using AudioStreaming.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Queries.Photo
{
    public class GetPhotoBySlugQuery : IRequest<byte[]>
    {
        public string PhotoSlug { get; set; }

        public GetPhotoBySlugQuery(string photoPath)
        {
            PhotoSlug= photoPath;
        }

    }
}
