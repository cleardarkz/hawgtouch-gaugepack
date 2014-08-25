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
    public partial class UH1VerticalSpeedGauge : UserControl, IHawgTouchGauge
    {
        private GaugeType _Type = GaugeType.OilPressureGauge;
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

        public UH1VerticalSpeedGauge(/*string strDataImportID*/)
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
                           //rt.Angle = angle * 165;
                           rt.Angle = angle * 162;
                           this.VVINeedle.RenderTransform = rt;
                       }));
        }
    }
}
