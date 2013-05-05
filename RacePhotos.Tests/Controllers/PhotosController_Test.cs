using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using NUnit.Framework;
using RacePhotos.Controllers;
using RacePhotosTestSupport;

namespace RacePhotos.Tests.Controllers
{
	[TestFixture]
	public class PhotosController_Test
	{
		#region SetUp / TearDown

		
		[SetUp]
		public void Init()
		{ }

		[TearDown]
		public void Dispose()
		{ }

		#endregion

		#region Tests


		[Test]
		public void List_NoRaceSetInSession_ReturnsRedirectToRacesController()
		{
			//Arrange
			string expected = "ReturnsRedirectToRacesController";
			var target = new PhotosController(new FakeDataSource());
			target.ControllerContext = new ControllerContext(new FakeHttpContext(), new RouteData(), target);
			var httpContext = target.ControllerContext.HttpContext;
			
			//Act
			var result = target.List();
			//Assert
			Assert.IsInstanceOf<RedirectToRouteResult>(result);
		}

		#endregion
	}
}
