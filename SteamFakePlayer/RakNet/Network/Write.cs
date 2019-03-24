using System;
using System.IO;
using System.Text;
using Network;
using UnityEngine;

namespace RakNet.Network
{
    public abstract class Write : Stream
    {
        // Token: 0x0400004E RID: 78
        private readonly MemoryStream _buffer = new MemoryStream();

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000076 RID: 118 RVA: 0x0000274B File Offset: 0x0000094B
        public override bool CanRead => true;

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000077 RID: 119 RVA: 0x00002C18 File Offset: 0x00000E18
        public override bool CanSeek => false;

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000078 RID: 120 RVA: 0x00002C18 File Offset: 0x00000E18
        public override bool CanWrite => false;

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x06000079 RID: 121 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override long Length => throw new NotImplementedException();

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x0600007A RID: 122 RVA: 0x00002C1B File Offset: 0x00000E1B
        // (set) Token: 0x0600007B RID: 123 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        // Token: 0x0600005F RID: 95
        public abstract bool Start();

        // Token: 0x06000060 RID: 96
        public abstract void Send(SendInfo info);

        // Token: 0x06000061 RID: 97
        public abstract void PacketId(Message.Type val);

        // Token: 0x06000062 RID: 98
        public abstract void UInt8(byte val);

        // Token: 0x06000063 RID: 99
        public abstract void UInt16(ushort val);

        // Token: 0x06000064 RID: 100
        public abstract void UInt32(uint val);

        // Token: 0x06000065 RID: 101
        public abstract void UInt64(ulong val);

        // Token: 0x06000066 RID: 102
        public abstract void Int8(sbyte val);

        // Token: 0x06000067 RID: 103
        public abstract void Int16(short val);

        // Token: 0x06000068 RID: 104
        public abstract void Int32(int val);

        // Token: 0x06000069 RID: 105
        public abstract void Int64(long val);

        // Token: 0x0600006A RID: 106
        public abstract void Bool(bool val);

        // Token: 0x0600006B RID: 107
        public abstract void Float(float val);

        // Token: 0x0600006C RID: 108
        public abstract void Double(double val);

        // Token: 0x0600006D RID: 109
        public abstract void Bytes(byte[] val);

        // Token: 0x0600006E RID: 110 RVA: 0x00002A44 File Offset: 0x00000C44
        public void String(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                BytesWithSize(new byte[0]);
                return;
            }

            if (_buffer.Capacity < val.Length * 8)
            {
                _buffer.Capacity = val.Length * 8;
            }

            _buffer.Position = 0L;
            _buffer.SetLength(_buffer.Capacity);
            var bytes = Encoding.UTF8.GetBytes(val, 0, val.Length, _buffer.GetBuffer(), 0);
            _buffer.SetLength(bytes);
            BytesWithSize(_buffer);
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00002ADD File Offset: 0x00000CDD
        public void Vector3(Vector3 obj)
        {
            Float(obj.x);
            Float(obj.y);
            Float(obj.z);
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00002B03 File Offset: 0x00000D03
        public void Quaternion(Quaternion obj)
        {
            Float(obj.x);
            Float(obj.y);
            Float(obj.z);
            Float(obj.w);
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00002B35 File Offset: 0x00000D35
        public void Ray(Ray obj)
        {
            Vector3(obj.origin);
            Vector3(obj.direction);
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00002B51 File Offset: 0x00000D51
        public void EntityId(uint id)
        {
            UInt32(id);
        }

        // Token: 0x06000073 RID: 115 RVA: 0x00002B51 File Offset: 0x00000D51
        public void GroupId(uint id)
        {
            UInt32(id);
        }

        // Token: 0x06000074 RID: 116 RVA: 0x00002B5C File Offset: 0x00000D5C
        public void BytesWithSize(MemoryStream val)
        {
            if (val == null || val.Length == 0L)
            {
                UInt32(0u);
                return;
            }

            if ((uint) val.Length > 10485760u)
            {
                UInt32(0u);
                Debug.LogError("BytesWithSize: Too big " + val.Length);
                return;
            }

            UInt32((uint) val.Length);
            Write(val.GetBuffer(), 0, (int) val.Length);
        }

        // Token: 0x06000075 RID: 117 RVA: 0x00002BD0 File Offset: 0x00000DD0
        public void BytesWithSize(byte[] b)
        {
            using (var memoryStream = new MemoryStream(b, 0, b.Length, true, true))
            {
                memoryStream.SetLength(b.Length);
                BytesWithSize(memoryStream);
            }
        }

        // Token: 0x0600007C RID: 124 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void Flush()
        {
            throw new NotImplementedException();
        }

        // Token: 0x0600007D RID: 125 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();

        // Token: 0x0600007E RID: 126 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override int ReadByte() => throw new NotImplementedException();

        // Token: 0x0600007F RID: 127 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

        // Token: 0x06000080 RID: 128 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
    }
}