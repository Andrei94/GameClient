using System.Windows.Data;
using GameClient.MainProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Tests
{
	[TestClass]
	public class PlaytimeConverterTest
	{
		private IValueConverter converter;

		[TestInitialize]
		public void SetUp()
		{
			converter = new PlaytimeConverter();
		}

		[TestMethod]
		public void ConvertMinutes()
		{
			Assert.AreEqual("23m", Convert(23));
		}

		[TestMethod]
		public void ConvertHours()
		{
			Assert.AreEqual("5h", Convert(300));
			Assert.AreEqual("5h 23m", Convert(323));
		}

		[TestMethod]
		public void ConvertDays()
		{
			Assert.AreEqual("2d 3m", Convert(2883));
			Assert.AreEqual("2d 15h", Convert(3780));
			Assert.AreEqual("2d 15h 3m", Convert(3783));
		}

		private string Convert(int minutes)
		{
			return (string) converter.Convert(minutes, null, null, null);
		}

		[TestMethod]
		public void ConvertNumberAsString()
		{
			Assert.AreEqual(string.Empty, converter.Convert("0", null, null, null));
		}

		[TestMethod]
		public void ConvertTextToNumber()
		{
			Assert.AreEqual("0", converter.Convert(ToString(), null, null, null));
		}

		[TestMethod]
		public void ConvertNullToNumber()
		{
			Assert.AreEqual("0", converter.Convert(null, null, null, null));
		}
	}
}
