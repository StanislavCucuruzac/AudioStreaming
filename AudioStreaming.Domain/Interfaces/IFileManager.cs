using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain.Interfaces
{
    public interface IFileManager
    {
        public Task<bool> WriteAllBytes(string fileName, byte[] bytes);
        public Task<bool> Delete(string fileName);
        public Task<byte[]> ReadAllBytes(string fileName);
    }
}
