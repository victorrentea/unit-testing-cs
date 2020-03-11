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
}
