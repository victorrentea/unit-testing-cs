using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCode.Telemetry
{
	public class ClientConfiguration
	{
		public enum AckMode { NORMAL, TIMEBOXED, FLOOD };
		public string sessionId;
		public DateTime sessionStart;
		public AckMode ackMode;
	}
}