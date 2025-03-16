using Domain.Primitives;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public sealed class Customer: AgregateRoot
    {
        public Customer(CustomerId id, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Active = active;
        }

        private Customer() 
        {
        }
        public CustomerId Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{Name} {LastName}";
        public string Email { get; private set; }= string.Empty;
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; set; }
    }
}
