using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class InfinitePower : IBase
	{
		public string Name { get; } = "Infinite power";
		public void Execute()
		{
			foreach (TeslaGate tesla in Map.TeslaGates)
			{
				tesla.windupTime = 0f;
				tesla.cooldownTime = 0;
			}
		}
		public void RevertChanges()
		{
			foreach (TeslaGate tesla in Map.TeslaGates)
			{
				tesla.windupTime = 1f;
				tesla.cooldownTime = 1f;
			}
		}
	}

}