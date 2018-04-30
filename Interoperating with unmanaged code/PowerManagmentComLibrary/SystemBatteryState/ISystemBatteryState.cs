using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentComLibrary.SystemBatteryState
{
    [ComVisible(true)]
    [Guid("74041e02-55a1-496c-967e-bd38e95de644")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ISystemBatteryState
    {
        bool AcOnLine { get; set; }
        bool BatteryPresent { get; set; }
        bool Charging { get; set; }
        bool Discharging { get; set; }
        bool[] Spare1 { get; set; }
        ushort MaxCapacity { get; set; }
        ushort RemainingCapacity { get; set; }
        ushort Rate { get; set; }
        ushort EstimatedTime { get; set; }
        ushort DefaultAlert1 { get; set; }
        ushort DefaultAlert2 { get; set; }
    }
}
