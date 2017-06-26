using System.Threading.Tasks;

namespace GameClient.Game
{
	public class Delayer
	{
		public virtual Task Delay(int miliseconds)
		{
			return Task.Delay(miliseconds);
		}
	}
}
