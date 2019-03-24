using System;
using System.IO;
using Network;
using NetworkPeer = RakNet.Network.NetworkPeer;
using Read = RakNet.Network.Read;

namespace RakNet
{
    internal class StreamRead : Read
    {
        // Token: 0x04000021 RID: 33
        private NetworkPeer _net;

        // Token: 0x04000022 RID: 34
        private Peer _peer;

        // Token: 0x04000023 RID: 35
        private MemoryStream _stream;

        // Token: 0x06000099 RID: 153 RVA: 0x00003D64 File Offset: 0x00001F64
        public StreamRead(NetworkPeer net, Peer peer)
        {
            _net = net;
            _peer = peer;
            _stream = new MemoryStream();
        }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x060000AB RID: 171 RVA: 0x00003F95 File Offset: 0x00002195
        public override long Length => _stream.Length;

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x060000AC RID: 172 RVA: 0x00003FA2 File Offset: 0x000021A2
        // (set) Token: 0x060000AD RID: 173 RVA: 0x00003FAF File Offset: 0x000021AF
        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        // Token: 0x0600009A RID: 154 RVA: 0x00003D85 File Offset: 0x00001F85
        public void Shutdown()
        {
            _stream.Dispose();
            _stream = null;
            _peer = null;
            _net = null;
        }

        // Token: 0x0600009B RID: 155 RVA: 0x00003DA8 File Offset: 0x00001FA8
        public override bool Start()
        {
            if (_peer == null)
            {
                return false;
            }

            _stream.Position = 0L;
            _stream.SetLength(0L);
            _peer.ReadBytes(_stream, _peer.IncomingBytesUnread);
            return true;
        }

        // Token: 0x0600009C RID: 156 RVA: 0x00003DF8 File Offset: 0x00001FF8
        public override bool Start(Connection connection)
        {
            if (!Start())
            {
                return false;
            }

            if (_stream.Length > 1L && _net.Cryptography != null && _net.Cryptography.IsEnabledIncoming(connection))
            {
                _net.Cryptography.Decrypt(connection, _stream, 1);
            }

            return true;
        }

        // Token: 0x0600009D RID: 157 RVA: 0x00003E57 File Offset: 0x00002057
        public override byte PacketId() => UInt8();

        // Token: 0x0600009E RID: 158 RVA: 0x00003E5F File Offset: 0x0000205F
        public override bool Bit() => unread >= 1 && _stream.ReadByte() != 0;

        // Token: 0x0600009F RID: 159 RVA: 0x00003E7A File Offset: 0x0000207A
        public override byte UInt8()
        {
            if (unread < 1)
            {
                return 0;
            }

            return Read8().u;
        }

        // Token: 0x060000A0 RID: 160 RVA: 0x00003E92 File Offset: 0x00002092
        public override ushort UInt16()
        {
            if (unread < 2)
            {
                return 0;
            }

            return Read16().u;
        }

        // Token: 0x060000A1 RID: 161 RVA: 0x00003EAA File Offset: 0x000020AA
        public override uint UInt32()
        {
            if (unread < 4)
            {
                return 0u;
            }

            return Read32().u;
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00003EC2 File Offset: 0x000020C2
        public override ulong UInt64()
        {
            if (unread < 8)
            {
                return 0uL;
            }

            return Read64().u;
        }

        // Token: 0x060000A3 RID: 163 RVA: 0x00003EDB File Offset: 0x000020DB
        public override sbyte Int8()
        {
            if (unread < 1)
            {
                return 0;
            }

            return Read8().i;
        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00003EF3 File Offset: 0x000020F3
        public override short Int16()
        {
            if (unread < 2)
            {
                return 0;
            }

            return Read16().i;
        }

        // Token: 0x060000A5 RID: 165 RVA: 0x00003F0B File Offset: 0x0000210B
        public override int Int32()
        {
            if (unread < 4)
            {
                return 0;
            }

            return Read32().i;
        }

        // Token: 0x060000A6 RID: 166 RVA: 0x00003F23 File Offset: 0x00002123
        public override long Int64()
        {
            if (unread < 8)
            {
                return 0L;
            }

            return Read64().i;
        }

        // Token: 0x060000A7 RID: 167 RVA: 0x00003F3C File Offset: 0x0000213C
        public override float Float()
        {
            if (unread < 4)
            {
                return 0f;
            }

            return Read32().f;
        }

        // Token: 0x060000A8 RID: 168 RVA: 0x00003F58 File Offset: 0x00002158
        public override double Double()
        {
            if (unread < 8)
            {
                return 0.0;
            }

            return Read64().f;
        }

        // Token: 0x060000A9 RID: 169 RVA: 0x00003F78 File Offset: 0x00002178
        public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

        // Token: 0x060000AA RID: 170 RVA: 0x00003F88 File Offset: 0x00002188
        public override int ReadByte() => _stream.ReadByte();

        // Token: 0x060000AE RID: 174 RVA: 0x00003FBD File Offset: 0x000021BD
        private byte[] GetReadBuffer() => _stream.GetBuffer();

        // Token: 0x060000AF RID: 175 RVA: 0x00003FCC File Offset: 0x000021CC
        private long GetReadOffset(long i)
        {
            var position = _stream.Position;
            _stream.Position = position + i;
            return position;
        }

        // Token: 0x060000B0 RID: 176 RVA: 0x00003FF4 File Offset: 0x000021F4
        private Union8 Read8()
        {
            var readOffset = GetReadOffset(1L);
            var readBuffer = GetReadBuffer();
            var result = default(Union8);
            result.b1 = readBuffer[(int) (IntPtr) readOffset];
            return result;
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x00004028 File Offset: 0x00002228
        private Union16 Read16()
        {
            var readOffset = GetReadOffset(2L);
            var readBuffer = GetReadBuffer();
            var result = default(Union16);
            checked
            {
                result.b1 = readBuffer[(int) (IntPtr) readOffset];
                result.b2 = readBuffer[(int) (IntPtr) unchecked(readOffset + 1L)];
                return result;
            }
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00004068 File Offset: 0x00002268
        private Union32 Read32()
        {
            var readOffset = GetReadOffset(4L);
            var readBuffer = GetReadBuffer();
            var result = default(Union32);
            checked
            {
                result.b1 = readBuffer[(int) (IntPtr) readOffset];
                result.b2 = readBuffer[(int) (IntPtr) unchecked(readOffset + 1L)];
                result.b3 = readBuffer[(int) (IntPtr) unchecked(readOffset + 2L)];
                result.b4 = readBuffer[(int) (IntPtr) unchecked(readOffset + 3L)];
                return result;
            }
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x000040C4 File Offset: 0x000022C4
        private Union64 Read64()
        {
            var readOffset = GetReadOffset(8L);
            var readBuffer = GetReadBuffer();
            var result = default(Union64);
            checked
            {
                result.b1 = readBuffer[(int) (IntPtr) readOffset];
                result.b2 = readBuffer[(int) (IntPtr) unchecked(readOffset + 1L)];
                result.b3 = readBuffer[(int) (IntPtr) unchecked(readOffset + 2L)];
                result.b4 = readBuffer[(int) (IntPtr) unchecked(readOffset + 3L)];
                result.b5 = readBuffer[(int) (IntPtr) unchecked(readOffset + 4L)];
                result.b6 = readBuffer[(int) (IntPtr) unchecked(readOffset + 5L)];
                result.b7 = readBuffer[(int) (IntPtr) unchecked(readOffset + 6L)];
                result.b8 = readBuffer[(int) (IntPtr) unchecked(readOffset + 7L)];
                return result;
            }
        }
    }
}