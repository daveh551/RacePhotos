using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoServer.Domain;

namespace PhotoServer.DataAccessLayer
{
	public class PhotographerDataSource : DbContext,  IPhotographerDataSource
	{
		private DbSet<Photographer> _photographerDataSet;
		public DbSet<Photographer> PhotographerDataSet { get { return _photographerDataSet; } }
		private IRepository<Photographer, int> _photographerData;

		public IRepository<Domain.Photographer, int> Photographers
		{
			get { return _photographerData; }
		}

		public PhotographerDataSource() : this ("DefaultConnection")
		{
			
		}
		public PhotographerDataSource(string connectionString) : base(connectionString)
		{
			_photographerDataSet = Set<Photographer>();
			_photographerData = new PhotographerRepository(_photographerDataSet);

		}


		public void Update(object item)
		{
			Entry(item).State = EntityState.Modified;
		}
	}
}
