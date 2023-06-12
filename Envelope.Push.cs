using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dffrnt.Envelopes
{
    public partial class Envelope
    {

        public void Push(string v)
        {
            WriteTypeCode(typeof(string));
            Write(v);
        }

        public void Push(byte v)
        {
            WriteTypeCode(typeof(byte));
            Write(v);
        }

        public void Push(Int32 v)
        {
            WriteTypeCode(typeof(Int32));
            Write(v);
        }

        public void Push(UInt32 v)
        {
            WriteTypeCode(typeof(UInt32));
            Write(v);
        }

        public void Push(Int64 v)
        {
            WriteTypeCode(typeof(Int64));
            Write(v);
        }

        public void Push(bool v)
        {
            WriteTypeCode(typeof(bool));
            Write(v);
        }

        public void Push(IList<byte> v)
        {
            Push(v, 0, v.Count);
        }

        public void Push(IList<byte> v, int offset, int length)
        {
            WriteTypeCode(typeof(IList<byte>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(float v)
        {
            WriteTypeCode(typeof(Single));
            Write(v);
        }

        public void Push(double v)
        {
            WriteTypeCode(typeof(double));
            Write(v);
        }

        public void Push(Envelope e)
        {
            WriteTypeCode(typeof(Envelope));
            Write(e);
        }

        public void Push(Vector2 v)
        {
            WriteTypeCode(typeof(Vector2));
            Write(v);
        }

        public void Push(Vector3 v)
        {
            WriteTypeCode(typeof(Vector3));
            Write(v);
        }

        public void Push(Vector4 v)
        {
            WriteTypeCode(typeof(Vector4));
            Write(v);
        }

        public void Push(Quaternion v)
        {
            WriteTypeCode(typeof(Quaternion));
            Write(v);
        }

        public void Push(Color v)
        {
            WriteTypeCode(typeof(Color));
            Write(v);
        }

        //-- Array Functions
        public void Push(IList<string> v)
        {
            WriteTypeCode(typeof(IList<string>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Int32> v)
        {
            WriteTypeCode(typeof(IList<Int32>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<UInt32> v)
        {
            WriteTypeCode(typeof(IList<UInt32>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Int64> v)
        {
            WriteTypeCode(typeof(IList<Int64>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<bool> v)
        {
            WriteTypeCode(typeof(IList<bool>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<float> v)
        {
            WriteTypeCode(typeof(IList<float>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<double> v)
        {
            WriteTypeCode(typeof(IList<double>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Envelope> v)
        {
            WriteTypeCode(typeof(IList<Envelope>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Vector2> v)
        {
            WriteTypeCode(typeof(IList<Vector2>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Vector3> v)
        {
            WriteTypeCode(typeof(IList<Vector3>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Vector4> v)
        {
            WriteTypeCode(typeof(IList<Vector4>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Quaternion> v)
        {
            WriteTypeCode(typeof(IList<Quaternion>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

        public void Push(IList<Color> v)
        {
            WriteTypeCode(typeof(IList<Color>));
            Write(v.Count);
            for (int i = 0, count = v.Count; i < count; i++) Write(v[i]);
        }

    }
}

