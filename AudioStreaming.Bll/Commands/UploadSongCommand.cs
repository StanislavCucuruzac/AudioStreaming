using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
using AudioStreaming.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class UploadSongCommand : IRequest<string>
    {
        [Required]
        public int ArtistId {get;set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile File { get; set; }

        public byte[] GetFileData()
        {
            using (var memoryStream = new MemoryStream())
            {
                File.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
