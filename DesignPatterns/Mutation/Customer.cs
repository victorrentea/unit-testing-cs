using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCode.Mutation
{
    public class Customer
    {
        public string Name;
        public string Phone;
        public List<string> Labels = new List<string>();
        public Address Address {
            get { return Address; }
            set {
                Address = value;
                value.customer = this;
            }
        } 
        public DateTime CreateDate;

    }
}
