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
    public partial class P51Speedometer : UserControl, IHawgTouchGauge
    {
        private string _DataImportID;

        public System.Windows.Size Size
        {
            get
            {
                return new System.Windows.Size(400, 400);
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

        public P51Speedometer(/*string strDataImportID*/)
        {
            InitializeComponent();
            //_DataImportID = strDataImportID;
        }


        public void UpdateGauge(string strData)
        {
            double angle = Convert.ToDouble(strData, CultureInfo.InvariantCulture);

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       (Action)(() =>
                       {
                           RotateTransform rt = new RotateTransform();
                           rt.Angle = (angle * 1000);
                           double minOffset = 60 + ((angle * 100) - 15);
                           double superOffset = ((angle * 100) - 23.5) * 10;

                           if (angle <= 0.300 && angle >= 0.250)
                           {

                               rt.Angle = rt.Angle - 70;
                           }
                           else if (angle < 0.250)
                           {
                               rt.Angle = rt.Angle - minOffset;
                           }
                           else if (angle > 0.300)
                               rt.Angle = 230 + (angle * 220) - 59;

                           this.SpeedNeedle.RenderTransform = rt;
                           Digital.Text = Convert.ToInt32(angle * 1000).ToString();
                       }));
        }
    }
}
