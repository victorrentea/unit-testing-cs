using NUnit.Framework;
using ProdCode.Mutation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Mutation
{
    class CustomerValidatorTest: IDisposable
    {
        private readonly CustomerValidator validator = new CustomerValidator();
        private Customer customer;
        public CustomerValidatorTest()
        {
            //replacement of [SetUp] in xUnit
            Console.WriteLine(" A new instance is born");
        }

        [SetUp]
        public void InitializeData()
        {
            Console.WriteLine("Cleanup before test");
            customer = AValidCustomer();
        }
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
            validator.Validate(customer);
        }

        [Test]
        public void FailsForCustomerWithEptyName()
        {
            customer.Name = "";
            Assert.Catch(() => validator.Validate(customer));
        }
        [Test]
        public void FailsForCustomerWithNullName()
        {
            customer.Name = null;
            Assert.Catch(() => validator.Validate(customer));
        }
        [Test]
        public void FailsForCustomerWithoutAddress()
        {
            customer.Address = null;
            Exception exception = Assert.Catch(() => 
                validator.Validate(customer));
            Assert.AreEqual("Missing customer address", exception.Message);
        }

        public void Dispose()
        {
            //replacement for [TearDown] in xUnit
        }
    }
}
