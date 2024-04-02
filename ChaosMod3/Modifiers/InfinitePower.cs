using ChaosMod3.Commands;

namespace ChaosMod3.Modifiers
{
	public class InfinitePower : IBase
	{
		public string Name { get; } = "Infinite power";
		public void Execute()
		{
			foreach (var tesla in PluginAPI.Core.Map.TeslaGates)
			{
				tesla.windupTime = 0f;
				tesla.cooldownTime = 0;
			}
		}
		public void RevertChanges()
		{
			foreach (var tesla in PluginAPI.Core.Map.TeslaGates)
			{
				tesla.windupTime = 1f;
				tesla.cooldownTime = 1f;
			}
		}
	}

}