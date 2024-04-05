using PluginAPI.Core;
using UnityEngine;

namespace ChaosMod3.Modifiers
{
	public class PowerOutage : IBase
	{
		public string Name { get; } = "Power Outage";

		public void Execute()
		{
			Map.FlickerAllLights(ChaosMod3.Singleton.PluginConfig.Delay);
		}

		public void RevertChanges()
		{
		}
	}
}