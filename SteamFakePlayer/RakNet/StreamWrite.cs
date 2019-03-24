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
        // Token: 0x06000080 RID: 128 RVA: 0x00003853 File Offset: 0x00001A53
		public StreamWrite(NetworkPeer net, Peer peer)
		{
			this._net = net;
			this._peer = peer;
			this._stream = new MemoryStream();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003874 File Offset: 0x00001A74
		public void Shutdown()
		{
			this._stream.Dispose();
			this._stream = null;
			this._peer = null;
			this._net = null;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003896 File Offset: 0x00001A96
		public override bool Start()
		{
			if (this._peer == null)
			{
				return false;
			}
			this._stream.Position = 0L;
			this._stream.SetLength(0L);
			return true;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000038C0 File Offset: 0x00001AC0
		public override void Send(SendInfo info)
		{
			if (info.connections != null)
			{
				foreach (var connection in info.connections)
				{
					MemoryStream memoryStream = this._stream;
					if (memoryStream.Length > 1L && this._net.Cryptography != null && this._net.Cryptography.IsEnabledOutgoing(connection))
					{
						memoryStream = this._net.Cryptography.EncryptCopy(connection, memoryStream, 1);
					}
					this._peer.SendStart();
					this._peer.WriteBytes(memoryStream);
					this._peer.SendTo(connection.guid, info.priority, info.method, info.channel);
				}
			}
			if (info.connection != null)
			{
				Connection connection2 = info.connection;
				MemoryStream memoryStream2 = this._stream;
				if (memoryStream2.Length > 1L && this._net.Cryptography != null && this._net.Cryptography.IsEnabledOutgoing(connection2))
				{
					this._net.Cryptography.Encrypt(connection2, memoryStream2, 1);
				}
				this._peer.SendStart();
				this._peer.WriteBytes(memoryStream2);
				this._peer.SendTo(connection2.guid, info.priority, info.method, info.channel);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003A18 File Offset: 0x00001C18
		public override void PacketId(Message.Type val)
		{
			byte val2 = (byte)(val + 140);
			this.UInt8(val2);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003A38 File Offset: 0x00001C38
		public override void UInt8(byte val)
		{
			Union8 u = default(Union8);
			u.u = val;
			this.Write8(u);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003A5C File Offset: 0x00001C5C
		public override void UInt16(ushort val)
		{
			Union16 u = default(Union16);
			u.u = val;
			this.Write16(u);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003A80 File Offset: 0x00001C80
		public override void UInt32(uint val)
		{
			Union32 u = default(Union32);
			u.u = val;
			this.Write32(u);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003AA4 File Offset: 0x00001CA4
		public override void UInt64(ulong val)
		{
			Union64 u = default(Union64);
			u.u = val;
			this.Write64(u);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public override void Int8(sbyte val)
		{
			Union8 u = default(Union8);
			u.i = val;
			this.Write8(u);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003AEC File Offset: 0x00001CEC
		public override void Int16(short val)
		{
			Union16 u = default(Union16);
			u.i = val;
			this.Write16(u);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003B10 File Offset: 0x00001D10
		public override void Int32(int val)
		{
			Union32 u = default(Union32);
			u.i = val;
			this.Write32(u);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003B34 File Offset: 0x00001D34
		public override void Int64(long val)
		{
			Union64 u = default(Union64);
			u.i = val;
			this.Write64(u);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003B58 File Offset: 0x00001D58
		public override void Bool(bool val)
		{
			this._stream.WriteByte((byte)(val ? 1 : 0));
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003B6C File Offset: 0x00001D6C
		public override void Float(float val)
		{
			Union32 u = default(Union32);
			u.f = val;
			this.Write32(u);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003B90 File Offset: 0x00001D90
		public override void Double(double val)
		{
			Union64 u = default(Union64);
			u.f = val;
			this.Write64(u);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public override void Bytes(byte[] val)
		{
			this._stream.Write(val, 0, val.Length);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003BC6 File Offset: 0x00001DC6
		public override void Write(byte[] buffer, int offset, int count)
		{
			this._stream.Write(buffer, offset, count);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003BD6 File Offset: 0x00001DD6
		public override void WriteByte(byte value)
		{
			this._stream.WriteByte(value);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003BE4 File Offset: 0x00001DE4
		private byte[] GetWriteBuffer()
		{
			return this._stream.GetBuffer();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003BF4 File Offset: 0x00001DF4
		private long GetWriteOffset(long i)
		{
			long position = this._stream.Position;
			if (this._stream.Length < position + i)
			{
				this._stream.SetLength(position + i);
			}
			this._stream.Position = position + i;
			return position;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003C3C File Offset: 0x00001E3C
		private void Write8(Union8 u)
		{
			long writeOffset = this.GetWriteOffset(1L);
			this.GetWriteBuffer()[(int)(checked((IntPtr)writeOffset))] = u.b1;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003C64 File Offset: 0x00001E64
		private void Write16(Union16 u)
		{
			long writeOffset = this.GetWriteOffset(2L);
			byte[] expr_0F = this.GetWriteBuffer();
			checked
			{
				expr_0F[(int)((IntPtr)writeOffset)] = u.b1;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 1L)))] = u.b2;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003C98 File Offset: 0x00001E98
		private void Write32(Union32 u)
		{
			long writeOffset = this.GetWriteOffset(4L);
			byte[] expr_0F = this.GetWriteBuffer();
			checked
			{
				expr_0F[(int)((IntPtr)writeOffset)] = u.b1;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 1L)))] = u.b2;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 2L)))] = u.b3;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 3L)))] = u.b4;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003CE4 File Offset: 0x00001EE4
		private void Write64(Union64 u)
		{
			long writeOffset = this.GetWriteOffset(8L);
			byte[] expr_0F = this.GetWriteBuffer();
			checked
			{
				expr_0F[(int)((IntPtr)writeOffset)] = u.b1;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 1L)))] = u.b2;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 2L)))] = u.b3;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 3L)))] = u.b4;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 4L)))] = u.b5;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 5L)))] = u.b6;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 6L)))] = u.b7;
				expr_0F[(int)((IntPtr)(unchecked(writeOffset + 7L)))] = u.b8;
			}
		}

		// Token: 0x0400001E RID: 30
		private NetworkPeer _net;

		// Token: 0x0400001F RID: 31
		private Peer _peer;

		// Token: 0x04000020 RID: 32
		private MemoryStream _stream;
    }
}