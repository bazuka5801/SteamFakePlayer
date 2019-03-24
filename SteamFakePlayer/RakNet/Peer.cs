using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Network;
using SapphireEngine;

namespace RakNet
{
    [SuppressUnmanagedCodeSecurity]
    internal class Peer
    {
        // Token: 0x0200000E RID: 14
        public enum PacketReliability
        {
            // Token: 0x04000041 RID: 65
            Unreliable,

            // Token: 0x04000042 RID: 66
            UnreliableSequenced,

            // Token: 0x04000043 RID: 67
            Reliable,

            // Token: 0x04000044 RID: 68
            ReliableOrdered,

            // Token: 0x04000045 RID: 69
            ReliableSequenced,

            // Token: 0x04000046 RID: 70
            UnreliableWithAckReceipt,

            // Token: 0x04000047 RID: 71
            ReliableWithAckReceipt,

            // Token: 0x04000048 RID: 72
            ReliableOrderedWithAckReceipt
        }

        // Token: 0x04000011 RID: 17
        private readonly byte[] _byteBuffer = new byte[512];


        // Token: 0x04000010 RID: 16
        private IntPtr _ptr;

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x0600003A RID: 58 RVA: 0x00002D29 File Offset: 0x00000F29
        public virtual ulong IncomingGuid
        {
            get
            {
                Check();
                return Native.NETRCV_GUID(_ptr);
            }
        }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x0600003B RID: 59 RVA: 0x00002D3C File Offset: 0x00000F3C
        public virtual uint IncomingAddressInt
        {
            get
            {
                Check();
                return Native.NETRCV_Address(_ptr);
            }
        }

        // Token: 0x17000006 RID: 6
        // (get) Token: 0x0600003C RID: 60 RVA: 0x00002D4F File Offset: 0x00000F4F
        public virtual uint IncomingPort
        {
            get
            {
                Check();
                return Native.NETRCV_Port(_ptr);
            }
        }

        // Token: 0x17000007 RID: 7
        // (get) Token: 0x0600003D RID: 61 RVA: 0x00002D62 File Offset: 0x00000F62
        public string IncomingAddress => GetAddress(IncomingGuid);

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x0600003E RID: 62 RVA: 0x00002D70 File Offset: 0x00000F70
        public virtual int IncomingBits
        {
            get
            {
                Check();
                return Native.NETRCV_LengthBits(_ptr);
            }
        }

        // Token: 0x17000009 RID: 9
        // (get) Token: 0x0600003F RID: 63 RVA: 0x00002D83 File Offset: 0x00000F83
        public virtual int IncomingBitsUnread
        {
            get
            {
                Check();
                return Native.NETRCV_UnreadBits(_ptr);
            }
        }

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000040 RID: 64 RVA: 0x00002D96 File Offset: 0x00000F96
        public virtual int IncomingBytes => IncomingBits / 8;

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000041 RID: 65 RVA: 0x00002DA0 File Offset: 0x00000FA0
        public virtual int IncomingBytesUnread => IncomingBitsUnread / 8;

