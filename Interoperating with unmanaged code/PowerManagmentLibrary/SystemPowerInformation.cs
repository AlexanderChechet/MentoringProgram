using System.Runtime.InteropServices;

namespace PowerManagmentLibrary
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SYSTEM_POWER_INFORMATION {
        [FieldOffset(0)]
        public byte CoolingMode;
        [FieldOffset(4)]
        public uint Idleness;
        [FieldOffset(8)]
        public uint TimeRemaining;
        [FieldOffset(12)]
        public uint MaxIdlenessAllowed;
    }
}
