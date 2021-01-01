using CodersAcademyBootcamp.Domain.Album;
using CodersAcademyBootcamp.Domain.Album.Repository;
using CodersAcademyBootcamp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Repository.Repository
{
    public class AlbumRepository : UnitOfWork<Album>, IAlbumRepository
    {
        public AlbumRepository(ContextApp context) : base(context)
        {

        }


    }
}
