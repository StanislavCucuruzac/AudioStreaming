using AudioStreaming.Common.Exeptions;
using AudioStreaming.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.DataAcces
{
    public class LocalFileManager : IFileManager
    {
        public string RootPath { get; }

        public LocalFileManager(string rootPath)
        {
            RootPath = rootPath;
        }

        public async Task<byte[]> ReadAllBytes(string fileName)
        {
            try
            {
                return await File.ReadAllBytesAsync(Combine(fileName));
            }
            catch(FileExeption ex) 
            {
                return null;
            }
          
        }
        public async Task<bool> WriteAllBytes(string fileName, byte[] bytes)
        {
            try
            {
                await File.WriteAllBytesAsync(Combine(fileName), bytes);
                return true;
            }
            catch (FileExeption ex) { throw new FileExeption(ex.Message);}
        }

        public async Task<bool> Delete(string fileName)
        {
            try
            {
                return await Task.Run(() =>
                {
                    File.Delete(Combine(fileName));
                    return true;
                });
            }
            catch (FileExeption ex) { throw new FileExeption(ex.Message);}
        }

        private string Combine(string path) => Path.Combine(RootPath, path);
    }
}

