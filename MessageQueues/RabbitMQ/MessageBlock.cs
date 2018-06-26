using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQHelper
{
    public struct MessageBlock
    {
        public Guid MessageId;
        public int Blocks;
        public int Index;
        public int BlockSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] Data;
    }

    public static class MessageBlockExtension
    {
        public static byte[] ToBytes(this MessageBlock block)
        {
            int size = Marshal.SizeOf(block);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(block, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            return bytes;
        }

        public static MessageBlock FromBytes(this byte[] bytes)
        {
            MessageBlock block = new MessageBlock();

            int size = Marshal.SizeOf(block);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(bytes, 0, ptr, size);

            block = (MessageBlock)Marshal.PtrToStructure(ptr, block.GetType());
            Marshal.FreeHGlobal(ptr);

            return block;
        }
    }
}
