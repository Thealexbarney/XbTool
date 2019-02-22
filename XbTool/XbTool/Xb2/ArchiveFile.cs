using System;
using LibHac.IO;

namespace XbTool.Xb2
{
    public class ArchiveFile : FileBase
    {
        private IStorage BaseStorage { get; }
        private long Offset { get; }
        private long Size { get; }

        private bool IsCompressed { get; set; }
        private byte[] FileData { get; set; }

        public ArchiveFile(byte[] file)
        {
            FileData = file;
            IsCompressed = true;
            Size = file.Length;
        }

        public ArchiveFile(IStorage baseStorage, long offset, long size)
        {
            Mode = OpenMode.Read;
            BaseStorage = baseStorage;
            Offset = offset;
            Size = size;
        }

        public override int Read(Span<byte> destination, long offset)
        {
            int toRead = ValidateReadParamsAndGetSize(destination, offset);

            if (IsCompressed)
            {
                FileData.CopyTo(destination.Slice((int)offset, toRead));
            }
            else
            {
                long storageOffset = Offset + offset;
                BaseStorage.Read(destination.Slice(0, toRead), storageOffset);
            }

            return toRead;
        }

        public override long GetSize() => Size;

        public override void Write(ReadOnlySpan<byte> source, long offset) => throw new NotSupportedException();
        public override void Flush() => throw new NotSupportedException();
        public override void SetSize(long size) => throw new NotSupportedException();
    }
}
