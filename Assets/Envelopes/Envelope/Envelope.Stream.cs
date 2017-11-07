using System;
using System.IO;

namespace Envelopes
{
    public partial class Envelope : Stream
    {

        public override long Length
        {
            get
            {
                return writeIndex;
            }
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override long Position
        {
            get
            {
                return writeIndex;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {

        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            for (var i = offset; i < offset + count; i++)
            {
                buffer[i - offset] = this.bytes[i];
            }
            return count;
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            CheckArraySize(count);
            Buffer.BlockCopy(buffer, offset, bytes, writeIndex, count);
            writeIndex += count;
        }

        public override int ReadByte()
        {
            return bytes[readIndex++];
        }

    }
}
