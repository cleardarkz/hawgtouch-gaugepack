﻿using System;
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
    public partial class UH1GasProducerTach : UserControl, IHawgTouchGauge
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

        public UH1GasProducerTach(/*string strDataImportID*/)
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
                           double value = Convert.ToDouble(vals[0], CultureInfo.InvariantCulture);
                           double value_u = Convert.ToDouble(vals[1], CultureInfo.InvariantCulture);
                           RotateTransform rt = new RotateTransform();
                           RotateTransform rt_u = new RotateTransform();

                           if (value > 0.0 && value <= 1.0)
                           {
                               double startAngle = 0.0;
                               double endAngle = 270;
                               double startValue = 0.0;
                               double endValue = 1.0;
                               rt.Angle = (startAngle - endAngle) / (startValue - endValue) * (value - startValue) + startAngle;
                           }
                           else
                           {
                               rt.Angle = 0.0;
                           }

                           if (value_u > 0.0 && value_u <= 1.0)
                           {
                               double startAngle = 0.0;
                               double endAngle = 360;
                               double startValue = 0.0;
                               double endValue = 1.0;
                               rt_u.Angle = (startAngle - endAngle) / (startValue - endValue) * (value_u - startValue) + startAngle;
                           }
                           else
                           {
                               rt_u.Angle = 0.0;
                           }


                           this.GasNeedle.RenderTransform = rt;
                           this.GasNeedle_U.RenderTransform = rt_u;
                       }));
        }
    }
}
