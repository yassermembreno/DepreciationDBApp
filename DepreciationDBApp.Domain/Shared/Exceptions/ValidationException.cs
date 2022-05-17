using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Messages { get; set; }

        public ValidationException() : base()
        {
            Messages = new List<string>();
        }
    }
}
