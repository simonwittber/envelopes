using System;
using System.Text;
using UnityEngine;

namespace Dffrnt.Envelopes
{
    public partial class Envelope
    {

        void CheckTypeCode(Type t)
        {
            if (bytes[readIndex] != typeCode[t])
            {
                throw new EnvelopeException("Type code mismatch, Found: " + (int)bytes[readIndex] + ", Wanted: " + (int)typeCode[t] + ". Bytes: " + ToString());
            }

            readIndex++;
        }


        string ReadString()
        {
            var isNotNull = ReadBool();
            if (isNotNull)
            {
                var length = ReadInt32();
                var s = Encoding.UTF8.GetString(Bytes, readIndex, length);
                readIndex += length;
                return s;
            }
            return null;
        }


        bool ReadBool()
        {
            return bytes[readIndex++] == 1;
        }


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


        UInt32 ReadUInt32()
        {
            return (UInt32)ReadInt32();
        }


        unsafe float ReadFloat()
        {
            int v = ReadInt32();
            return *(float*)&v;
        }


        unsafe double ReadDouble()
        {
            var v = ReadInt64();
            return *(double*)&v;
        }


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


        Vector2 ReadVector2()
        {
            return new Vector2(ReadFloat(), ReadFloat());
        }


        Vector3 ReadVector3()
        {
            return new Vector3(ReadFloat(), ReadFloat(), ReadFloat());
        }


        Vector4 ReadVector4()
        {
            return new Vector4(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }


        Quaternion ReadQuaternion()
        {
            return new Quaternion(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }


        Color ReadColor()
        {
            return new Color(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }


        Envelope ReadEnvelope()
        {
            var e = Take();
            var size = ReadInt32();
            e.CheckArraySize(size);
            for (var i = 0; i < size; i++)
                e.Bytes[i] = (byte)ReadByte();
            return e;
        }

    }
}