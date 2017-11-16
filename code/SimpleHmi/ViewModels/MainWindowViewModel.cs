using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimpleHmi.PlcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleHmi.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public string IpAddress
        {
            get { return _ipAddress; }
            set { SetProperty(ref _ipAddress, value); }
        }
        private string _ipAddress;

        public string INFSETPOINTVL
        {
            get { return _INFSETPOINTVL; }
            set { SetProperty(ref _INFSETPOINTVL, value); }
        }
        private string _INFSETPOINTVL;

        public string IQFSETPOINTVL
        {
            get { return _IQFSETPOINTVL; }
            set { SetProperty(ref _IQFSETPOINTVL, value); }
        }
        private string _IQFSETPOINTVL;

        public string GLZSETPOINTVL
        {
            get { return _GLZSETPOINTVL; }
            set { SetProperty(ref _GLZSETPOINTVL, value); }
        }
        private string _GLZSETPOINTVL;

        public string HDSETPOINTVL
        {
            get { return _HDSETPOINTVL; }
            set { SetProperty(ref _HDSETPOINTVL, value); }
        }
        private string _HDSETPOINTVL;

        public string RFSETPOINTVL
        {
            get { return _RFSETPOINTVL; }
            set { SetProperty(ref _RFSETPOINTVL, value); }
        }
        private string _RFSETPOINTVL;

        public string a
        {
            get { return _a; }
            set { SetProperty(ref _a, value); }
        }
        private string _a;

        public double INFSTSPDP
        {
            get { return _INFSTSPDP; }
            set { SetProperty(ref _INFSTSPDP, value); }
        }
        private double _INFSTSPDP;

        public double INFSP
        {
            get { return _INFSP; }
            set { SetProperty(ref _INFSP, value); }
        }
        private double _INFSP;

        public double IQFSP
        {
            get { return _IQFSP; }
            set { SetProperty(ref _IQFSP, value); }
        }
        private double _IQFSP;

        public double GLZSP
        {
            get { return _GLZSP; }
            set { SetProperty(ref _GLZSP, value); }
        }
        private double _GLZSP;

        public double HDSP
        {
            get { return _HDSP; }
            set { SetProperty(ref _HDSP, value); }
        }
        private double _HDSP;

        public double RFSP
        {
            get { return _RFSP; }
            set { SetProperty(ref _RFSP, value); }
        }
        private double _RFSP;

        public double IQFTEMP
        {
            get { return _IQFTEMP; }
            set { SetProperty(ref _IQFTEMP, value); }
        }
        private double _IQFTEMP;

        public double CLWTEMP
        {
            get { return _CLWTEMP; }
            set { SetProperty(ref _CLWTEMP, value); }
        }
        private double _CLWTEMP;

        public double RFTEMP
        {
            get { return _RFTEMP; }
            set { SetProperty(ref _RFTEMP, value); }
        }
        private double _RFTEMP;

        public double CTBTEMP
        {
            get { return _CTBTEMP; }
            set { SetProperty(ref _CTBTEMP, value); }
        }
        private double _CTBTEMP;

        // DEVICES & BUTTONS STATE

        public bool Blower1
        {
            get { return _Blower1; }
            set { SetProperty(ref _Blower1, value); }
        }
        private bool _Blower1;

        public bool Blower2
        {
            get { return _Blower2; }
            set { SetProperty(ref _Blower2, value); }
        }
        private bool _Blower2;

        public bool Blower3
        {
            get { return _Blower3; }
            set { SetProperty(ref _Blower3, value); }
        }
        private bool _Blower3;

        public bool Blower4
        {
            get { return _Blower4; }
            set { SetProperty(ref _Blower4, value); }
        }
        private bool _Blower4;

        public bool Blower5
        {
            get { return _Blower5; }
            set { SetProperty(ref _Blower5, value); }
        }
        private bool _Blower5;

        public bool Blower6
        {
            get { return _Blower6; }
            set { SetProperty(ref _Blower6, value); }
        }
        private bool _Blower6;

        public bool Blower7
        {
            get { return _Blower7; }
            set { SetProperty(ref _Blower7, value); }
        }
        private bool _Blower7;

        public bool Blower8
        {
            get { return _Blower8; }
            set { SetProperty(ref _Blower8, value); }
        }
        private bool _Blower8;

        public bool Blower9
        {
            get { return _Blower9; }
            set { SetProperty(ref _Blower9, value); }
        }
        private bool _Blower9;

        public bool FlashingL
        {
            get { return _FlashingL; }
            set { SetProperty(ref _FlashingL, value); }
        }
        private bool _FlashingL;

        public bool IQF_LSV
        {
            get { return _IQF_LSV; }
            set { SetProperty(ref _IQF_LSV, value); }
        }
        private bool _IQF_LSV;

        public bool IQF_BDV
        {
            get { return _IQF_BDV; }
            set { SetProperty(ref _IQF_BDV, value); }
        }
        private bool _IQF_BDV;

        public bool IQF_AP
        {
            get { return _IQF_AP; }
            set { SetProperty(ref _IQF_AP, value); }
        }
        private bool _IQF_AP;

        public bool IQF_CDV
        {
            get { return _IQF_CDV; }
            set { SetProperty(ref _IQF_CDV, value); }
        }
        private bool _IQF_CDV;

        public bool IQF_BD_WP
        {
            get { return _IQF_BD_WP; }
            set { SetProperty(ref _IQF_BD_WP, value); }
        }
        private bool _IQF_BD_WP;

        public bool IQF_CD_WP
        {
            get { return _IQF_CD_WP; }
            set { SetProperty(ref _IQF_CD_WP, value); }
        }
        private bool _IQF_CD_WP;

        public bool RF_LSV
        {
            get { return _RF_LSV; }
            set { SetProperty(ref _RF_LSV, value); }
        }
        private bool _RF_LSV;

        public bool RF_BDV
        {
            get { return _RF_BDV; }
            set { SetProperty(ref _RF_BDV, value); }
        }
        private bool _RF_BDV;

        public bool RF_AP
        {
            get { return _RF_AP; }
            set { SetProperty(ref _RF_AP, value); }
        }
        private bool _RF_AP;


        public bool RF_CDV
        {
            get { return _RF_CDV; }
            set { SetProperty(ref _RF_CDV, value); }
        }
        private bool _RF_CDV;

        public bool RF_BD_WP
        {
            get { return _RF_BD_WP; }
            set { SetProperty(ref _RF_BD_WP, value); }
        }
        private bool _RF_BD_WP;

        public bool RF_CD_WP
        {
            get { return _RF_CD_WP; }
            set { SetProperty(ref _RF_CD_WP, value); }
        }
        private bool _RF_CD_WP;


        public ConnectionStates ConnectionState
        {
            get { return _connectionState; }
            set { SetProperty(ref _connectionState, value); }
        }
        private ConnectionStates _connectionState;

        public TimeSpan ScanTime
        {
            get { return _scanTime; }
            set { SetProperty(ref _scanTime, value); }
        }
        private TimeSpan _scanTime;

        public ICommand ConnectCommand { get; private set; }

        public ICommand DisconnectCommand { get; private set; }

        public ICommand SetInfCommand { get; private set; }

        public ICommand IBCommand { get; private set; }

        public ICommand RBCommand { get; private set; }

        public ICommand IBDCommand { get; private set; }

        public ICommand RBDCommand { get; private set; }

        public ICommand ICDCommand { get; private set; }

        public ICommand RCDCommand { get; private set; }

        public ICommand ILSCommand { get; private set; }

        public ICommand RLSCommand { get; private set; }

        public ICommand INFCommand { get; private set; }

        public ICommand IQFCommand { get; private set; }

        public ICommand GLZCommand { get; private set; }

        public ICommand HDCommand { get; private set; }

        public ICommand RFCommand { get; private set; }

        public ICommand OCMCommand { get; private set; }

        public ICommand GLZPCommand { get; private set; }

        public ICommand INVMCommand { get; private set; }

        public ICommand MANSCommand { get; private set; }

        public ICommand QCKSCommand { get; private set; }

        public ICommand SBSCommand { get; private set; }

        S7PlcService _plcService;

        public MainWindowViewModel()
        {
            _plcService = S7PlcService.Instance;
            ConnectCommand = new DelegateCommand(Connect);
            DisconnectCommand = new DelegateCommand(Disconnect);
            SetInfCommand = new DelegateCommand(SetInf);
            IBCommand = new DelegateCommand(async () => { await IB(); });
            RBCommand = new DelegateCommand(async () => { await RB(); });
            IBDCommand = new DelegateCommand(async () => { await IBD(); });
            RBDCommand = new DelegateCommand(async () => { await RBD(); });
            ICDCommand = new DelegateCommand(async () => { await ICD(); });
            RCDCommand = new DelegateCommand(async () => { await RCD(); });
            ILSCommand = new DelegateCommand(async () => { await ILS(); });
            RLSCommand = new DelegateCommand(async () => { await RLS(); });
            INFCommand = new DelegateCommand(async () => { await INF(); });
            IQFCommand = new DelegateCommand(async () => { await IQF(); });
            GLZCommand = new DelegateCommand(async () => { await GLZ(); });
            HDCommand = new DelegateCommand(async () => { await HD(); });
            RFCommand = new DelegateCommand(async () => { await RF(); });
            OCMCommand = new DelegateCommand(async () => { await OCM(); });
            GLZPCommand = new DelegateCommand(async () => { await GLZP(); });
            INVMCommand = new DelegateCommand(async () => { await INVM(); });
            MANSCommand = new DelegateCommand(async () => { await MANS(); });
            QCKSCommand = new DelegateCommand(async () => { await QCKS(); });
            SBSCommand = new DelegateCommand(async () => { await SBS(); }); 

            IpAddress = "192.168.1.15";
 //           INFSETPOINTVL = "11.8";

            OnPlcServiceValuesRefreshed(null, null);
            _plcService.ValuesRefreshed += OnPlcServiceValuesRefreshed;
        }

        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            ConnectionState = _plcService.ConnectionState;
            ScanTime = _plcService.ScanTime;

            INFSETPOINTVL = _plcService.INFSETPOINTVL;

            IQFSETPOINTVL = _plcService.IQFSETPOINTVL;

            GLZSETPOINTVL = _plcService.GLZSETPOINTVL;

            HDSETPOINTVL = _plcService.HDSETPOINTVL;

            RFSETPOINTVL = _plcService.RFSETPOINTVL;

            a = _plcService.a;

            INFSTSPDP = _plcService.INFSTSPDP;

            INFSP = _plcService.INFSP;
            IQFSP = _plcService.IQFSP;
            GLZSP = _plcService.GLZSP;
            HDSP = _plcService.HDSP;
            RFSP = _plcService.RFSP;

            IQFTEMP = _plcService.IQFTEMP;
            CLWTEMP = _plcService.CLWTEMP;
            RFTEMP = _plcService.RFTEMP;
            CTBTEMP = _plcService.CTBTEMP;

            Blower1 = _plcService.Blower1;
            Blower2 = _plcService.Blower2;
            Blower3 = _plcService.Blower3;
            Blower4 = _plcService.Blower4;
            Blower5 = _plcService.Blower5;
            Blower6 = _plcService.Blower6;
            Blower7 = _plcService.Blower7;
            Blower8 = _plcService.Blower8;
            Blower9 = _plcService.Blower9;

            FlashingL = _plcService.FlashingL;

            IQF_LSV = _plcService.IQF_LSV;
            IQF_BDV = _plcService.IQF_BDV;
            IQF_AP = _plcService.IQF_AP;
            IQF_CDV = _plcService.IQF_CDV;
            IQF_BD_WP= _plcService.IQF_BD_WP;
            IQF_CD_WP = _plcService.IQF_CD_WP;

            RF_LSV = _plcService.RF_LSV;
            RF_BDV = _plcService.RF_BDV;
            RF_AP = _plcService.RF_AP;
            RF_CDV = _plcService.RF_CDV;
            RF_BD_WP = _plcService.RF_BD_WP;
            RF_CD_WP = _plcService.RF_CD_WP;
        }

        private void Connect()
        {
            _plcService.Connect(IpAddress, 0, 1);
        }

        private void Disconnect()
        {
            _plcService.Disconnect();
        }

        private void SetInf()
        {
          //  _plcService.SetInf();
        }

        private async Task IB()
        {
            await _plcService.WriteButton("DB183.DBX0.0");
        }

        private async Task RB()
        {
            await _plcService.WriteButton("DB183.DBX0.1");
        }

        private async Task IBD()
        {
            await _plcService.WriteButton("DB183.DBX0.2");
        }

        private async Task RBD()
        {
            await _plcService.WriteButton("DB183.DBX0.3");
        }

        private async Task ICD()
        {
            await _plcService.WriteButton("DB183.DBX0.4");
        }

        private async Task RCD()
        {
            await _plcService.WriteButton("DB183.DBX0.5");
        }

        private async Task ILS()
        {
            await _plcService.WriteButton("DB183.DBX0.6");
        }

        private async Task RLS()
        {
            await _plcService.WriteButton("DB183.DBX0.7");
        }

        private async Task INF()
        {
            await _plcService.WriteButton("DB184.DBX0.0");
        }

        private async Task IQF()
        {
            await _plcService.WriteButton("DB184.DBX0.1");
        }
        private async Task GLZ()
        {
            await _plcService.WriteButton("DB184.DBX0.2");
        }
        private async Task HD()
        {
            await _plcService.WriteButton("DB184.DBX0.3");
        }
        private async Task RF()
        {
            await _plcService.WriteButton("DB184.DBX0.4");
        }
        private async Task OCM()
        {
            await _plcService.WriteButton("DB184.DBX0.5");
        }

        private async Task GLZP()
        {
            await _plcService.WriteButton("DB184.DBX0.6");
        }
        private async Task INVM()
        {
            await _plcService.WriteButton("DB184.DBX0.7");
        }
        private async Task MANS()
        {
            await _plcService.WriteButton("DB185.DBX0.0");
        }
        private async Task QCKS()
        {
            await _plcService.WriteButton("DB185.DBX0.1");
        }
        private async Task SBS()
        {
            await _plcService.WriteButton("DB185.DBX0.2");
        }

    }
}
