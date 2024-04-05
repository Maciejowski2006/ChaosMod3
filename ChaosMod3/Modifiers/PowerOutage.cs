using UnityEngine;

namespace ChaosMod3.Modifiers
{
	public class PowerOutage : IBase
	{
		public string Name { get; } = "Power Outage";

		public void Execute()
		{
			PluginAPI.Core.Map.ChangeColorOfAllLights(new Color(0, 0, 0));
		}

		public void RevertChanges()
		{
			PluginAPI.Core.Map.ResetColorOfAllLights();
		}
	}
}