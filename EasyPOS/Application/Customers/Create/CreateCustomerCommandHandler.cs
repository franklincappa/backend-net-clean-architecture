﻿using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Create
{
    public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
         
            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                //throw new ArgumentException(nameof(phoneNumber));
                return Error.Validation("Customer.PhoneNumber", "Phone nuber has not valid format.");
            }
            if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                command.State, command.ZipCode) is not Address address)
            {
                //throw new ArgumentException(nameof(address));
                return Error.Validation("Customer.Address", "Addres is not valid.");
            }
            var customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                command.Name,
                command.LastName,
                command.Email,
                phoneNumber,
                address,
                true
                );

            await _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        
            
        }

    }
}
