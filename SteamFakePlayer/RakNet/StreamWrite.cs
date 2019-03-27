using System;
using System.IO;
using Network;
using Message = RakNet.Network.Message;
using NetworkPeer = RakNet.Network.NetworkPeer;
using Write = RakNet.Network.Write;

namespace RakNet
{
    internal class StreamWrite : Write
    {
        // Token: 0x0400001E RID: 30
        private NetworkPeer _net;

        // Token: 0x0400001F RID: 31
        private Peer _peer;

        // Token: 0x04000020 RID: 32
        private MemoryStream _stream;

        // Token: 0x06000080 RID: 128 RVA: 0x00003853 File Offset: 0x00001A53
        public StreamWrite(NetworkPeer net, Peer peer)
        {
            _net = net;
            _peer = peer;
            _stream = new MemoryStream();
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00003874 File Offset: 0x00001A74
        public void Shutdown()
        {
            _stream.Dispose();
            _stream = null;
            _peer = null;
            _net = null;
        }

        // Token: 0x06000082 RID: 130 RVA: 0x00003896 File Offset: 0x00001A96
        public override bool Start()
        {
            if (_peer == null)
            {
                return false;
            }

            _stream.Position = 0L;
            _stream.SetLength(0L);
            return true;
        }

        // Token: 0x06000083 RID: 131 RVA: 0x000038C0 File Offset: 0x00001AC0
        public override void Send(SendInfo info)
        {
            if (info.connections != null)
            {
                foreach (var connection in info.connections)
                {
                    var memoryStream = _stream;
                    if (memoryStream.Length > 1L && _net.Cryptography != null &&
                        _net.Cryptography.IsEnabledOutgoing(connection))
                    {
                        memoryStream = _net.Cryptography.EncryptCopy(connection, memoryStream, 1);
                    }

                    _peer.SendStart();
                    _peer.WriteBytes(memoryStream);
                    _peer.SendTo(connection.guid, info.priority, info.method, info.channel);
                }
            }

            if (info.connection != null)
            {
                var connection2 = info.connection;
                var memoryStream2 = _stream;
                if (memoryStream2.Length > 1L && _net.Cryptography != null &&
                    _net.Cryptography.IsEnabledOutgoing(connection2))
                {
                    _net.Cryptography.Encrypt(connection2, memoryStream2, 1);
                }

                _peer.SendStart();
                _peer.WriteBytes(memoryStream2);
                _peer.SendTo(connection2.guid, info.priority, info.method, info.channel);
            }
        }

        // Token: 0x06000084 RID: 132 RVA: 0x00003A18 File Offset: 0x00001C18
        public override void PacketId(Message.Type val)
        {
            var val2 = (byte) (val + 140);
            UInt8(val2);
        }

        // Token: 0x06000085 RID: 133 RVA: 0x00003A38 File Offset: 0x00001C38
        public override void UInt8(byte val)
        {
            var u = default(Union8);
            u.u = val;
            Write8(u);
        }

        // Token: 0x06000086 RID: 134 RVA: 0x00003A5C File Offset: 0x00001C5C
        public override void UInt16(ushort val)
        {
            var u = default(Union16);
            u.u = val;
            Write16(u);
        }

        // Token: 0x06000087 RID: 135 RVA: 0x00003A80 File Offset: 0x00001C80
        public override void UInt32(uint val)
        {
            var u = default(Union32);
            u.u = val;
            Write32(u);
        }

        // Token: 0x06000088 RID: 136 RVA: 0x00003AA4 File Offset: 0x00001CA4
        public override void UInt64(ulong val)
        {
            var u = default(Union64);
            u.u = val;
            Write64(u);
        }

        // Token: 0x06000089 RID: 137 RVA: 0x00003AC8 File Offset: 0x00001CC8
        public override void Int8(sbyte val)
        {
            var u = default(Union8);
            u.i = val;
            Write8(u);
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00003AEC File Offset: 0x00001CEC
        public override void Int16(short val)
        {
            var u = default(Union16);
            u.i = val;
            Write16(u);
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00003B10 File Offset: 0x00001D10
        public override void Int32(int val)
        {
            var u = default(Union32);
            u.i = val;
            Write32(u);
        }

        // Token: 0x0600008C RID: 140 RVA: 0x00003B34 File Offset: 0x00001D34
        public override void Int64(long val)
        {
            var u = default(Union64);
            u.i = val;
            Write64(u);
        }

        // Token: 0x0600008D RID: 141 RVA: 0x00003B58 File Offset: 0x00001D58
        public override void Bool(bool val)
        {
            _stream.WriteByte((byte) (val ? 1 : 0));
        }

        // Token: 0x0600008E RID: 142 RVA: 0x00003B6C File Offset: 0x00001D6C
        public override void Float(float val)
        {
            var u = default(Union32);
            u.f = val;
            Write32(u);
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00003B90 File Offset: 0x00001D90
        public override void Double(double val)
        {
            var u = default(Union64);
            u.f = val;
            Write64(u);
        }

        // Token: 0x06000090 RID: 144 RVA: 0x00003BB4 File Offset: 0x00001DB4
        public override void Bytes(byte[] val)
        {
            _stream.Write(val, 0, val.Length);
        }

        // Token: 0x06000091 RID: 145 RVA: 0x00003BC6 File Offset: 0x00001DC6
        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        // Token: 0x06000092 RID: 146 RVA: 0x00003BD6 File Offset: 0x00001DD6
        public override void WriteByte(byte value)
        {
            _stream.WriteByte(value);
        }

        // Token: 0x06000093 RID: 147 RVA: 0x00003BE4 File Offset: 0x00001DE4
        private byte[] GetWriteBuffer() => _stream.GetBuffer();

        // Token: 0x06000094 RID: 148 RVA: 0x00003BF4 File Offset: 0x00001DF4
        private long GetWriteOffset(long i)
        {
            var position = _stream.Position;
            if (_stream.Length < position + i)
            {
                _stream.SetLength(position + i);
            }

            _stream.Position = position + i;
            return position;
        }

        // Token: 0x06000095 RID: 149 RVA: 0x00003C3C File Offset: 0x00001E3C
        private void Write8(Union8 u)
        {
            var writeOffset = GetWriteOffset(1L);
            GetWriteBuffer()[(int) (IntPtr) writeOffset] = u.b1;
        }

        // Token: 0x06000096 RID: 150 RVA: 0x00003C64 File Offset: 0x00001E64
        private void Write16(Union16 u)
        {
            var writeOffset = GetWriteOffset(2L);
            var expr_0F = GetWriteBuffer();
            checked
            {
                expr_0F[(int) (IntPtr) writeOffset] = u.b1;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 1L)] = u.b2;
            }
        }

        // Token: 0x06000097 RID: 151 RVA: 0x00003C98 File Offset: 0x00001E98
        private void Write32(Union32 u)
        {
            var writeOffset = GetWriteOffset(4L);
            var expr_0F = GetWriteBuffer();
            checked
            {
                expr_0F[(int) (IntPtr) writeOffset] = u.b1;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 1L)] = u.b2;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 2L)] = u.b3;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 3L)] = u.b4;
            }
        }

        // Token: 0x06000098 RID: 152 RVA: 0x00003CE4 File Offset: 0x00001EE4
        private void Write64(Union64 u)
        {
            var writeOffset = GetWriteOffset(8L);
            var expr_0F = GetWriteBuffer();
            checked
            {
                expr_0F[(int) (IntPtr) writeOffset] = u.b1;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 1L)] = u.b2;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 2L)] = u.b3;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 3L)] = u.b4;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 4L)] = u.b5;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 5L)] = u.b6;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 6L)] = u.b7;
                expr_0F[(int) (IntPtr) unchecked(writeOffset + 7L)] = u.b8;
            }
        }
    }
}