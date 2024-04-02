using System.Collections.Generic;

namespace ChaosMod3.Configs
{
	public class AnotherConfig
	{
		public string Test { get; set; } = "Anoter Value";

		public List<string> TestList { get; set; } = new List<string>()
		{
			"Item1", "Item2"
		};
	}
}