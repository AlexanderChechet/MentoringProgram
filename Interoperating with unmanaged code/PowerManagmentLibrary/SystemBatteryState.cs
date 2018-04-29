using System;
using System.Runtime.InteropServices;

namespace PowerManagmentLibrary
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SYSTEM_BATTERY_STATE {
        [FieldOffset(0)]
        public bool AcOnLine;
        [FieldOffset(1)]
        public bool BatteryPresent;
        [FieldOffset(2)]
        public bool Charging;
        [FieldOffset(3)]
        public bool Discharging;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Bool, SizeConst = 4)]
        [FieldOffset(4)]
        public bool[] Spare1;
        [FieldOffset(8)]
        public ushort MaxCapacity;
        [FieldOffset(10)]
        public ushort RemainingCapacity;
        [FieldOffset(12)]
        public ushort Rate;
        [FieldOffset(14)]
        public ushort EstimatedTime;
        [FieldOffset(16)]
        public ushort DefaultAlert1;
        [FieldOffset(18)]
        public ushort DefaultAlert2;
    }
}
