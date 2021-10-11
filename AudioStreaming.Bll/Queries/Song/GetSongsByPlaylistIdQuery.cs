using AudioStreaming.Common.Dtos;
using AudioStreaming.Common.Exeptions;
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
    public class GetSongsByPlaylistIdQuery : IRequest<ICollection<SongPlaylistModel>>
    {
        //public int PlaylistId { get; set; }

        //public GetSongsByPlaylistIdQuery(int playlistId)
        //{
        //    PlaylistId = playlistId;
        //}

        //public class Handler : IRequestHandler<GetSongsByPlaylistIdQuery, ICollection<SongPlaylistModel>>
        //{
        //    private readonly AudioStreamingDbContext _context;
        //    private readonly IFileManager _fileManager;

        //    public Handler(AudioStreamingDbContext context, IFileManager fileManager)
        //    {
        //        _context = context;
        //        _fileManager = fileManager;
        //    }

        //    public async Task<ICollection<SongPlaylistModel>> Handle(GetSongsByPlaylistIdQuery request, CancellationToken cancellationToken)
        //    {
        //        var playlist = await _context.Playlists.FindAsync(new object[] { request.PlaylistId }, cancellationToken);

        //        if (playlist is null)
        //            throw new NotFoundExeption("Not found");


        //        var raws = (await _context.PlaylistSongs
        //            .Include(prop => prop.SongId)
        //            .Include(prop => prop.PlaylistId)
        //            .Where(playlistSong =>
        //                (playlistSong.SongId == request.PlaylistId || playlistSong.PlaylistId == request.PlaylistId))
        //            .Select(prop =>
        //                new
        //                {
        //                    Playlist = prop.SongId == request.PlaylistId ? prop.PlaylistId : prop.SongId,

        //                })
        //            .ToListAsync(cancellationToken));
                  

        //        var songs = new List<SongPlaylistModel>();

        //        foreach (var raw in raws)
        //        {
        //            songs.Add(new SongPlaylistModel()
        //            {
        //                Id = raw.

        //            });
        //        }

        //        return songs;
        //    }

            
        //}
    }
        
}
