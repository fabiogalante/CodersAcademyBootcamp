using CodersAcademyBootcamp.Crosscutting.Entity;
using CodersAcademyBootcamp.Domain.Album.ValueObject;
using System;
using System.Text.Json.Serialization;

namespace CodersAcademyBootcamp.Domain.Album
{
    public class Music : Entity<Guid>, IDomain<Music>
    {
        public String Name { get; set; }
        public Duration Duration { get; set; }
    }
}
