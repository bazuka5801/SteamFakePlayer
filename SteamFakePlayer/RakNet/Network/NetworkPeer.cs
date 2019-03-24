using System;
using Network;

namespace RakNet.Network
{
    public abstract class NetworkPeer
    {
        public enum StatTypeLong
        {
            BytesSent,
            BytesSentLastSecond,
            BytesReceived,
            BytesReceivedLastSecond,
            MessagesInSendBuffer,
            BytesInSendBuffer,
            MessagesInResendBuffer,
            BytesInResendBuffer,
            PacketLossAverage,
            PacketLossLastSecond,
            ThrottleBytes
        }

        public NetworkCryptography Cryptography;

        public Action<Message> OnMessage;
        public Func<int, Read, uint, int, bool> OnUnconnectedMessage;

        public Read read;
        public Write write;

        public abstract void Send();


        protected Message StartMessage(Message.Type type, Connection connection)
        {
            var message = new Message
            {
                peer = this,
                type = type,
                connection = connection
            };
            return message;
        }
    }
}