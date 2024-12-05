﻿namespace Agriculture.Items.Contracts.Features.Items.Commands
{
    public class CreateItemCommandBindingModel
    {
        public CreateItemCommandBindingModel(string catalogNumber, string name, string description)
        {
            CatalogNumber = catalogNumber;
            Name = name;
            Description = description;
        }

        public string CatalogNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
