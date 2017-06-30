using System.Threading.Tasks;

namespace GameClient.Processes
{
	public class Delayer
	{
		public virtual Task Delay(int miliseconds)
		{
			return Task.Delay(miliseconds);
		}
	}
}
