using LibHac;
using LibHac.Fs;
using System;

namespace XbTool.Xb2
{
    public class ArchiveFile : FileBase
    {
        private IStorage BaseStorage { get; }
        private long Offset { get; }
        private long Size { get; }

        private bool IsCompressed { get; set; }
        private byte[] FileData { get; set; }

        public ArchiveFile(byte[] file, OpenMode mode)
        {
            FileData = file;
            IsCompressed = true;
            Size = file.Length;
        }

        public ArchiveFile(IStorage baseStorage, long offset, long size)
        {
            BaseStorage = baseStorage;
            Offset = offset;
            Size = size;
        }

        protected override Result ReadImpl(out long bytesRead, long offset, Span<byte> destination, ReadOption options)
        {
            Result res = ValidateReadParams(out bytesRead, offset, destination.Length, OpenMode.Read);
            if (res.IsFailure())
                return res;

            if (IsCompressed)
            {
                FileData.AsSpan((int)offset, (int)bytesRead).CopyTo(destination);
                res = Result.Success;
            }
            else
            {
                long storageOffset = Offset + offset;
                res = BaseStorage.Read(storageOffset, destination.Slice(0, (int)bytesRead));
            }

            return res;
        }

        protected override Result WriteImpl(long offset, ReadOnlySpan<byte> source, WriteOption options) => throw new NotSupportedException();
        protected override Result FlushImpl() => Result.Success;
        protected override Result SetSizeImpl(long size) => throw new NotSupportedException();
        protected override Result GetSizeImpl(out long size)
        {
            size = Size;
            return Result.Success;
        }
    }
}
