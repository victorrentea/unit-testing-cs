using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCode.Mutation
{
	public class CustomerValidator
	{
		public void Validate(Customer customer)
		{
			if (string.IsNullOrEmpty(customer.Name))
			{
				throw new Exception("Missing customer name");
			}
			ValidateAddress(customer.Address);
			//etc
		}

		private void ValidateAddress(Address address)
		{
			if (address == null)
			{
				throw new Exception("Missing customer address");
			}
			if (string.IsNullOrEmpty(address.City))
			{
				throw new Exception("Missing address xcity");
			}
		}
	}

	//class MyService
	//{
	//	private readonly Clock clock;
	//	public void method(DateTime now)
	//	{
	//		// or 
	//		DateTime now2 = clock.getNow();

	//		// this does not allow truncation:
	//		//if (now2 - somePrevTime > 100 minutes) {
	//		//	stuff
	//		//}

	//		DateTime now3 = TimeMachine.getNow();
	//	}
	//}
	//class TimeMachine
	//{
	//	public static DateTime testTime; // only used from the tests
	//	internal static DateTime getNow()
	//	{
	//		if (testTime != null)
	//		{
	//			return new DateTime();
	//		} else
	//		{
	//			return testTime;
	//		}
	//	}
	//}
}
