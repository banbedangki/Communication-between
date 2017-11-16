using SimpleHmi.PlcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleHmi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        S7PlcService _plcService;
        //        S7PlcService s = new S7PlcService();

        public MainWindow()
        {
            InitializeComponent();
            INFSETPOINTVL.Text = "45";
            IQFSETPOINTVL.Text = "1";
            GLZSETPOINTVL.Text = "1";
            HDSETPOINTVL.Text = "1";
            RFSETPOINTVL.Text = "1";
        }

        string INF_Old, IQF_Old, GLZ_Old, HD_Old, RF_Old;

        // INF SETPOINT
        private void INFSETPOINT_TextChanged(object sender, EventArgs e)
        {
            string Tam = INFSETPOINTVL.Text;
            double T;

            if (INFSETPOINTVL.Text == "-")
            {
                return;
            }

            if (Tam == "")
            {
                INF_Old = "1";
                INFSETPOINTVL.Text = "1";
            }
            else
            {
                if (double.TryParse(Tam, out T))
                {
                    if (T > 40) { INFSETPOINTVL.Text = "40"; }
                    if (T < 1) { INFSETPOINTVL.Text = "1"; }
                    else if (T > 1 && T < 45)
                    {
                        INF_Old = Tam;
                        _plcService = S7PlcService.Instance;
                        _plcService.INFSETPOINTVL = INFSETPOINTVL.Text;
                        _plcService.SetInf(0);
                    }
                }
                else
                {
                    INFSETPOINTVL.Text = INF_Old;

                }
            }
        }

        // IQF SETPOINT
        private void IQFSETPOINT_TextChanged(object sender, EventArgs e)
        {
            string Tam2 = IQFSETPOINTVL.Text;
            double T2;

            if (IQFSETPOINTVL.Text == "-")
            {
                return;
            }

            if (Tam2 == "")
            {
                IQF_Old = "1";
                IQFSETPOINTVL.Text = "1";
            }
            else
            {
                if (double.TryParse(Tam2, out T2))
                {
                    if (T2 > 40) { IQFSETPOINTVL.Text = "40"; }
                    if (T2 < 1) { IQFSETPOINTVL.Text = "1"; }
                    else if (T2 > 1 && T2 < 45)
                    {
                        IQF_Old = Tam2;
                        _plcService = S7PlcService.Instance;
                        _plcService.IQFSETPOINTVL = IQFSETPOINTVL.Text;
                        _plcService.SetInf(1);
                    }
                }
                else
                {
                    IQFSETPOINTVL.Text = IQF_Old;

                }
            }
        }

        // GLZ SETPOINT
        private void GLZSETPOINT_TextChanged(object sender, EventArgs e)
        {
            string Tam3 = GLZSETPOINTVL.Text;
            double T3;

            if (GLZSETPOINTVL.Text == "-")
            {
                return;
            }

            if (Tam3 == "")
            {
                GLZ_Old = "1";
                GLZSETPOINTVL.Text = "1";
            }
            else
            {
                if (double.TryParse(Tam3, out T3))
                {
                    if (T3 > 40) { GLZSETPOINTVL.Text = "40"; }
                    if (T3 < 1) { GLZSETPOINTVL.Text = "1"; }
                    else if (T3 > 1 && T3 < 45)
                    {
                        GLZ_Old = Tam3;
                        _plcService = S7PlcService.Instance;
                        _plcService.GLZSETPOINTVL = GLZSETPOINTVL.Text;
                        _plcService.SetInf(2);
                    }
                }
                else
                {
                    GLZSETPOINTVL.Text = GLZ_Old;

                }
            }
        }

        // HD SETPOINT
        private void HDSETPOINT_TextChanged(object sender, EventArgs e)
        {
            string Tam4 = HDSETPOINTVL.Text;
            double T4;

            if (HDSETPOINTVL.Text == "-")
            {
                return;
            }

            if (Tam4 == "")
            {
                HD_Old = "1";
                HDSETPOINTVL.Text = "1";
            }
            else
            {
                if (double.TryParse(Tam4, out T4))
                {
                    if (T4 > 40) { HDSETPOINTVL.Text = "40"; }
                    if (T4 < 1) { HDSETPOINTVL.Text = "1"; }
                    else if (T4 > 1 && T4 < 45)
                    {
                        HD_Old = Tam4;
                        _plcService = S7PlcService.Instance;
                        _plcService.HDSETPOINTVL = HDSETPOINTVL.Text;
                        _plcService.SetInf(3);
                    }
                }
                else
                {
                    HDSETPOINTVL.Text = HD_Old;

                }
            }
        }

        // RF SETPOINT
        private void RFSETPOINT_TextChanged(object sender, EventArgs e)
        {
            string Tam5 = RFSETPOINTVL.Text;
            double T5;

            if (RFSETPOINTVL.Text == "-")
            {
                return;
            }

            if (Tam5 == "")
            {
                RF_Old = "1";
                RFSETPOINTVL.Text = "1";
            }
            else
            {
                if (double.TryParse(Tam5, out T5))
                {
                    if (T5 > 40) { RFSETPOINTVL.Text = "40"; }
                    if (T5 < 1) { RFSETPOINTVL.Text = "1"; }
                    else if (T5 > 1 && T5 < 45)
                    {
                        RF_Old = Tam5;
                        _plcService = S7PlcService.Instance;
                        _plcService.RFSETPOINTVL = RFSETPOINTVL.Text;
                        _plcService.SetInf(4);
                    }
                }
                else
                {
                    RFSETPOINTVL.Text = RF_Old;

                }
            }
        }
    }
}
