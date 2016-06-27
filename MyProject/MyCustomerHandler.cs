using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain;

namespace MyProject
{
    public class MyCustomerHandler
    {
        public Customer CreateCustomer(string name, string street, string city) =>
            new Customer
            {
                Id = 1,
                Name = name,
                Address = new Address
                {
                    Street = street,
                    City = city
                }
            };
    }
}
