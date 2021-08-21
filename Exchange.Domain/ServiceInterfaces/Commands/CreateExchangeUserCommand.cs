﻿namespace Exchange.Domain.ServiceInterfaces.Commands
{
    /// <summary>
    /// Create Exchange User Command
    /// </summary>
    public class CreateExchangeUserCommand
    {
        /// <summary>
        /// User name to create
        /// </summary>
        public string UserName { get; set; }
    }
}