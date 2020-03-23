using NUnit.Framework;
using ProdCode.Mutation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Mutation
{
    class CustomerValidatorTest
    {

        private static Customer AValidCustomer()
        {
            return new Customer
            {
                Name = "John Doe",
                Address = new Address
                {
                    City = "Bucharest"
                }
            };
        }
        [Test]
        public void PassesForValidCustomer()
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = AValidCustomer();
            validator.Validate(customer);
        }

        [Test]
        public void FailsForCustomerWithEptyName()
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = AValidCustomer();
            customer.Name = "";
            Assert.Catch(() => validator.Validate(customer));
        }
        [Test]
        public void FailsForCustomerWithNullName()
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = AValidCustomer();
            customer.Name = null;
            Assert.Catch(() => validator.Validate(customer));
        }
        [Test]
        public void FailsForCustomerWithoutAddress()
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = AValidCustomer();
            customer.Address = null;
            Exception exception = Assert.Catch(() => 
                validator.Validate(customer));
            Assert.AreEqual("Missing customer address", exception.Message);
        }
       
    }
}
