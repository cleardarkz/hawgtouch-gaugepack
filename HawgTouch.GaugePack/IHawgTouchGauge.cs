using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HawgTouch.GaugePack
{
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

        void UpdateGauge(string strData);
    }
}
