using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentComLibrary.SystemBatteryState
{
    [ComVisible(true)]
    [Guid("b5397cf8-63ed-48c0-b807-80e135a8d606")]
    [ClassInterface(ClassInterfaceType.None)]
    public class SystemBatteryStateCom : ISystemBatteryState
    {
        private bool[] spare1;
        private bool acOnLine;
        private bool batteryPresent;
        private bool charging;
        private bool discharging;
        private ushort maxCapacity;
        private ushort remainingCapacity;
        private ushort rate;
        private ushort estimatedTime;
        private ushort defaultAlert1;
        private ushort defaultAlert2;

        public SystemBatteryStateCom()
        {
            spare1 = new bool[4];
        }

        bool ISystemBatteryState.AcOnLine
        {
            get { return acOnLine; }
            set { acOnLine = value; }
        }

        bool ISystemBatteryState.BatteryPresent
        {
            get { return batteryPresent; }
            set { batteryPresent = value; }
        }

        bool ISystemBatteryState.Charging
        {
            get { return charging; }
            set { charging = value; }
        }

        ushort ISystemBatteryState.DefaultAlert1
        {
            get { return defaultAlert1; }
            set { defaultAlert1 = value; }
        }

        ushort ISystemBatteryState.DefaultAlert2
        {
            get { return defaultAlert2; }
            set { defaultAlert2 = value; }
        }

        bool ISystemBatteryState.Discharging
        {
            get { return discharging; }
            set { discharging = value; }
        }

        ushort ISystemBatteryState.EstimatedTime
        {
            get { return estimatedTime; }
            set { estimatedTime = value; }
        }

        ushort ISystemBatteryState.MaxCapacity
        {
            get { return maxCapacity; }
            set { maxCapacity = value; }
        }

        ushort ISystemBatteryState.Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        ushort ISystemBatteryState.RemainingCapacity
        {
            get { return remainingCapacity; }
            set { remainingCapacity = value; }
        }

        bool[] ISystemBatteryState.Spare1
        {
            get { return spare1; }
            set { spare1 = value; }
        }
    }
}
