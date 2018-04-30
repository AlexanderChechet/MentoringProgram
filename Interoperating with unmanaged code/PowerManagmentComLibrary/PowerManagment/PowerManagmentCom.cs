using System;
using PowerManagmentLibrary;
using System.Runtime.InteropServices;
using PowerManagmentComLibrary.SystemBatteryState;
using PowerManagmentComLibrary.SystemPowerInformation;

namespace PowerManagmentComLibrary.PowerManagment
{
    [ComVisible(true)]
    [Guid("daa29ada-2301-48c2-af14-b3363c44783b")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerManagmentCom : IPowerManagmentCom
    {
        ISystemBatteryState IPowerManagmentCom.GetBatteryState()
        {
            var state = PowerManagmentLibrary.PowerManagment.GetBatteryState();
            var result = (ISystemBatteryState)(new SystemBatteryStateCom());
            result.AcOnLine = state.AcOnLine;
            result.BatteryPresent = state.BatteryPresent;
            result.Charging = state.Charging;
            result.DefaultAlert1 = state.DefaultAlert1;
            result.DefaultAlert2 = state.DefaultAlert2;
            result.Discharging = state.Discharging;
            result.EstimatedTime = state.EstimatedTime;
            result.MaxCapacity = state.MaxCapacity;
            result.Rate = state.Rate;
            result.RemainingCapacity = state.RemainingCapacity;
            state.Spare1.CopyTo(result.Spare1, 0);
            return result;
        }

        ulong IPowerManagmentCom.GetLastSleepTime()
        {
            return PowerManagmentLibrary.PowerManagment.GetLastSleepTime();
        }

        ulong IPowerManagmentCom.GetLastWakeTime()
        {
            return PowerManagmentLibrary.PowerManagment.GetLastWakeTime();
        }

        ISystemPowerInformation IPowerManagmentCom.GetPowerInformation()
        {
            var info = PowerManagmentLibrary.PowerManagment.GetPowerInformation();
            var result = (ISystemPowerInformation)(new SystemPowerInformationCom());
            result.CoolingMode = info.CoolingMode;
            result.Idleness = info.Idleness;
            result.MaxIdlenessAllowed = info.MaxIdlenessAllowed;
            result.TimeRemaining = info.TimeRemaining;
            return result;
        }

        void IPowerManagmentCom.RemoveHiberFile()
        {
            PowerManagmentLibrary.PowerManagment.RemoveHiberFile();
        }

        void IPowerManagmentCom.ReserveHiberFile()
        {
            PowerManagmentLibrary.PowerManagment.ReserveHiberFile();
        }

        bool IPowerManagmentCom.SetSuspendState(bool hibernate)
        {
            return PowerManagmentLibrary.PowerManagment.SetSuspendState(hibernate);
        }
    }
}
