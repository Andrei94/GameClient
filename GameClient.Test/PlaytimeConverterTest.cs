using System;
using System.Globalization;
using GameClient.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Test
{
	[TestClass]
	public class PlaytimeConverterTest
	{
		[TestMethod]
		public void ConvertMinutes()
		{
			var x = new PlaytimeConverter();
			Assert.AreEqual("5h 23m", x.Convert(323, null, null, CultureInfo.CurrentCulture));
		}
	}
}
