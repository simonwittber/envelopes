using System;
using System.Collections.Generic;
using UnityEngine;

namespace Envelopes
{
    public partial class Envelope
    {
        public byte PopByte()
        {
            CheckTypeCode(typeof(byte));
            return (byte)ReadByte();
        }

        public string PopString()
        {
            CheckTypeCode(typeof(string));
            return ReadString();
        }

        public Int32 PopInt32()
        {
            CheckTypeCode(typeof(Int32));
            return ReadInt32();
        }

        public UInt32 PopUInt32()
        {
            CheckTypeCode(typeof(UInt32));
            return ReadUInt32();
        }

        public Int64 PopInt64()
        {
            CheckTypeCode(typeof(Int64));
            return ReadInt64();
        }

        public float PopFloat()
        {
            CheckTypeCode(typeof(Single));
            return ReadFloat();
        }

        public double PopDouble()
        {
            CheckTypeCode(typeof(double));
            return ReadDouble();
        }

        public bool PopBool()
        {
            CheckTypeCode(typeof(bool));
            return ReadBool();
        }

        public byte[] PopByteArray()
        {
            CheckTypeCode(typeof(IList<byte>));
            var a = new byte[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = (byte)ReadByte();
            return a;
        }

        public Envelope PopEnvelope()
        {
            CheckTypeCode(typeof(Envelope));
            return ReadEnvelope();
        }

        public Vector2 PopVector2()
        {
            CheckTypeCode(typeof(Vector2));
            return ReadVector2();
        }

        public Vector3 PopVector3()
        {
            CheckTypeCode(typeof(Vector3));
            return ReadVector3();
        }

        public Vector4 PopVector4()
        {
            CheckTypeCode(typeof(Vector4));
            return ReadVector4();
        }

        public Quaternion PopQuaternion()
        {
            CheckTypeCode(typeof(Quaternion));
            return ReadQuaternion();
        }

        public Color PopColor()
        {
            CheckTypeCode(typeof(Color));
            return ReadColor();
        }

        public bool[] PopBoolArray()
        {
            CheckTypeCode(typeof(IList<bool>));
            var a = new bool[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadBool();
            return a;
        }

        public Int32[] PopInt32Array()
        {
            CheckTypeCode(typeof(IList<Int32>));
            var a = new Int32[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadInt32();
            return a;
        }

        public UInt32[] PopUInt32Array()
        {
            CheckTypeCode(typeof(IList<UInt32>));
            var a = new UInt32[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadUInt32();
            return a;
        }

        public float[] PopFloatArray()
        {
            CheckTypeCode(typeof(IList<float>));
            var a = new float[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadFloat();
            return a;
        }

        public double[] PopDoubleArray()
        {
            CheckTypeCode(typeof(IList<double>));
            var a = new double[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadDouble();
            return a;
        }

        public Int64[] PopInt64Array()
        {
            CheckTypeCode(typeof(IList<Int64>));
            var a = new Int64[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadInt64();
            return a;
        }

        public Color[] PopColorArray()
        {
            CheckTypeCode(typeof(IList<Color>));
            var a = new Color[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadColor();
            return a;
        }

        public Vector2[] PopVector2Array()
        {
            CheckTypeCode(typeof(IList<Vector2>));
            var a = new Vector2[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector2();
            return a;
        }

        public Vector3[] PopVector3Array()
        {
            CheckTypeCode(typeof(IList<Vector3>));
            var a = new Vector3[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector3();
            return a;
        }

        public Vector4[] PopVector4Array()
        {
            CheckTypeCode(typeof(IList<Vector4>));
            var a = new Vector4[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector4();
            return a;
        }

        public Quaternion[] PopQuaternionArray()
        {
            CheckTypeCode(typeof(IList<Quaternion>));
            var a = new Quaternion[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadQuaternion();
            return a;
        }

        public string[] PopStringArray()
        {
            CheckTypeCode(typeof(IList<string>));
            var a = new string[ReadInt32()];
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadString();
            return a;
        }


        public void PopBoolArray(bool[] a)
        {
            CheckTypeCode(typeof(IList<bool>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadBool();
        }

        public void PopInt32Array(Int32[] a)
        {
            CheckTypeCode(typeof(IList<Int32>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadInt32();
        }

        public void PopUInt32Array(UInt32[] a)
        {
            CheckTypeCode(typeof(IList<UInt32>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadUInt32();
        }

        public void PopFloatArray(float[] a)
        {
            CheckTypeCode(typeof(IList<float>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadFloat();
        }

        public void PopDoubleArray(double[] a)
        {
            CheckTypeCode(typeof(IList<double>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadDouble();
        }

        public void PopInt64Array(Int64[] a)
        {
            CheckTypeCode(typeof(IList<Int64>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadInt64();
        }

        public void PopColorArray(Color[] a)
        {
            CheckTypeCode(typeof(IList<Color>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadColor();
        }

        public void PopVector2Array(Vector2[] a)
        {
            CheckTypeCode(typeof(IList<Vector2>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector2();
        }

        public void PopVector3Array(Vector3[] a)
        {
            CheckTypeCode(typeof(IList<Vector3>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector3();
        }

        public void PopVector4Array(Vector4[] a)
        {
            CheckTypeCode(typeof(IList<Vector4>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadVector4();
        }

        public void PopQuaternionArray(Quaternion[] a)
        {
            CheckTypeCode(typeof(IList<Quaternion>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadQuaternion();
        }

        public void PopStringArray(string[] a)
        {
            CheckTypeCode(typeof(IList<string>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = ReadString();
        }

        public void PopByteArray(byte[] a)
        {
            CheckTypeCode(typeof(IList<byte>));
            var size = ReadInt32();
            if (size > a.Length) throw new IndexOutOfRangeException("Array size is too small.");
            for (var i = 0; i < a.Length; i++)
                a[i] = (byte)ReadByte();
        }


    }
}

