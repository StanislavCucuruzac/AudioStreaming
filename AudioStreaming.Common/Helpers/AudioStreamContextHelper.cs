using AudioStreaming.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Helpers
{
    public static class AudioStreamContextHelper
    {
        public static async Task<string> TryGetSongBase64BySlug(string slug, IFileManager fileManager)
        {
            if (slug != null)
            {
                var songBytes = await fileManager.ReadAllBytes(slug + ".mp3");
                var songBaseString = Convert.ToBase64String(songBytes);
                return "data:audio/mp3;base64, " + songBaseString;
            }

            return null;
        }
    }
}
