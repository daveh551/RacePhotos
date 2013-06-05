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
	public class RaceDataSource : DbContext, IRaceDataSource

	{
		private DbSet<Race> _raceDataSet;
		private DbSet<Event> _eventDataSet;
		private DbSet<Distance> _distanceDataSet;
		public DbSet<Race> RaceDataSet { get { return _raceDataSet; } }
		public DbSet<Event> EventDataSet { get { return _eventDataSet; } }
		public DbSet<Distance> DistanceDataSet { get { return _distanceDataSet; } }

		private IRepository<Race, int> _raceData;
		private IRepository<Event, int> _eventData;
		private IRepository<Distance, int> _distanceData; 
		public IRepository<Race, int> Races { get { return _raceData; } }
		public IRepository<Event, int> Events { get { return _eventData; } }
		public IRepository<Distance, int> Distances { get { return _distanceData; } } 

		public RaceDataSource() : this("DefaultConnection")
		{
		}

		public RaceDataSource(string connectionString) : base(connectionString)
		{
			_raceDataSet = Set<Race>();
			_raceData = new RaceRepository(_raceDataSet);
			_eventDataSet = Set<Event>();
			_eventData = new EventRepository(_eventDataSet);
			_distanceDataSet = Set<Distance>();
			_distanceData = new DistanceRepository(_distanceDataSet);

		}


		public void Update(object item)
		{
			Entry(item).State = EntityState.Modified;
		}
	}
}
