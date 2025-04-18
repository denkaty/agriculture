﻿namespace Agriculture.Transactions.Contracts.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandBindingModel
    {
        public CreateSupplierCommandBindingModel(string taxIdentificationNumber, string name, string email, string phoneNumber, string address, string? contactPerson)
        {
            TaxIdentificationNumber = taxIdentificationNumber;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            ContactPerson = contactPerson;
        }

        public string TaxIdentificationNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
    }
}
