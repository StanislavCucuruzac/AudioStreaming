using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Exeptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad request")
        {

        }
    }
}
