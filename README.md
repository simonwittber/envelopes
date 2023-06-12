Envelopes
=========

```git submodule add https://github.com/simonwittber/envelopes Envelopes```

Envelopes is a Garbage free library for serializing primitive types into
a byte array.

Envelope instances use pre-allocate fixed size buffers wherever possible
to ensure zero per-frame allocations. However, if an envelope does need
to grow the internal buffer to accomadate more Push calls, it will.

To avoid contructor allocation, Envelope instances are pooled. To get
a new instance, use Envelope.Take(). When finished with the instance, use
Envelope.Return(Envelope instance);

Envelopes work like a queue. Call Envelope.Push to push primitive types
into the envelope, then Envelope.Pop(Int32,Float,FloatArray etc) to 
retrieve the types from the envelope. Minimal type information is stored in
the envelope to aid debugging.

The .Bytes property and the .Length property are used to perform work with
the serialized data, such as persisting or sending over a network.


Why not Protobuf/JSON/...
=========================
Envelopes are concerned with serialization of data for transport. They are
simple and rapid, no need for a tutorial, or model definition or separate
compile step. Envelopes do this without memory allocation or reflection,
which are important on constrained devices and video games. For example:

```csharp
var e = Envelope.Take()
e.Push("Simon Wittber")
e.Push(1979)
e.Push(new[] { 123123123, 456456456, 789789789 });
WriteToSocket(e.Bytes, e.Length);
Envelope.Return(e);
```

and on the opposite end:

```csharp
var e = Envelope.Take();
ReadFromSocket(e.Bytes, 0, e.MAX_ENVELOPE_SIZE);
var name = e.PopString();
var year = e.PopInt32();
var phoneNumbers = e.PopInt64Array()
Envelope.Return(e);
```

All this happens with minimal buffer copies, and zero allocation (except for
strings of course!).


License
=======
Copyright 2017 Simon Wittber <simonwittber@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy 
of this software and associated documentation files (the "Software"), to deal 
in the Software without restriction, including without limitation the rights 
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
copies of the Software, and to permit persons to whom the Software is 
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
SOFTWARE.
