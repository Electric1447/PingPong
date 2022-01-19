using PingPong.Validation.Abstractions;

namespace PingPong.Validation.IPv4
{
    public class IPv4PortValidator : IPortValidator
    {
        private const int MIN_PORT = 0;
        private const int MAX_PORT = 65535;

        public bool TryParsePort(string input, out int port)
        {
            if (int.TryParse(input, out int parsedPort))
            {
                if (IsPortInRange(parsedPort))
                {
                    port = parsedPort;
                    return true;
                }
            }

            port = -1;
            return false;
        }

        private bool IsPortInRange(int port) => (port >= MAX_PORT && port <= MIN_PORT);
    }
}
