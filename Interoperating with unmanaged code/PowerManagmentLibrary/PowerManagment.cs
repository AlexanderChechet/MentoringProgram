using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentLibrary
{
    public class PowerManagment
    {
        [DllImport("PowrProf.dll")]
        private static extern uint CallNtPowerInformation(int level, IntPtr inputBuffer, uint inputBufferSize, IntPtr outputBuffer, uint outputBufferSize);
        [DllImport("PowrProf.dll")]
        private static extern bool SetSuspendState(bool Hibernate, bool forceCritical, bool disableWakeEvent);

        public static ulong GetLastSleepTime()
        {
            int size = Marshal.SizeOf(typeof(ulong));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            var status = CallNtPowerInformation((int)PowerInformationLevel.LastSleepTime, IntPtr.Zero, (uint)0, ptr, (uint)8);
            if (status == 0)
            {
                return Marshal.PtrToStructure<ulong>(ptr);
            }
            throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static ulong GetLastWakeTime()
        {
            int size = Marshal.SizeOf(typeof(ulong));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            var status = CallNtPowerInformation((int)PowerInformationLevel.LastWakeTime, IntPtr.Zero, (uint)0, ptr, (uint)8);
            if (status == 0)
            {
                return Marshal.PtrToStructure<ulong>(ptr);
            }
            throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static SYSTEM_POWER_INFORMATION GetPowerInformation()
        {
            int size = Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            var status = CallNtPowerInformation((int)PowerInformationLevel.SystemPowerInformation, IntPtr.Zero, (uint)0, ptr, (uint)size);
            if (status == 0)
            {
                var info = Marshal.PtrToStructure<SYSTEM_POWER_INFORMATION>(ptr);
                return info;
            }
            throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static SYSTEM_BATTERY_STATE GetBatteryState()
        {
            int size = Marshal.SizeOf(typeof(SYSTEM_BATTERY_STATE));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            var status = CallNtPowerInformation((int)PowerInformationLevel.SystemPowerInformation, IntPtr.Zero, (uint)0, ptr, (uint)size);
            if (status == 0)
            {
                var state = Marshal.PtrToStructure<SYSTEM_BATTERY_STATE>(ptr);
                return state;
            }
            throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static void ReserveHiberFile()
        {
            int size = Marshal.SizeOf(typeof(Boolean));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr<Boolean>(true, ptr, true);
            var status = CallNtPowerInformation((int)PowerInformationLevel.SystemReserveHiberFile, ptr, (uint)size, IntPtr.Zero, (uint)0);
            if (status != 0)
                throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static void RemoveHiberFile()
        {
            int size = Marshal.SizeOf(typeof(Boolean));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr<Boolean>(false, ptr, true);
            var status = CallNtPowerInformation((int)PowerInformationLevel.SystemReserveHiberFile, ptr, (uint)size, IntPtr.Zero, (uint)0);
            if (status != 0)
                throw new Exception($"Error in function call. Status code = {status:X}");
        }

        public static bool SetSuspendState(bool hibernate)
        {
            return SetSuspendState(hibernate, false, false);
        }
    }
}
