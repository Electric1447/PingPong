namespace PingPong.Validation.Abstractions
{
    public interface IAddressValidator
    {
        bool TryParseAddress(string input, out byte[] address);
    }
}
