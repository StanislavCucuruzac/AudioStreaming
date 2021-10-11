using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Dal.Repository;
using AudioStreaming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationalTests.Mock
{
    public class ArtistRepositoryMock : IRepo<Artist>
    {

        private IEnumerable<Artist> artists = new List<Artist>()
        {
             new Artist
                {
                    Id = 1,
                    Name = "Billie Elish",
                    Country = "USA",
                    Style = "Pop"
                },
                 new Artist
                {
                    Id = 2,
                    Name = "Morgenstern",
                    Country = "Russia",
                    Style = "Rap"
                },
                  new Artist
                {
                    Id = 3,
                    Name = "Drake",
                    Country = "USA",
                    Style = "Pop"
                }

            };

        public Task<Artist> Add(Artist entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<Artist, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> FirstOrDefault(Expression<Func<Artist, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artist>> GetAll()
        {
            return Task.FromResult(artists);
        }

        public Task<Artist> GetById(int id)
        {
            return Task.FromResult(artists.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Artist>> GetWhere(Expression<Func<Artist, bool>> predicate, params Expression<Func<Artist, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artist>> GetWithInclude(params Expression<Func<Artist, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Artist entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Artist entityToUpdate, Artist entity)
        {
            throw new NotImplementedException();
        }
    }
}
