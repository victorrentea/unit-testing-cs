using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCode.Telemetry
{
	public class TelemetryDiagnosticControls
	{
		public const string DIAGNOSTIC_CHANNEL_CONNECTION_STRING = "*111#";

		private ITelemetryClient telemetryClient;
		public string diagnosticInfo = "";

		public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
		{
			this.telemetryClient = telemetryClient;
		}

		public void CheckTransmission()
		{
			telemetryClient.Disconnect();

			int currentRetry = 1;
			while (!telemetryClient.GetOnlineStatus() && currentRetry <= 3)
			{
				telemetryClient.Connect(DIAGNOSTIC_CHANNEL_CONNECTION_STRING);
				currentRetry++;
			}

			if (!telemetryClient.GetOnlineStatus())
			{
				throw new Exception("Unable to connect.");
			}

			ClientConfiguration config = new ClientConfiguration();
			config.sessionId = telemetryClient.GetVersion() + "-" + Guid.NewGuid();
			config.sessionStart = DateTime.Now;
			config.ackMode = ClientConfiguration.AckMode.NORMAL;
			telemetryClient.Configure(config);

			telemetryClient.Send(TelemetryClient.DIAGNOSTIC_MESSAGE);
			diagnosticInfo = telemetryClient.Receive();
		}
	}
}