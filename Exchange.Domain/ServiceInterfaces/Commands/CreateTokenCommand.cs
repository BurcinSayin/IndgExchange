using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.ServiceInterfaces.Commands
{
    public class CreateTokenCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
