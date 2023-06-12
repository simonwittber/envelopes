using System;
using System.Text;
using UnityEngine;

namespace Dffrnt.Envelopes
{
    public partial class Envelope
    {
        void CheckArraySize(int allocate)
        {
            if (writeIndex + allocate > bytes.Length)
            {
                var newSize = (bytes.Length + allocate) + (int) ((bytes.Length + allocate) * 0.25f);
                Array.Resize(ref bytes, newSize);
            }
        }

        void WriteTypeCode(Type t) => Write(typeCode[t]);

        void Write(byte v)
        {
            CheckArraySize(1);
            bytes[writeIndex++] = v;
        }

        void Write(string v)
        {
            if (v == null)
                Write(false);
            else
            {
                Write(true);
                var sz = Encoding.UTF8.GetBytes(v);
                Write(sz.Length);
                Write(sz);
            }
        }

        void Write(byte[] v)
        {
            CheckArraySize(v.Length);
            Buffer.BlockCopy(v, 0, bytes, writeIndex, v.Length);
            writeIndex += v.Length;
        }

        void Write(float f)
        {
            Write(GetBytes(f));
        }

        void Write(double f)
        {
            Write(GetBytes(f));
        }

        void Write(Int32 f)
        {
            Write(GetBytes(f));
        }

        void Write(UInt32 f)
        {
            Write(GetBytes(f));
        }

        void Write(Int64 f)
        {
            Write(GetBytes(f));
        }

        void Write(Envelope e)
        {
            Write((int) e.Length);
            Write(e.Bytes, 0, (int) e.Length);
        }

        void Write(bool v)
        {
            Write(v ? (byte) 1 : (byte) 0);
        }

        void Write(Vector2 v)
        {
            Write(v.x);
            Write(v.y);
        }

        void Write(Vector3 v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
        }

        void Write(Vector4 v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
            Write(v.w);
        }

        void Write(Quaternion v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
            Write(v.w);
        }

        void Write(Color v)
        {
            Write(v.r);
            Write(v.g);
            Write(v.b);
            Write(v.a);
        }

        static unsafe byte[] GetBytes(int value)
        {
            fixed (byte* b = bytes4) *((int*) b) = value;
            return bytes4;
        }

        static unsafe byte[] GetBytes(long value)
        {
            fixed (byte* b = bytes8) *((long*) b) = value;
            return bytes8;
        }

        static byte[] GetBytes(uint value)
        {
            return GetBytes((int) value);
        }

        static unsafe byte[] GetBytes(float value)
        {
            return GetBytes(*(int*) &value);
        }

        static unsafe byte[] GetBytes(double value)
        {
            return GetBytes(*(long*) &value);
        }

        [ThreadStatic] static byte[] bytes4 = new byte[4];
        [ThreadStatic] static byte[] bytes8 = new byte[8];
    }
}