using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Blizzard.Storm
{
    public class StormFileStream : Stream
    {
        public StormFileStream(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(handle), $"{nameof(handle)} cannot be null/zero.");
            Handle = handle;

            Length = SFile.GetFileSizeLong(Handle);
        }

        public IntPtr Handle { get; }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get; }

        public override long Position {
            get => throw new NotSupportedException();
            set => Seek(value, SeekOrigin.Begin);
        }

        public override void Flush() { /* Do nothing? */ }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var pBuffer = Marshal.AllocHGlobal(count);
            SFile.ReadFile(Handle, pBuffer, count, out int read);
            Marshal.Copy(pBuffer, buffer, offset, count);
            return read;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return SFile.SetFilePointerLong(Handle, offset, origin);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                SFile.CloseFile(Handle);

            base.Dispose(disposing);
        }
    }
}
