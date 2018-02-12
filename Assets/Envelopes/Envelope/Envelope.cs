using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentMethods.Envelopes
{
    public class EnvelopePool
    {

    }
    public partial class Envelope : IDisposable
    {

        public const int MAX_MSG_SIZE = 1024;

        static Stack<Envelope> pool = new Stack<Envelope>();

        Dictionary<Type, byte> typeCode = new Dictionary<Type, byte>()
        {
            {typeof(int), (byte)'i'},
            {typeof(float), (byte)'f'},
            {typeof(long), (byte)'g'},
            {typeof(double), (byte)'d'},
            {typeof(bool), (byte)'t'},
            {typeof(byte), (byte)'b'},
            {typeof(string), (byte)'s'},
            {typeof(Envelope), (byte)'e'},

            {typeof(IList<int>), (byte)'I'},
            {typeof(IList<float>), (byte)'F'},
            {typeof(IList<long>), (byte)'G'},
            {typeof(IList<double>), (byte)'D'},
            {typeof(IList<bool>), (byte)'T'},
            {typeof(IList<byte>), (byte)'B'},
            {typeof(IList<string>), (byte)'S'},
            {typeof(IList<Envelope>), (byte)'E'},

            {typeof(Vector2), (byte)'1'},
            {typeof(Vector3), (byte)'2'},
            {typeof(Vector4), (byte)'3'},
            {typeof(Quaternion), (byte)'4'},
            {typeof(Color), (byte)'5'},

            {typeof(IList<Vector2>), (byte)'6'},
            {typeof(IList<Vector3>), (byte)'7'},
            {typeof(IList<Vector4>), (byte)'8'},
            {typeof(IList<Quaternion>), (byte)'9'},
            {typeof(IList<Color>), (byte)'0'},
        };

        public static int InUse { get; private set; }

        public static int PoolSize
        {
            get
            {
                return pool.Count;
            }
        }

        public static Envelope Take()
        {
            lock (pool)
            {
                InUse++;
                var msg = pool.Count > 0 ? pool.Pop() : new Envelope();
                msg.readIndex = msg.writeIndex = 0;
                msg.inPool = false;
                return msg;
            }
        }

        public static void Return(Envelope msg)
        {
            lock (pool)
            {
                if (msg.inPool) throw new Exception("Msg in pool already!");
                msg.inPool = true;
                InUse--;
                pool.Push(msg);
            }
        }

        public new void Dispose()
        {
            Envelope.Return(this);
        }

        public Envelope Clone()
        {
            var e = Envelope.Take();
            e.Write(bytes, 0, (int)Length);
            e.readIndex = 0;
            e.writeIndex = writeIndex;
            return e;
        }

        public void Clear()
        {
            readIndex = writeIndex = 0;
        }

        public byte[] Bytes
        {
            get
            {
                return bytes;
            }
        }

        public byte[] ToArray()
        {
            var a = new byte[Length];
            System.Array.Copy(bytes, a, Length);
            return a;
        }

        public int Available
        {
            get
            {
                return bytes.Length - writeIndex;
            }
        }

        public override string ToString()
        {
            var s = string.Format("Envelope({0} bytes) ", Length); ;
            for (var i = 0; i < Length; i++)
            {
                var b = bytes[i];

                s += (b >= 32 && b <= 126 ? ((char)b).ToString() : String.Format(@"\u{0:x4}", b));
            }
            return s;
        }

        bool inPool = false;
        int readIndex, writeIndex;
        byte[] bytes = new byte[MAX_MSG_SIZE];
    }
}

