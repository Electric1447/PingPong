using System;
using System.Net;
using PingPong.Common.Dtos;
using PingPong.Validation.Abstractions;

namespace PingPong.CreationPolicy
{
    public class IPAdressFactory
    {
        private readonly IAddressValidator _addressValidator;
        private readonly IPortValidator _portValidator;

        public IPAdressFactory(IAddressValidator addressValidator, IPortValidator portValidator)
        {
            _addressValidator = addressValidator;
            _portValidator = portValidator;
        }

        public IPAddressWithPort CreateAddress(string[] input)
        {
            if (input.Length == 2)
            {
                if (_addressValidator.TryParseAddress(input[0], out var address) &&
                    _portValidator.TryParsePort(input[1], out int port))
                {
                    return new IPAddressWithPort(new IPAddress(address), port);
                }
            }

            throw new Exception();
        }
    }
}
