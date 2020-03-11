using System;

namespace ProdCode.Telemetry
{
	class TelemetryClient
	{
		public const string DIAGNOSTIC_MESSAGE = "AT#UD";


		private bool onlineStatus;
		private string diagnosticMessageResult = "";

		private readonly Random connectionEventsSimulator = new Random(42);

		public bool GetOnlineStatus()
		{
			return onlineStatus;
		}

		public void Connect(string telemetryServerConnectionString)
		{
			if (telemetryServerConnectionString == null || "".Equals(telemetryServerConnectionString))
			{
				throw new Exception();
			}

			// simulate the operation on a real modem
			bool success = connectionEventsSimulator.Next(0, 10) <= 8;

			onlineStatus = success;
		}

		public string GetVersion()
		{
			return "1.3";
		}

		public void Disconnect()
		{
			onlineStatus = false;
		}

		public void Send(string message)
		{
			if (message == null || "".Equals(message))
			{
				throw new Exception();
			}

			if (message == DIAGNOSTIC_MESSAGE)
			{
				// simulate a status report
				diagnosticMessageResult = "LAST TX rate................ 100 MBPS\r\n"
						+ "HIGHEST TX rate............. 100 MBPS\r\n" + "LAST RX rate................ 100 MBPS\r\n"
						+ "HIGHEST RX rate............. 100 MBPS\r\n" + "BIT RATE.................... 100000000\r\n"
						+ "WORD LEN.................... 16\r\n" + "WORD/FRAME.................. 511\r\n"
						+ "BITS/FRAME.................. 8192\r\n" + "MODULATION TYPE............. PCM/FM\r\n"
						+ "TX Digital Los.............. 0.75\r\n" + "RX Digital Los.............. 0.10\r\n"
						+ "BEP Test.................... -5\r\n" + "Local Rtrn Count............ 00\r\n"
						+ "Remote Rtrn Count........... 00";

				return;
			}

			// here should go the real Send operation (not needed for this exercise)
		}

		public string Receive()
		{
			string message;

			if (diagnosticMessageResult == null || "".Equals(diagnosticMessageResult))
			{
				// simulate a received message (just for illustration - not needed for this exercise)
				message = "";
				int messageLength = connectionEventsSimulator.Next(50) + 60;
				for (int i = messageLength; i >= 0; --i)
				{
					message += (char)connectionEventsSimulator.Next(40) + 86;
				}

			}
			else
			{
				message = diagnosticMessageResult;
				diagnosticMessageResult = "";
			}

			return message;
		}

		public void Configure(ClientConfiguration config)
		{
			//TODO Configure the client
			throw new NotImplementedException("This stuff only works in production env");
		}
	}
}