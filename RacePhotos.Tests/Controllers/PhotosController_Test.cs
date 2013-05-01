using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
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
			//Act
			var result = target.List();
			//Assert
			Assert.AreEqual(expected, result, "failure message");
		}

		#endregion
	}
}
