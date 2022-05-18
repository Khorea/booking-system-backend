using System.ComponentModel;

namespace BookingSystemBackend.Utils
{
	public class Enums
	{
		public enum CarType
		{
			[Description("First Class")]
			FirstClass,
			[Description("Second Class")]
			SecondClass,
			[Description("First Class Sleeper")]
			Sleeper,
			[Description("Couchette")]
			Couchette
		}
	}
}
