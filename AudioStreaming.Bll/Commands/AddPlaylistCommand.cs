using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class AddPlaylistCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int PlaylistId { get; set; }

        public AddPlaylistCommand(int userId, int playlistId)
        {
            UserId = userId;
            PlaylistId = playlistId;
        }

        
    }
}
