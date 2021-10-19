using AudioStreaming.Common.Dtos;
using AudioStreaming.Common.Exeptions;
using AudioStreaming.Common.Helpers;
using AudioStreaming.Common.Models;
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

namespace AudioStreaming.Bll.Queries.Song
{
    public class GetSongsQuery : IRequest<ICollection<SongModel>>
    {
        public int PlaylistId { get; set; }
        public int LoadFrom { get; set; }

        public GetSongsQuery(int playlistId, int loadFrom = 0)
        {
            PlaylistId = playlistId;
            LoadFrom = loadFrom;
        }

    }

}
