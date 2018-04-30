using PowerManagmentComLibrary.SystemBatteryState;
using PowerManagmentComLibrary.SystemPowerInformation;
using PowerManagmentLibrary;
using System;
using System.Runtime.InteropServices;

namespace PowerManagmentComLibrary.PowerManagment
{
    [ComVisible(true)]
    [Guid("20839be7-b710-4df5-8482-2171e201fadf")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPowerManagmentCom
    {
        ulong GetLastSleepTime();
        ulong GetLastWakeTime();
        ISystemPowerInformation GetPowerInformation();
        ISystemBatteryState GetBatteryState();
        void ReserveHiberFile();
        void RemoveHiberFile();
        bool SetSuspendState(bool hibernate);
    }
}
