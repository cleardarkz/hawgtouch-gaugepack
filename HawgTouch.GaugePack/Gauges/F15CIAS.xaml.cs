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
    public partial class F15CIAS : UserControl, IHawgTouchGauge
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

        public F15CIAS(/*string strDataImportID*/)
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
                           double valueIAS = Convert.ToDouble(vals[0], CultureInfo.InvariantCulture);
                           double valueMach = Convert.ToDouble(vals[1], CultureInfo.InvariantCulture);

                           // (Start Angle - End Angle) / (Start Value - End Value) * (Actual Value - Start Value ) + Start Angle
                           // +21.5
                           // 1000 = 338
                           // 700 = 290
                           // 400 = 200
                           // 200 = 100
                           // 50 = 25
                           // 0 = 0

                           double value = valueIAS * 1.943844;
                           RotateTransform rtIAS = new RotateTransform(); rtIAS.Angle = 21.5;
                           double startAngle = 0.0, endAngle = 25.0, startValue = 0.0, endValue = 50.0;
                           if (value <= 0)
                           {
                           }
                           if (value > 0.0 && value <= 50.0)
                           {
                               startAngle = 0.0;
                               endAngle = 25.0;
                               startValue = 0.0;
                               endValue = 50.0;
                               rtIAS.Angle += (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 50.0 && value <= 200.0)
                           {
                               startAngle = 25.0;
                               endAngle = 100.0;
                               startValue = 50.0;
                               endValue = 200.0;
                               rtIAS.Angle += (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 200.0 && value <= 400.0)
                           {
                               startAngle = 100.0;
                               endAngle = 200.0;
                               startValue = 200.0;
                               endValue = 400.0;
                               rtIAS.Angle += (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 400.0 && value <= 700.0)
                           {
                               startAngle = 200.0;
                               endAngle = 290.0;
                               startValue = 400.0;
                               endValue = 700.0;
                               rtIAS.Angle += (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 700.0 && value <= 1000.0)
                           {
                               startAngle = 290.0;
                               endAngle = 338.0;
                               startValue = 700.0;
                               endValue = 1000.0;
                               rtIAS.Angle += (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 1000.0)
                           {
                               rtIAS.Angle += 338.0;
                           }
                           this.Needle.RenderTransform = rtIAS;

                           // +206
                           // 2.46666667 = 214.57
                           // 2.4 = 206
                           // 1.0 = 26
                           // 0 = 0

                           value = valueMach;
                           RotateTransform rtMach = new RotateTransform(); rtMach.Angle = (rtIAS.Angle - 21.5) + 206.0;
                           startAngle = 0.0; endAngle = 26.0; startValue = 0.0; endValue = 1.0;
                           if (value <= 0.0 || valueIAS < 200)
                           {
                           }
                           if (value > 0.0 && value <= 1.0)
                           {
                               startAngle = 0.0;
                               endAngle = 26.0;
                               startValue = 0.0;
                               endValue = 1.0;
                               rtMach.Angle -= (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 1.0 && value <= 2.467)
                           {
                               startAngle = 26.0;
                               endAngle = 214.57;
                               startValue = 1.0;
                               endValue = 2.467;
                               rtMach.Angle -= (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else if (value > 2.467)
                           {
                               rtMach.Angle -= 214.57;
                           }
                           this.NeedleMach.RenderTransform = rtMach;
                       }));
        }
    }
}
