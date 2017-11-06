using System;

namespace Envelopes
{
    public partial class Envelope
    {

        public Int32 PeekInt32()
        {
            var ri = readIndex;
            var v = System.BitConverter.ToInt32(this.bytes, readIndex);
            readIndex = ri;
            return v;
        }

        public UInt32 PeekUInt32()
        {
            var v = System.BitConverter.ToUInt32(this.bytes, readIndex);
            return v;
        }

        public Int64 PeekInt64()
        {
            var ri = readIndex;
            var v = System.BitConverter.ToInt64(this.bytes, readIndex);
            readIndex = ri;
            return v;
        }

        public float PeekFloat()
        {
            var ri = readIndex;
            var v = System.BitConverter.ToSingle(this.bytes, readIndex);
            readIndex = ri;
            return v;
        }

        public bool PeekBool()
        {
            var ri = readIndex;
            var v = bytes[readIndex] == (byte)1;
            readIndex = ri;
            return v;
        }

        public byte PeekByte()
        {
            var ri = readIndex;
            var v = bytes[readIndex];
            readIndex = ri;
            return v;
        }

        public string PeekString()
        {
            var ri = readIndex;
            var notNull = PopBool();
            string value = null;
            if (notNull)
                value = System.Text.Encoding.UTF8.GetString(PopByteArray());
            readIndex = ri;
            return value;
        }

        public byte[] PeekBytes()
        {
            var ri = readIndex;
            byte[] sbytes = null;
            var notNull = PopBool();
            if (notNull)
                sbytes = PopByteArray();
            readIndex = ri;
            return sbytes;
        }


    }
}

