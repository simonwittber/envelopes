using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

namespace DifferentMethods.Envelopes
{
    public class EnvelopeTest
    {

        [Test]
        public void EnvelopeTestInt32()
        {
            var e = Envelope.Take();
            e.Push((Int32)1);
            var r = e.PopInt32();
            Assert.AreEqual(1, r);
        }

        [Test]
        public void EnvelopeTestInt32Array()
        {
            var e = Envelope.Take();
            var array = new Int32[] { 1, 2, 3, 4, 5 };
            e.Push(array);
            var r = e.PopInt32Array();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestInt32ArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new Int32[] { 1, 2, 3, 4, 5 };
            e.Push(array);
            var array2 = new Int32[5];
            e.PopInt32Array(array2);
            Assert.AreEqual(array, array2);
        }

        [Test]
        public void EnvelopeTestBool()
        {
            var e = Envelope.Take();
            e.Push(true);
            var r = e.PopBool();
            Assert.AreEqual(true, r);
        }

        [Test]
        public void EnvelopeTestBoolArray()
        {
            var e = Envelope.Take();
            var array = new bool[] { true, false, true };
            e.Push(array);
            var r = e.PopBoolArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestBoolArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new bool[] { true, false, true };
            e.Push(array);
            var r = new bool[3];
            e.PopBoolArray(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestFloat()
        {
            var e = Envelope.Take();
            e.Push(3.14f);
            var r = e.PopFloat();
            Assert.AreEqual(3.14f, r);
        }

        [Test]
        public void EnvelopeTestFloatArray()
        {
            var e = Envelope.Take();
            var array = new[] { 3.14f, 2.1f, 1f };
            e.Push(array);
            var r = e.PopFloatArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestFloatArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { 3.14f, 2.1f, 1f };
            e.Push(array);
            var r = new float[3];
            e.PopFloatArray(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestInt64()
        {
            var e = Envelope.Take();
            e.Push((Int64)1);
            var r = e.PopInt64();
            Assert.AreEqual(1, r);
        }

        [Test]
        public void EnvelopeTestInt64Array()
        {
            var e = Envelope.Take();
            var array = new Int64[] { 1, 2, 3, 4, 5 };
            e.Push(array);
            var r = e.PopInt64Array();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestInt64ArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new Int64[] { 1, 2, 3, 4, 5 };
            e.Push(array);
            var r = new Int64[5];
            e.PopInt64Array(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestDouble()
        {
            var e = Envelope.Take();
            e.Push(6.28);
            var r = e.PopDouble();
            Assert.AreEqual(6.28, r);
        }

        [Test]
        public void EnvelopeTestDoubleArray()
        {
            var e = Envelope.Take();
            var array = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            e.Push(array);
            var r = e.PopDoubleArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestDoubleArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            e.Push(array);
            var r = new double[5];
            e.PopDoubleArray(r);
            Assert.AreEqual(array, r);
        }


        [Test]
        public void EnvelopeTestVector2()
        {
            var e = Envelope.Take();
            var v = Vector2.one * 22f / 7f;
            e.Push(v);
            var r = e.PopVector2();
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestVector2Array()
        {
            var e = Envelope.Take();
            var array = new[] { Vector2.zero, Vector2.up, Vector2.down };
            e.Push(array);
            var r = e.PopVector2Array();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestVector2ArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { Vector2.zero, Vector2.up, Vector2.down };
            e.Push(array);
            var r = new Vector2[3];
            e.PopVector2Array(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestVector3()
        {
            var e = Envelope.Take();
            var v = Vector3.one * 22f / 7f;
            e.Push(v);
            var r = e.PopVector3();
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestVector3Array()
        {
            var e = Envelope.Take();
            var array = new[] { Vector3.zero, Vector3.up, Vector3.down };
            e.Push(array);
            var r = e.PopVector3Array();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestVector3ArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { Vector3.zero, Vector3.up, Vector3.down };
            e.Push(array);
            var r = new Vector3[3];
            e.PopVector3Array(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestVector4()
        {
            var e = Envelope.Take();
            var v = Vector4.one * 22f / 7f;
            e.Push(v);
            var r = e.PopVector4();
            Assert.IsInstanceOf(typeof(Vector4), r);
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestVector4Array()
        {
            var e = Envelope.Take();
            var array = new[] { Vector4.zero, Vector4.one };
            e.Push(array);
            var r = e.PopVector4Array();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestVector4ArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { Vector4.zero, Vector4.one };
            e.Push(array);
            var r = new Vector4[2];
            e.PopVector4Array(r);
            Assert.AreEqual(array, r);
        }


        [Test]
        public void EnvelopeTestQuaternion()
        {
            var e = Envelope.Take();
            var v = Quaternion.identity;
            e.Push(v);
            var r = e.PopQuaternion();
            Assert.IsInstanceOf(typeof(Quaternion), r);
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestQuaternionArray()
        {
            var e = Envelope.Take();
            var array = new[] { Quaternion.identity, Quaternion.identity };
            e.Push(array);
            var r = e.PopQuaternionArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestQuaternionArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { Quaternion.identity, Quaternion.identity };
            e.Push(array);
            var r = new Quaternion[2];
            e.PopQuaternionArray(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestColor()
        {
            var e = Envelope.Take();
            var v = Color.blue;
            e.Push(v);
            var r = e.PopColor();
            Assert.IsInstanceOf(typeof(Color), r);
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestColorArray()
        {
            var e = Envelope.Take();
            var array = new[] { Color.blue, Color.red, Color.magenta };
            e.Push(array);
            var r = e.PopColorArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestColorArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { Color.blue, Color.red, Color.magenta };
            e.Push(array);
            var r = new Color[3];
            e.PopColorArray(r);
            Assert.AreEqual(array, r);
        }


        [Test]
        public void EnvelopeTestString()
        {
            var e = Envelope.Take();
            var v = "xyzzy.";
            e.Push(v);
            var r = e.PopString();
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestStringArray()
        {
            var e = Envelope.Take();
            var array = new[] { "plugh.", "nothing happens." };
            e.Push(array);
            var r = e.PopStringArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestStringArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { "plugh.", "nothing happens." };
            e.Push(array);
            var r = new string[2];
            e.PopStringArray(r);
            Assert.AreEqual(array, r);
        }


        [Test]
        public void EnvelopeTestByte()
        {
            var e = Envelope.Take();
            var v = (byte)128;
            e.Push(v);
            var r = e.PopByte();
            Assert.AreEqual(v, r);
        }

        [Test]
        public void EnvelopeTestByteArray()
        {
            var e = Envelope.Take();
            var array = new[] { (byte)128, (byte)64, (byte)32 };
            e.Push(array);
            var r = e.PopByteArray();
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestByteArrayAlloc()
        {
            var e = Envelope.Take();
            var array = new[] { (byte)128, (byte)64, (byte)32 };
            e.Push(array);
            var r = new byte[3];
            e.PopByteArray(r);
            Assert.AreEqual(array, r);
        }

        [Test]
        public void EnvelopeTestEnvelope()
        {
            var e = Envelope.Take();
            var v = Envelope.Take();
            v.Push(1979);
            v.Push(3.14);
            v.Push("Xyzzy");
            e.Push(v);
            var r = e.PopEnvelope();
            Assert.AreEqual(1979, r.PopInt32());
            Assert.AreEqual(3.14, r.PopDouble());
            Assert.AreEqual("Xyzzy", r.PopString());
        }

    }
}