using System.Runtime.InteropServices;

namespace KeyGenerator
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Int24Converter
    {
        [FieldOffset(0)] public uint UIntValue;
        [FieldOffset(0)] public byte Byte0;
        [FieldOffset(1)] public byte Byte1;
        [FieldOffset(2)] public byte Byte2;
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct Int36Converter
    {
        [FieldOffset(0)] public long LongValue;
        [FieldOffset(0)] public byte Byte0;
        [FieldOffset(1)] public byte Byte1;
        [FieldOffset(2)] public byte Byte2;
        [FieldOffset(3)] public byte Byte3;
        [FieldOffset(4)] public byte Byte4;
    }
}
