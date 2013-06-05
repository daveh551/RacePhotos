using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoServer.Domain;

namespace PhotoServer.DataAccessLayer
{
	public interface IPhotographerDataSource : IDisposable
	{
		IRepository<Photographer, int> Photographers { get; }
		int SaveChanges();
	}
}
