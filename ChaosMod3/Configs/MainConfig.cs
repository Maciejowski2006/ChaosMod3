using System.Collections.Generic;
using System.ComponentModel;

namespace ChaosMod3.Configs
{
	public class MainConfig
	{
		[Description("Time between new events (in seconds)")]
		public int Delay { get; set; } = 60;
		
		[Description("Force a selected modification to always be rolled:\n" +
		             " #  -1 - don't force\n" +
		             " #   0 - Who needs keycards anyway\n" +
		             " #   1 - Fuck 079 in particular\n" +
		             " #   2 - Ghost Party\n" +
		             " #   3 - Hitman\n" +
		             " #   4 - I AM FREE\n" +
		             " #   5 - I am speed\n" +
		             " #   6 - Infinite power\n" +
		             " #   7 - 94 in 6\n" +
		             " #   8 - Power outage\n" +
		             " #   9 - Skinny Bois\n" +
		             " #   6 - Swap It\n" +
		             " #   10 - Zombie Apocalypse")]
		public int ForceMod { get; set; } = -1; 
		public string StringValue { get; set; } = "Test";
		public int IntValue { get; set; } = 100;

		public Dictionary<string, string> DictionaryValue { get; set; } = new Dictionary<string, string>()
		{
			{ "Value1", "Param1" },
			{ "Value2", "Param2" },
		};
	}
}