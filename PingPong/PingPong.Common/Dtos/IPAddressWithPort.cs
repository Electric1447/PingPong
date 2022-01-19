using System.Net;

namespace PingPong.Common.Dtos
{
    public struct IPAddressWithPort
    {
        public IPAddress Address { get; init; }
        public int Port { get; init; }

        public IPAddressWithPort(IPAddress address, int port)
        {
            Address = address;
            Port = port;
        }

        public override string ToString() => $"{Address}:{Port}";
    }
}
