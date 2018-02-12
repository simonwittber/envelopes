using System.Collections;
using System.Collections.Generic;
using DifferentMethods.Envelopes;
using UnityEngine;
using UnityEngine.Assertions;

public class GarbageTest : MonoBehaviour
{
    Vector3[] array = new[] { Vector3.one, Vector3.left };
    void Update()
    {
        var e = Envelope.Take();
        var v = Envelope.Take();
        v.Push(1979);
        v.Push(3.14);
        //strings always alloc due to encoding/decoding
        //v.Push("Xyzzy");
        v.Push(Vector3.one);
        v.Push(long.MaxValue);
        v.Push(array);
        e.Push(v);
        e.Push(true);
        var r = e.PopEnvelope();
        e.PopBool();
        r.PopInt32();
        r.PopDouble();
        //r.PopString();
        r.PopVector3();
        r.PopInt64();
        r.PopVector3Array(array);
        Envelope.Return(r);
        Envelope.Return(e);
        Envelope.Return(v);

    }

}

