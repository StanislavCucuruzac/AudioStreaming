using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands.Delete
{
    public class DeletePhotoCommand : IRequest
    {
        public int ArtistId { get; set; }
        public string PhotoSlug { get; set; }

        public DeletePhotoCommand(int profileId, string photoSlug)
        {
            ArtistId = profileId;
            PhotoSlug = photoSlug;
        }          
        
    }
}
