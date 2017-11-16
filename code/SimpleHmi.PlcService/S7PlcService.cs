using Sharp7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHmi.PlcService
{
    public class S7PlcService
    {
        private readonly S7Client _client;
        private readonly System.Timers.Timer _timer;
        private DateTime _lastScanTime;
        private volatile object _locker = new object();

        public S7PlcService()
        {
            _client = new S7Client();
            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += OnTimerElapsed;
        }

        private static S7PlcService instance;

        public static S7PlcService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new S7PlcService();
                }
                return instance;
            }
        }
        public ConnectionStates ConnectionState { get; private set; }

        public string INFSETPOINTVL { get; set; }

        public string IQFSETPOINTVL { get; set; }

        public string GLZSETPOINTVL { get; set; }

        public string HDSETPOINTVL { get; set; }

        public string RFSETPOINTVL { get; set; }

        public string a { get; set; }

        public double INFSTSPDP { get; set; }
        public double IQFSTSPDP { get; private set; }
        public double GLZSTSPDP { get; private set; }
        public double HDSTSPDP { get; private set; }
        public double RFSTSPDP { get; private set; }


        public double INFSP { get; private set; }

        public double IQFSP { get; private set; }

        public double GLZSP { get; private set; }

        public double HDSP { get; private set; }

        public double RFSP { get; private set; }

        public double IQFTEMP { get; private set; }

        public double CLWTEMP { get; private set; }

        public double RFTEMP { get; private set; }

        public double CTBTEMP { get; private set; }

        public bool Blower1 { get; private set; }

        public bool Blower2 { get; private set; }

        public bool Blower3 { get; private set; }

        public bool Blower4 { get; private set; }

        public bool Blower5 { get; private set; }

        public bool Blower6 { get; private set; }

        public bool Blower7 { get; private set; }

        public bool Blower8 { get; private set; }

        public bool Blower9 { get; private set; }

        public bool FlashingL { get; private set; }

        public bool IQF_BLW_BT { get; private set; }

        public bool IQF_LS_BT { get; private set; }

        public bool IQF_BD_BT { get; private set; }

        public bool IQF_CD_BT { get; private set; }

        public bool IQF_LSV { get; private set; }

        public bool IQF_BDV { get; private set; }

        public bool IQF_AP { get; private set; }

        public bool IQF_CDV { get; private set; }

        public bool IQF_BD_WP { get; private set; }

        public bool IQF_CD_WP { get; private set; }

        public bool RF_BLW_BT { get; private set; }

        public bool RF_LS_BT { get; private set; }

        public bool RF_BD_BT { get; private set; }

        public bool RF_CD_BT { get; private set; }

        public bool RF_LSV { get; private set; }

        public bool RF_BDV { get; private set; }

        public bool RF_AP { get; private set; }

        public bool RF_CDV { get; private set; }

        public bool RF_BD_WP { get; private set; }

        public bool RF_CD_WP { get; private set; }

        public TimeSpan ScanTime { get; private set; }

        public event EventHandler ValuesRefreshed;

        // CONNECT TO PLC
        public void Connect(string ipAddress, int rack, int slot)
        {
            try
            {
                ConnectionState = ConnectionStates.Connecting;
                int result = _client.ConnectTo(ipAddress, rack, slot);
                if (result == 0)
                {
                    ConnectionState = ConnectionStates.Online;
                    _timer.Start();
                }
                else
                {
                    Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Connection error: " + _client.ErrorText(result));
                    ConnectionState = ConnectionStates.Offline;
                }
                OnValuesRefreshed();
            }
            catch
            {
                ConnectionState = ConnectionStates.Offline;
                OnValuesRefreshed();
                throw;
            }
        }

        // DISCONNECT FC

        public void Disconnect()
        {
            if (_client.Connected)
            {
                _timer.Stop();
                _client.Disconnect();
                ConnectionState = ConnectionStates.Offline;
                OnValuesRefreshed();
            }
        }

                /// <summary>
        /// Writes a bit at the specified address. Es.: DB1.DBX10.2 writes the bit in db 1, word 10, 3rd bit
        /// </summary>
        /// <param name="address">Es.: DB1.DBX10.2 writes the bit in db 1, word 10, 3rd bit</param>
        /// <param name="value">true or false</param>
        /// <returns></returns>
        private int WriteBit(string address, bool value)
        {
            var strings = address.Split('.');
            int db = Convert.ToInt32(strings[0].Replace("DB", ""));
            int pos = Convert.ToInt32(strings[1].Replace("DBX", ""));
            int bit = Convert.ToInt32(strings[2]);
            return WriteBit(db, pos, bit, value);
        }

        private int WriteBit(int db, int pos, int bit, bool value)
        {
            lock (_locker)
            {
                int a = (pos * 8) + bit;
                var buffer = new byte[20];
                S7.SetBitAt(ref buffer, pos, bit, value);
                return _client.WriteArea(S7Consts.S7AreaDB, db, a, buffer.Length, S7Consts.S7WLBit, buffer);
            }
        }


        // WRITE WORD
        private int WriteWord(string address, short value)
        {
            var strings = address.Split('.');
            var db = Convert.ToInt32(strings[0].Replace("DB", ""));
            var pos = Convert.ToInt32(strings[1].Replace("DBW", ""));
            return WriteWord(db, pos, value);
        }

        private int WriteWord(int dbNumber, int startIndex, short value)
        {
            lock (_locker)
            {
                var buffer = new byte[32];
                S7.SetIntAt(buffer, 0, value);
                return _client.DBWrite(dbNumber, startIndex, buffer.Length, buffer);
            }
        }

        // CLICK BUTTON
        public async Task WriteButton(string address)
        {
            await Task.Run(() =>
            {
                int writeResult = WriteBit(address, true);
                if (writeResult != 0)
                {
                    Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " + _client.ErrorText(writeResult));
                }
                Thread.Sleep(30);
                writeResult = WriteBit(address, false);
                if (writeResult != 0)
                {
                    Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " + _client.ErrorText(writeResult));
                }
            });
        }

        // WRITE:  CONVEYOR SPEEDTIME SETPOINT
        public float tam1, tam2, tam3, tam4, tam5;
        public Task SetInf(int add)
        {
            return Task.Run(() =>
            {
                {
                    var s7multivar3 = new S7MultiVar(_client);
                    byte[] buffer189 = new byte[20];
                    string INFSTSPVL = INFSETPOINTVL;
                    string IQFSTSPVL = IQFSETPOINTVL;
                    string GLZSTSPVL = GLZSETPOINTVL;
                    string HDSTSPVL = HDSETPOINTVL;
                    string RFSTSPVL = RFSETPOINTVL;
                    float INF_ST_SP2;

                    if (add == 0)
                    {
                        INF_ST_SP2 = float.Parse(INFSTSPVL);
                        INF_ST_SP2 = Convert.ToSingle(INFSTSPVL);
                        tam1 = INF_ST_SP2;
                    }

                    if (add == 1)
                    {
                        INF_ST_SP2 = float.Parse(IQFSTSPVL);
                        INF_ST_SP2 = Convert.ToSingle(IQFSTSPVL);
                        tam2 = INF_ST_SP2;
                    }

                    if (add == 2)
                    {
                        INF_ST_SP2 = float.Parse(GLZSTSPVL);
                        INF_ST_SP2 = Convert.ToSingle(GLZSTSPVL);
                        tam3 = INF_ST_SP2;
                    }

                    if (add == 3)
                    {
                        INF_ST_SP2 = float.Parse(HDSTSPVL);
                        INF_ST_SP2 = Convert.ToSingle(HDSTSPVL);
                        tam4 = INF_ST_SP2;
                    }

                    if (add == 4)
                    {
                        INF_ST_SP2 = float.Parse(RFSTSPVL);
                        INF_ST_SP2 = Convert.ToSingle(RFSTSPVL);
                        tam5 = INF_ST_SP2;
                    }

                    s7multivar3.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, 189, 0, buffer189.Length, ref buffer189);
                    S7.SetRealAt(buffer189, 0, (float)tam1);
                    S7.SetRealAt(buffer189, 4, (float)tam2);
                    S7.SetRealAt(buffer189, 8, (float)tam3);
                    S7.SetRealAt(buffer189, 12, (float)tam4);
                    S7.SetRealAt(buffer189, 16, (float)tam5);
                    int result89 = s7multivar3.Write();
                }
            });
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                ScanTime = DateTime.Now - _lastScanTime;
                RefreshValues();
                OnValuesRefreshed();
            }
            finally
            {
                _timer.Start();
            }
            _lastScanTime = DateTime.Now;
        }

        public void RefreshValues()
        {
            lock (_locker)

            //{
            //    var s7MultiVar = new S7MultiVar(_client);
            //    byte[] buffer189 = new byte[20];
            //    s7MultiVar.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, 189, 0, 20, ref buffer189);
            //    int result189 = s7MultiVar.Read();
            //    if (result189 == 0)
            //    {
            //        INFSTSPDP = Math.Round(S7.GetRealAt(buffer189, 0), 1);
            //        a = INFSTSPDP.ToString();
            //        IQFSTSPDP = Math.Round(S7.GetRealAt(buffer189, 4), 1);
            //        GLZSTSPDP = Math.Round(S7.GetRealAt(buffer189, 8), 1);
            //        HDSTSPDP = Math.Round(S7.GetRealAt(buffer189, 12), 1);
            //        RFSTSPDP = Math.Round(S7.GetRealAt(buffer189, 16), 1);
            //    }
            //    else
            //    {
            //        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Read error: " + _client.ErrorText(result189));
            //    }
            //}

            // READ: CONVEYORS SPEED TIME
            {
                var s7MultiVar = new S7MultiVar(_client);
                byte[] buffer88 = new byte[20];
                s7MultiVar.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, 88, 0, 20, ref buffer88);
                int result88 = s7MultiVar.Read();
                if (result88 == 0)
                {
                    INFSP = Math.Round(S7.GetRealAt(buffer88, 0), 1);
                    IQFSP = Math.Round(S7.GetRealAt(buffer88, 4), 1);
                    GLZSP = Math.Round(S7.GetRealAt(buffer88, 8), 1);
                    HDSP = Math.Round(S7.GetRealAt(buffer88, 12), 1);
                    RFSP = Math.Round(S7.GetRealAt(buffer88, 16), 1);
                }
                else
                {
                    Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Read error: " + _client.ErrorText(result88));
                }
            }

            // READ: TEMPERATURE

            {
                var s7MultiVar2 = new S7MultiVar(_client);
                byte[] buffer186 = new byte[19];
                s7MultiVar2.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, 186, 0, 19, ref buffer186);
                int result186 = s7MultiVar2.Read();
                if (result186 == 0)
                {
                    IQFTEMP = Math.Round(S7.GetRealAt(buffer186, 0), 1);
                    CLWTEMP = Math.Round(S7.GetRealAt(buffer186, 4), 1);
                    RFTEMP = Math.Round(S7.GetRealAt(buffer186, 8), 1);
                    CTBTEMP = Math.Round(S7.GetRealAt(buffer186, 12), 1);

                    // READ DEVICES STATE
                    Blower1 = S7.GetBitAt(buffer186, 16, 0);
                    Blower2 = S7.GetBitAt(buffer186, 16, 1);
                    Blower3 = S7.GetBitAt(buffer186, 16, 2);
                    Blower4 = S7.GetBitAt(buffer186, 16, 3);
                    Blower5 = S7.GetBitAt(buffer186, 16, 4);
                    Blower6 = S7.GetBitAt(buffer186, 16, 5);
                    Blower7 = S7.GetBitAt(buffer186, 16, 6);
                    Blower8 = S7.GetBitAt(buffer186, 16, 7);
                    Blower9 = S7.GetBitAt(buffer186, 17, 0);

                    FlashingL = S7.GetBitAt(buffer186, 17, 1);

                    IQF_LSV = S7.GetBitAt(buffer186, 17, 2);
                    IQF_BDV = S7.GetBitAt(buffer186, 17, 3);
                    IQF_AP = S7.GetBitAt(buffer186, 17, 4);
                    IQF_CDV = S7.GetBitAt(buffer186, 17, 5);
                    IQF_BD_WP = S7.GetBitAt(buffer186, 17, 6);
                    IQF_CD_WP = S7.GetBitAt(buffer186, 17, 7);

                    RF_LSV = S7.GetBitAt(buffer186, 18, 0);
                    RF_BDV = S7.GetBitAt(buffer186, 18, 1);
                    RF_AP = S7.GetBitAt(buffer186, 18, 2);
                    RF_CDV = S7.GetBitAt(buffer186, 18, 3);
                    RF_BD_WP = S7.GetBitAt(buffer186, 18, 4);
                    RF_CD_WP = S7.GetBitAt(buffer186, 18, 5);
                }
                else
                {
                    Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Read error: " + _client.ErrorText(result186));
                }
            }
        }

        private void OnValuesRefreshed()
        {
            ValuesRefreshed.Invoke(this, new EventArgs());
        }
    }
}

