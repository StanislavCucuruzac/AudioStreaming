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
        public IFormFile File { get; set; }

        public byte[] GetFileData()
        {
            using (var memoryStream = new MemoryStream())
            {
                File.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public class Handler : IRequestHandler<UploadSongCommand, string>
        {
            private readonly AudioStreamingDbContext _context;
            private readonly IFileManager _fileManager;


            public Handler(AudioStreamingDbContext context, IFileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }
            public async Task<string> Handle(UploadSongCommand request, CancellationToken cancellationToken)
            {
                byte[] songBytes = request.GetFileData();


                string slug = await Nanoid.Nanoid.GenerateAsync(size: 20);

                await _context.SaveChangesAsync(cancellationToken);
                await _fileManager.WriteAllBytes(slug + ".mp3", songBytes);

                return slug;
            }
        }
    }
}
