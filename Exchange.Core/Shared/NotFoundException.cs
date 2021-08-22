using System;

namespace Exchange.Core.Shared
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {
            
        }
        
    }
}