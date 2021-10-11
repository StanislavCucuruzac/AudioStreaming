using AudioStreaming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Seed
{
    public class ArtistSeed
    {
        public static async Task Seed(AudioStreamingDbContext context)
        {
            if (!context.Artists.Any())
            {
                var zivert = new Artist()
                {
                    Name = "Zivert",
                    Country = "Russia",
                    Style = "Pop",

                };
                context.Artists.Add(zivert);
            await context.SaveChangesAsync();
            }
            
        }
    }
}
