using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class DeleteSongFromPlaylist : IRequest<Unit>
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }

        public DeleteSongFromPlaylist(int songId, int playlistId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }

    }
}
