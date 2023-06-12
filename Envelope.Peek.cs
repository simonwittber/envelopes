using System;
using UnityEngine;

namespace Dffrnt.Envelopes
{
    public partial class Envelope
    {

        public Int32 PeekInt32()
        {
            var ri = readIndex;
            var v = PopInt32();
            readIndex = ri;
            return v;
        }

        public UInt32 PeekUInt32()
        {
            var ri = readIndex;
            var v = PopUInt32();
            readIndex = ri;
            return v;
        }

        public Int64 PeekInt64()
        {
            var ri = readIndex;
            var v = PopInt64();
            readIndex = ri;
            return v;
        }

        public float PeekFloat()
        {
            var ri = readIndex;
            var v = PopFloat();
            readIndex = ri;
            return v;
        }

        public bool PeekBool()
        {
            var ri = readIndex;
            var v = PopBool();
            readIndex = ri;
            return v;
        }

        public byte PeekByte()
        {
            var ri = readIndex;
            var v = PopByte();
            readIndex = ri;
            return v;
        }

        public string PeekString()
        {
            var ri = readIndex;
            var v = PopString();
            readIndex = ri;
            return v;
        }

        public byte[] PeekByteArray()
        {
            var ri = readIndex;
            var v = PopByteArray();
            readIndex = ri;
            return v;
        }

        public Vector2 PeekVector2()
        {
            var ri = readIndex;
            var v = PopVector2();
            readIndex = ri;
            return v;
        }

        public Vector3 PeekVector3()
        {
            var ri = readIndex;
            var v = PopVector3();
            readIndex = ri;
            return v;
        }

        public Vector4 PeekVector4()
        {
            var ri = readIndex;
            var v = PopVector4();
            readIndex = ri;
            return v;
        }

        public Quaternion PeekQuaternion()
        {
            var ri = readIndex;
            var v = PopQuaternion();
            readIndex = ri;
            return v;
        }

        public Color PeekColor()
        {
            var ri = readIndex;
            var v = PopColor();
            readIndex = ri;
            return v;
        }


    }
}

