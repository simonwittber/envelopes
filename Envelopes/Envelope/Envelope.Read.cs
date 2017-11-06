using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Envelopes
{
    public partial class Envelope
    {

        void CheckTypeCode(Type t)
        {
            if (bytes[readIndex] != typeCode[t])
            {
                throw new EnvelopeException("Type code mismatch, Found: " + (int)bytes[readIndex] + ", Wanted: " + (int)typeCode[t] + ". Bytes: " + this.ToString());
            }
            else
            {
                readIndex++;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        string ReadString()
        {
            var isNotNull = ReadBool();
            if (isNotNull)
            {
                var length = ReadInt32();
                var s = System.Text.UTF8Encoding.UTF8.GetString(this.Bytes, readIndex, length);
                readIndex += length;
                return s;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool ReadBool()
        {
            return this.bytes[readIndex++] == (byte)1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Int32 ReadInt32()
        {
            var v = System.BitConverter.ToInt32(this.bytes, readIndex);
            readIndex += 4;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        UInt32 ReadUInt32()
        {
            var v = System.BitConverter.ToUInt32(this.bytes, readIndex);
            readIndex += 4;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        float ReadFloat()
        {
            var v = System.BitConverter.ToSingle(this.bytes, readIndex);
            readIndex += 4;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        double ReadDouble()
        {
            var v = System.BitConverter.ToDouble(this.bytes, readIndex);
            readIndex += 8;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Int64 ReadInt64()
        {
            var v = System.BitConverter.ToInt64(this.bytes, readIndex);
            readIndex += 8;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Vector2 ReadVector2()
        {
            return new Vector2(ReadFloat(), ReadFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Vector3 ReadVector3()
        {
            return new Vector3(ReadFloat(), ReadFloat(), ReadFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Vector4 ReadVector4()
        {
            return new Vector4(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Quaternion ReadQuaternion()
        {
            return new Quaternion(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Color ReadColor()
        {
            return new Color(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Envelope ReadEnvelope()
        {
            var e = Envelope.Take();
            var size = ReadInt32();
            e.CheckArraySize(size);
            for (var i = 0; i < size; i++)
                e.Bytes[i] = (byte)ReadByte();
            return e;
        }

    }
}