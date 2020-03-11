using NUnit.Framework;
using ProdCode.Mutation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Mutation
{
    class CustomerValidatorTest
    {
        [Test]
        public void TestValidator()
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer();
            customer.Name = "John Doe";
            Address address = new Address();
            address.City = "Bucharest";
            customer.Address = address;
            validator.Validate(customer);
        }

    }
}
