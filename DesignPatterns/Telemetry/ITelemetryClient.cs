namespace ProdCode.Telemetry
{
    public interface ITelemetryClient
    {
        void Configure(ClientConfiguration config);
        void Connect(string telemetryServerConnectionString);
        void Disconnect();
        bool GetOnlineStatus();
        string GetVersion();
        string Receive();
        void Send(string message);
    }
}