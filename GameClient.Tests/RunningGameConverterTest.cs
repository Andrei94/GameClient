using System.Windows.Data;
using GameClient.MainProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Tests
{
	[TestClass]
	public class RunningGameConverterTest
	{
		private IValueConverter converter;

		[TestInitialize]
		public void SetUp()
		{
			converter = new RunningGameConverter();
		}

		[TestMethod]
		public void ConvertRunningGame()
		{
			Assert.AreEqual("Playing game1", Convert(new RunningGameInfo("game1")));
			Assert.AreEqual("Playing game1 for 2m", Convert(new RunningGameInfo("game1", 2)));
			Assert.AreEqual("Playing game1 for 1d 9h 20m", Convert(new RunningGameInfo("game1", 2000)));
		}

		[TestMethod]
		public void ConvertTextToEmptyString()
		{
			Assert.AreEqual(string.Empty, Convert(ToString()));
		}

		[TestMethod]
		public void ConvertNullToEmptyString()
		{
			Assert.AreEqual(string.Empty, Convert(null));
		}

		private string Convert(object value)
		{
			return (string) converter.Convert(value, null, null, null);
		}
	}
}