        public static Peer CreateServer(string ip, int port, int maxConnections)
        {
            var peer = new Peer();
            peer._ptr = Native.NET_Create();
            if (Native.NET_StartServer(peer._ptr, ip, port, maxConnections) == 0)
            {
                return peer;
            }

            peer.Close();
            var text = StringFromPointer(Native.NET_LastStartupError(peer._ptr));
            ConsoleSystem.LogWarning(string.Concat("Couldn't create server on port ", port, " (", text, ")"));
            return null;
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00002C50 File Offset: 0x00000E50
        public static Peer CreateConnection(string hostname, int port, int retries, int retryDelay, int timeout)
        {
            var peer = new Peer();
            peer._ptr = Native.NET_Create();
            if (Native.NET_StartClient(peer._ptr, hostname, port, retries, retryDelay, timeout) == 0)
            {
                return peer;
            }

            var text = StringFromPointer(Native.NET_LastStartupError(peer._ptr));
            ConsoleSystem.LogWarning(string.Concat("Couldn't connect to server ", hostname, ":", port, " (", text,
                ")"));
            peer.Close();
            return null;
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00002CDE File Offset: 0x00000EDE
        public void Close()
        {
            if (_ptr != IntPtr.Zero)
            {
                Native.NET_Close(_ptr);
                _ptr = IntPtr.Zero;
            }
        }

        // Token: 0x06000039 RID: 57 RVA: 0x00002D08 File Offset: 0x00000F08
        public bool Receive() => !(_ptr == IntPtr.Zero) && Native.NET_Receive(_ptr);

        // Token: 0x06000042 RID: 66 RVA: 0x00002DAA File Offset: 0x00000FAA
        public virtual void SetReadPos(int bitsOffset)
        {
            Check();
            Native.NETRCV_SetReadPointer(_ptr, bitsOffset);
        }

        // Token: 0x06000043 RID: 67 RVA: 0x00002DBE File Offset: 0x00000FBE
        protected virtual unsafe bool Read(byte* data, int length)
        {
            Check();
            return Native.NETRCV_ReadBytes(_ptr, data, length);
        }

        // Token: 0x06000044 RID: 68 RVA: 0x00002DD4 File Offset: 0x00000FD4
        public unsafe int ReadBytes(byte[] buffer, int offset, int length)
        {
            fixed (byte* ptr = buffer)
            {
                if (!Read(ptr + offset, length))
                {
                    return 0;
                }
            }

            return length;
        }

        // Token: 0x06000045 RID: 69 RVA: 0x00002E0C File Offset: 0x0000100C
        public unsafe byte ReadByte()
        {
            fixed (byte* byteBuffer = _byteBuffer)
            {
                if (!Read(byteBuffer, 1))
                {
                    return 0;
                }
            }

            return _byteBuffer[0];
        }

        // Token: 0x06000046 RID: 70 RVA: 0x00002E4B File Offset: 0x0000104B
        public IntPtr RawData()
        {
            Check();
            return Native.NETRCV_RawData(_ptr);
        }

        // Token: 0x06000047 RID: 71 RVA: 0x00002E60 File Offset: 0x00001060
        public unsafe int ReadBytes(MemoryStream memoryStream, int length)
        {
            if (memoryStream.Capacity < length)
            {
                memoryStream.Capacity = length + 32;
            }

            fixed (byte* buffer = memoryStream.GetBuffer())
            {
                memoryStream.SetLength(memoryStream.Capacity);
                if (!Read(buffer, length))
                {
                    return 0;
                }

                memoryStream.SetLength(length);
            }

            return length;
        }

        // Token: 0x06000048 RID: 72 RVA: 0x00002EC2 File Offset: 0x000010C2
        public virtual void SendStart()
        {
            Check();
            Native.NETSND_Start(_ptr);
        }

        // Token: 0x06000049 RID: 73 RVA: 0x00002ED5 File Offset: 0x000010D5
        public unsafe void WriteByte(byte val)
        {
            Write(&val, 1);
        }

        // Token: 0x0600004A RID: 74 RVA: 0x00002EE4 File Offset: 0x000010E4
        public unsafe void WriteBytes(byte[] val, int offset, int length)
        {
            fixed (byte* ptr = val)
            {
                Write(ptr + offset, length);
            }
        }

        // Token: 0x0600004B RID: 75 RVA: 0x00002F18 File Offset: 0x00001118
        public unsafe void WriteBytes(byte[] val)
        {
            fixed (byte* ptr = val)
            {
                Write(ptr, val.Length);
            }
        }

        // Token: 0x0600004C RID: 76 RVA: 0x00002F4A File Offset: 0x0000114A
        public void WriteBytes(MemoryStream stream)
        {
            WriteBytes(stream.GetBuffer(), 0, (int) stream.Length);
        }

        // Token: 0x0600004D RID: 77 RVA: 0x00002F60 File Offset: 0x00001160
        protected virtual unsafe void Write(byte* data, int size)
        {
            if (size == 0)
            {
                return;
            }

            if (data == null)
            {
                return;
            }

            Check();
            Native.NETSND_WriteBytes(_ptr, data, size);
        }

        // Token: 0x0600004E RID: 78 RVA: 0x00002F7F File Offset: 0x0000117F
        public virtual uint SendBroadcast(Priority priority, SendMethod reliability, sbyte channel)
        {
            Check();
            return Native.NETSND_Broadcast(_ptr, ToRaknetPriority(priority), ToRaknetPacketReliability(reliability),
                channel);
        }

        // Token: 0x0600004F RID: 79 RVA: 0x00002FA1 File Offset: 0x000011A1
        public virtual uint SendTo(ulong guid, Priority priority, SendMethod reliability, sbyte channel)
        {
            Check();
            return Native.NETSND_Send(_ptr, guid, ToRaknetPriority(priority), ToRaknetPacketReliability(reliability),
                channel);
        }

        // Token: 0x06000050 RID: 80 RVA: 0x00002FC5 File Offset: 0x000011C5
        public unsafe void SendUnconnectedMessage(byte* data, int length, uint adr, ushort port)
        {
            Check();
            Native.NET_SendMessage(_ptr, data, length, adr, port);
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00002FDD File Offset: 0x000011DD
        public string GetAddress(ulong guid)
        {
            Check();
            return StringFromPointer(Native.NET_GetAddress(_ptr, guid));
        }

        // Token: 0x06000052 RID: 82 RVA: 0x00002FF6 File Offset: 0x000011F6
        private static string StringFromPointer(IntPtr p)
        {
            if (p == IntPtr.Zero)
            {
                return string.Empty;
            }

            return Marshal.PtrToStringAnsi(p);
        }

        // Token: 0x06000053 RID: 83 RVA: 0x00003011 File Offset: 0x00001211
        public int ToRaknetPriority(Priority priority)
        {
            switch (priority)
            {
                case Priority.Immediate:
                    return 0;
                case Priority.High:
                    return 1;
                case Priority.Medium:
                    return 2;
                default:
                    return 3;
            }
        }

        // Token: 0x06000054 RID: 84 RVA: 0x0000302E File Offset: 0x0000122E
        public int ToRaknetPacketReliability(SendMethod priority)
        {
            switch (priority)
            {
                case SendMethod.Reliable:
                    return 3;
                case SendMethod.ReliableUnordered:
                    return 2;
                case SendMethod.ReliableSequenced:
                    return 4;
                case SendMethod.Unreliable:
                    return 0;
                case SendMethod.UnreliableSequenced:
                    return 1;
                default:
                    return 3;
            }
        }

        // Token: 0x06000055 RID: 85 RVA: 0x00003057 File Offset: 0x00001257
        public void Kick(Connection connection)
        {
            Check();
            Native.NET_CloseConnection(_ptr, connection.guid);
        }

        // Token: 0x06000056 RID: 86 RVA: 0x00003070 File Offset: 0x00001270
        protected virtual void Check()
        {
            if (_ptr == IntPtr.Zero)
            {
                throw new NullReferenceException("Peer has already shut down!");
            }
        }

        // Token: 0x06000057 RID: 87 RVA: 0x00003090 File Offset: 0x00001290
        public virtual string GetStatisticsString(ulong guid)
        {
            Check();
            return string.Format("Average Ping:\t\t{0}\nLast Ping:\t\t{1}\nLowest Ping:\t\t{2}\n{3}",
                GetPingAverage(guid), GetPingLast(guid), GetPingLowest(guid),
                StringFromPointer(Native.NET_GetStatisticsString(_ptr, guid)));
        }

        // Token: 0x06000058 RID: 88 RVA: 0x000030F4 File Offset: 0x000012F4
        public virtual int GetPingAverage(ulong guid)
        {
            Check();
            return Native.NET_GetAveragePing(_ptr, guid);
        }

        // Token: 0x06000059 RID: 89 RVA: 0x00003108 File Offset: 0x00001308
        public virtual int GetPingLast(ulong guid)
        {
            Check();
            return Native.NET_GetLastPing(_ptr, guid);
        }

        // Token: 0x0600005A RID: 90 RVA: 0x0000311C File Offset: 0x0000131C
        public virtual int GetPingLowest(ulong guid)
        {
            Check();
            return Native.NET_GetLowestPing(_ptr, guid);
        }
    }
}