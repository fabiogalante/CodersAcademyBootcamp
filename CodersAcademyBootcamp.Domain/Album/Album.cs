using CodersAcademyBootcamp.Crosscutting.Entity;
using CodersAcademyBootcamp.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;

namespace CodersAcademyBootcamp.Domain.Album
{
    public class Album : Entity<Guid>, IDomain<Album>
    {
        public string Name{ get; set; }
        public String Description { get; set; }
        public String Backdrop { get; set; }
        public Band Band { get; set; }
        public virtual IList<Music> Musics { get; set; }
    }
}
