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
    public partial class UH1ASIGauge : UserControl, IHawgTouchGauge
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

        public UH1ASIGauge(/*string strDataImportID*/)
        {
            InitializeComponent();
            //_DataImportID = strDataImportID;
        }


        public void UpdateGauge(string strData)
        {
            double value = Convert.ToDouble(strData, CultureInfo.InvariantCulture);

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       (Action)(() =>
                       {
                           RotateTransform rt = new RotateTransform();
                           // (Start Angle - End Angle) / (Start Value - End Value) * (Actual Value - Start Value ) + Start Angle
                           // 150 = 346.2 = 1.0
                           // 120 = 281.7 = 0.825
                           // 80 = 195.4 = 0.55
                           // 60 = 152.3 = 0.44
                           // 50 = 135.5 = 0.395
                           // 40 = 109 = 0.32
                           // 30 = 66.5 = 0.19
                           // 20 = 23 = 0.075
                           // 0 = 0
                           if (value > 0.0 && value <= 0.075)
                           {
                               double startAngle = 0.0;
                               double endAngle = 23.1;
                               double startValue = 0.0;
                               double endValue = 0.075;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.075 && value <= 0.19)
                           {
                               double startAngle = 23.1;
                               double endAngle = 66.5;
                               double startValue = 0.075;
                               double endValue = 0.19;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.19 && value <= 0.32)
                           {
                               double startAngle = 66.5;
                               double endAngle = 109.0;
                               double startValue = 0.19;
                               double endValue = 0.32;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.32 && value <= 0.395)
                           {
                               double startAngle = 109.0;
                               double endAngle = 135.5;
                               double startValue = 0.32;
                               double endValue = 0.395;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.395 && value <= 0.44)
                           {
                               double startAngle = 135.5;
                               double endAngle = 152.3;
                               double startValue = 0.395;
                               double endValue = 0.44;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.44 && value <= 0.55)
                           {
                               double startAngle = 152.3;
                               double endAngle = 195.4;
                               double startValue = 0.44;
                               double endValue = 0.55;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.55 && value <= 0.825)
                           {
                               double startAngle = 195.4;
                               double endAngle = 281.7;
                               double startValue = 0.55;
                               double endValue = 0.825;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 0.825 && value <= 1.0)
                           {
                               double startAngle = 281.7;
                               double endAngle = 346.2;
                               double startValue = 0.825;
                               double endValue = 1.0;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else
                           {
                               rt.Angle = 0.0;
                           }

                           this.SpeedNeedle.RenderTransform = rt;
                           Digital.Text = value.ToString();
                       }));
        }
    }
}
