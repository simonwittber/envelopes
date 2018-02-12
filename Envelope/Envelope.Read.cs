using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DifferentMethods.Envelopes
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
        unsafe Int32 ReadInt32()
        {
            int v;
            fixed (byte* pbyte = &bytes[readIndex])
            {
                if (readIndex % 4 == 0)
                { // data is aligned 
                    v = *((int*)pbyte);
                }
                else
                {
                    if (BitConverter.IsLittleEndian)
                    {
                        v = (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
                    }
                    else
                    {
                        v = (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
                    }
                }
            }
            readIndex += 4;
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        UInt32 ReadUInt32()
        {
            return (UInt32)ReadInt32();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe float ReadFloat()
        {
            int v = ReadInt32();
            return *(float*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe double ReadDouble()
        {
            var v = ReadInt64();
            return *(double*)&v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe Int64 ReadInt64()
        {
            Int64 v;
            fixed (byte* pbyte = &bytes[readIndex])
            {
                if (readIndex % 8 == 0)
                { // data is aligned 
                    v = *((Int64*)pbyte);
                }
                else
                {
                    if (BitConverter.IsLittleEndian)
                    {
                        int i1 = (*pbyte) | (*(pbyte + 1) << 8) | (*(pbyte + 2) << 16) | (*(pbyte + 3) << 24);
                        int i2 = (*(pbyte + 4)) | (*(pbyte + 5) << 8) | (*(pbyte + 6) << 16) | (*(pbyte + 7) << 24);
                        v = (UInt32)i1 | ((Int64)i2 << 32);
                    }
                    else
                    {
                        int i1 = (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
                        int i2 = (*(pbyte + 4) << 24) | (*(pbyte + 5) << 16) | (*(pbyte + 6) << 8) | (*(pbyte + 7));
                        v = (UInt32)i2 | ((Int64)i1 << 32);
                    }
                }
            }
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