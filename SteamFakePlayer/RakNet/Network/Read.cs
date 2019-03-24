using System;
using System.IO;
using System.Text;
using Network;
using UnityEngine;

namespace RakNet.Network
{
    public abstract class Read : Stream
    {
        // Token: 0x0400004F RID: 79
        private readonly MemoryStream _buffer = new MemoryStream();

        // Token: 0x1700000F RID: 15
        // (get) Token: 0x06000083 RID: 131 RVA: 0x00002C36 File Offset: 0x00000E36
        public int length => (int) Length;

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x06000084 RID: 132 RVA: 0x00002C3F File Offset: 0x00000E3F
        public int position => (int) Position;

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000085 RID: 133 RVA: 0x00002C48 File Offset: 0x00000E48
        public int unread => (int) (Length - Position);

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x0600009C RID: 156 RVA: 0x0000274B File Offset: 0x0000094B
        public override bool CanRead => true;

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x0600009D RID: 157 RVA: 0x00002C18 File Offset: 0x00000E18
        public override bool CanSeek => false;

        // Token: 0x17000014 RID: 20
        // (get) Token: 0x0600009E RID: 158 RVA: 0x00002C18 File Offset: 0x00000E18
        public override bool CanWrite => false;

        // Token: 0x17000015 RID: 21
        // (get) Token: 0x0600009F RID: 159 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override long Length => throw new NotImplementedException();

        // Token: 0x06000086 RID: 134
        public abstract bool Start();

        // Token: 0x06000087 RID: 135
        public abstract bool Start(Connection connection);

        // Token: 0x06000088 RID: 136
        public abstract bool Bit();

        // Token: 0x06000089 RID: 137
        public abstract byte PacketId();

        // Token: 0x0600008A RID: 138
        public abstract byte UInt8();

        // Token: 0x0600008B RID: 139
        public abstract ushort UInt16();

        // Token: 0x0600008C RID: 140
        public abstract uint UInt32();

        // Token: 0x0600008D RID: 141
        public abstract ulong UInt64();

        // Token: 0x0600008E RID: 142
        public abstract sbyte Int8();

        // Token: 0x0600008F RID: 143
        public abstract short Int16();

        // Token: 0x06000090 RID: 144
        public abstract int Int32();

        // Token: 0x06000091 RID: 145
        public abstract long Int64();

        // Token: 0x06000092 RID: 146
        public abstract float Float();

        // Token: 0x06000093 RID: 147
        public abstract double Double();

        // Token: 0x06000094 RID: 148 RVA: 0x00002C58 File Offset: 0x00000E58
        public Vector3 Vector3() => new Vector3(Float(), Float(), Float());

        // Token: 0x06000095 RID: 149 RVA: 0x00002C71 File Offset: 0x00000E71
        public Quaternion Quaternion() => new Quaternion(Float(), Float(), Float(), Float());

        // Token: 0x06000096 RID: 150 RVA: 0x00002C90 File Offset: 0x00000E90
        public Ray Ray() => new Ray(Vector3(), Vector3());

        // Token: 0x06000097 RID: 151 RVA: 0x00002CA4 File Offset: 0x00000EA4
        public string String()
        {
            var memoryStream = MemoryStreamWithSize();
            if (memoryStream == null)
            {
                return string.Empty;
            }

            return Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
        }

        // Token: 0x06000098 RID: 152 RVA: 0x00002CD9 File Offset: 0x00000ED9
        public uint EntityId() => UInt32();

        // Token: 0x06000099 RID: 153 RVA: 0x00002CD9 File Offset: 0x00000ED9
        public uint GroupId() => UInt32();

        // Token: 0x0600009A RID: 154 RVA: 0x00002CE4 File Offset: 0x00000EE4
        public MemoryStream MemoryStreamWithSize()
        {
            var num = UInt32();
            if (num == 0u)
            {
                return null;
            }

            if (num > 10485760u)
            {
                return null;
            }

            if (_buffer.Capacity < num)
            {
                _buffer.Capacity = (int) num;
            }

            _buffer.Position = 0L;
            _buffer.SetLength(num);
            var num2 = Read(_buffer.GetBuffer(), 0, (int) num);
            if (num2 != num)
            {
                return null;
            }

            return _buffer;
        }

        // Token: 0x0600009B RID: 155 RVA: 0x00002D5C File Offset: 0x00000F5C
        public byte[] BytesWithSize()
        {
            var num = UInt32();
            if (num == 0u)
            {
                return null;
            }

            if (num > 10485760u)
            {
                return null;
            }

            var result = new byte[num];
            var num2 = Read(result, 0, (int) num);
            if (num2 != num)
            {
                return null;
            }

            return result;
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void Flush()
        {
            throw new NotImplementedException();
        }

        // Token: 0x060000A3 RID: 163 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void WriteByte(byte value)
        {
            throw new NotImplementedException();
        }

        // Token: 0x060000A5 RID: 165 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

        // Token: 0x060000A6 RID: 166 RVA: 0x00002C1B File Offset: 0x00000E1B
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
    }
}