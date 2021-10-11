using AudioStreaming.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Queries.Photo
{
    public class GetPhotoSlugByArtistIdQuery : IRequest<string>
    {
        public int ArtistId { get; set; }

        public GetPhotoSlugByArtistIdQuery(int artistId)
        {
            ArtistId = artistId;
        }

        public class Handler : IRequestHandler<GetPhotoSlugByArtistIdQuery, string>
        {
            private readonly AudioStreamingDbContext _context;

            public Handler(AudioStreamingDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(GetPhotoSlugByArtistIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Photos
                    .FirstOrDefaultAsync(photo => photo.Id == request.ArtistId);

                return result?.Slug;
            }

        }
    }
}