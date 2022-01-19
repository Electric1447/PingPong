namespace PingPong.Validation.Abstractions
{
    public interface IPortValidator
    {
        bool TryParsePort(string input, out int port);
    }
}
