using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HawgTouch.GaugePack
{
    // DEPRECATED
    public enum GaugeType
    {
        FanSpeedGauge = 0,
        FuelFlowGauge = 1,
        APUEGTGauge = 2,
        APURPMGauge = 3,
        EngineRPMGauge = 4,
        EngineTempGauge = 5,
        OilPressureGauge = 6
    }
    public interface IHawgTouchGauge
    {
        string Name
        {
            get;
        }

        string DataImportID
        {
            get;
            set;
        }

        System.Windows.Size Size
        {
            get;
        }

        GaugeType Type
        {
            get;
        }

        void UpdateGauge(string strData);
    }
}
