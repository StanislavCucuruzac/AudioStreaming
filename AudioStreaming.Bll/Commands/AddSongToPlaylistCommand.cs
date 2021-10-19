using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
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
    public class AddSongToPlaylistCommand : IRequest<Unit>
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }

        public AddSongToPlaylistCommand(int songId, int playlistId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }
        
    }
}
