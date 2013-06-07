using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoServer.Domain;

namespace PhotoServer.DataAccessLayer
{
	public class MasterDbContext : DbContext
	{
		public DbSet<Race> Races { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Distance> Distances { get; set;}
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Photographer> Photographers { get; set; }
	}
}
