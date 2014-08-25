using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Threading;
using System.Globalization;

namespace HawgTouch.GaugePack.Gauges
{
    public partial class A10TACAN : UserControl, IHawgTouchGauge
    {
        private GaugeType _Type = GaugeType.FanSpeedGauge;
        private string _DataImportID;

        public GaugeType Type
        {
            get
            {
                return _Type;
            }
        }

        public System.Windows.Size Size
        {
            get
            {
                return new System.Windows.Size(270, 100);
            }
        }

        public string DataImportID
        {
            get
            {
                return _DataImportID;
            }
            set
            {
                _DataImportID = value;
            }
        }

        public A10TACAN(/*string strDataImportID*/)
        {
            InitializeComponent();
            //_DataImportID = strDataImportID;
        }


        public void UpdateGauge(string strData)
        {

            string[] vals = strData.Split(';');

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       (Action)(() =>
                       {

                           double left = Convert.ToDouble(vals[0], CultureInfo.InvariantCulture);
                           double middle = Convert.ToDouble(vals[1], CultureInfo.InvariantCulture) * 10;
                           double right = Convert.ToDouble(vals[2], CultureInfo.InvariantCulture) * 10;
                           double xy = Convert.ToDouble(vals[3], CultureInfo.InvariantCulture);
                           if (left != 1.0)
                               this.LeftT.Text = (left * 10).ToString();
                           else
                               this.LeftT.Text = "";

                           this.MiddleT.Text = ((int)middle).ToString();
                           this.RightT.Text = ((int)right).ToString();

                           if (xy == 1.0)
                               this.XY.Text = "Y";
                           else
                               this.XY.Text = "X";

                       }));
        }
    }
}
