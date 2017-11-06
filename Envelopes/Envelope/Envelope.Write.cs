using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Envelopes
{

    public partial class Envelope
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void CheckArraySize(int allocate)
        {
            if (writeIndex + allocate > bytes.Length)
            {
                var newSize = (bytes.Length + allocate) + (int)((bytes.Length + allocate) * 0.25f);
                System.Array.Resize(ref bytes, newSize);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void WriteTypeCode(Type t)
        {
            Write(typeCode[t]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(byte v)
        {
            CheckArraySize(1);
            bytes[writeIndex++] = v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(string v)
        {
            if (v == null)
                Write(false);
            else
            {
                Write(true);
                var sz = System.Text.Encoding.UTF8.GetBytes(v);
                Write(sz.Length);
                Write(sz);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(byte[] v)
        {
            CheckArraySize(v.Length);
            Buffer.BlockCopy(v, 0, bytes, writeIndex, v.Length);
            writeIndex += v.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(float f)
        {
            Write(GetBytes(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(double f)
        {
            Write(GetBytes(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Int32 f)
        {
            Write(GetBytes(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(UInt32 f)
        {
            Write(GetBytes(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Int64 f)
        {
            Write(GetBytes(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Envelope e)
        {
            Write((int)e.Length);
            Write(e.Bytes, 0, (int)e.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(bool v)
        {
            Write(v ? (byte)1 : (byte)0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Vector2 v)
        {
            Write(v.x);
            Write(v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Vector3 v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Vector4 v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
            Write(v.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Quaternion v)
        {
            Write(v.x);
            Write(v.y);
            Write(v.z);
            Write(v.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Write(Color v)
        {
            Write(v.r);
            Write(v.g);
            Write(v.b);
            Write(v.a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe static byte[] GetBytes(int value)
        {
            fixed (byte* b = bytes4)
                *((int*)b) = value;
            return bytes4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe static byte[] GetBytes(long value)
        {

            fixed (byte* b = bytes8)
                *((long*)b) = value;
            return bytes8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static byte[] GetBytes(uint value)
        {

            return GetBytes((int)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe static byte[] GetBytes(float value)
        {
            return GetBytes(*(int*)&value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe static byte[] GetBytes(double value)
        {
            return GetBytes(*(long*)&value);
        }

        [ThreadStatic] static byte[] bytes4 = new byte[4];
        [ThreadStatic] static byte[] bytes8 = new byte[8];

    }
}