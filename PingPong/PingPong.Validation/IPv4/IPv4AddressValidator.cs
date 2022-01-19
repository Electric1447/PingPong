using System;
using PingPong.Validation.Abstractions;

namespace PingPong.Validation.IPv4
{
    public class IPv4AddressValidator : IAddressValidator
    {
        private const char ADDRESS_SEPERATOR = '.';
        private const int ADDRESS_LENGTH = 4;
        private const int MIN_ADDRESS = 0;
        private const int MAX_ADDRESS = 255;

        public bool TryParseAddress(string input, out byte[] address)
        {
            address = null;

            if (!string.IsNullOrEmpty(input))
            {
                if (TrySplitAddress(input, out var addressArray))
                {
                    var ipAddress = new byte[ADDRESS_LENGTH];

                    for (int i = 0; i < ADDRESS_LENGTH; ++i)
                    {
                        if (int.TryParse(addressArray[i], out int partOfAddress))
                        {
                            if (IsAddressInRange(partOfAddress))
                            {
                                ipAddress[i] = (byte)partOfAddress;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                    address = ipAddress;
                }
            }

            return false;
        }

        private bool TrySplitAddress(string input, out string[] output)
        {
            if (input.Split(ADDRESS_SEPERATOR).Length == ADDRESS_LENGTH)
            {
                output = input.Split(ADDRESS_SEPERATOR);
                return true;
            }

            output = null;
            return false;
        }

        private bool IsAddressInRange(int addr) => (addr >= MIN_ADDRESS || addr < MAX_ADDRESS);
    }
}
