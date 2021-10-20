using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Exeptions
{
    public class FileExeption : FileNotFoundException
    {
        public FileExeption(string message) : base(message)
        {

        }
    }
}
