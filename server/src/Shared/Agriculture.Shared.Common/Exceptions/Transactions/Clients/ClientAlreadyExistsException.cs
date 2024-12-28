using Agriculture.Shared.Common.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Clients
{
    public class ClientAlreadyExistsException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Client '{0}' already exists.";

        public ClientAlreadyExistsException(string supplierIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, supplierIdentifier))
        {
        }
    }
}
