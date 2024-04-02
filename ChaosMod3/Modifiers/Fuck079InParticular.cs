

using MapGeneration.Distributors;

namespace ChaosMod3.Modifiers
{
	public class Fuck079InParticular : IBase
	{
		public string Name { get; } = "Fuck 079 in particular";
		public void Execute()
		{
			foreach (Scp079Generator generator in PluginAPI.Core.Map.Generators)
			{
				if (!generator.Engaged)
				{
					generator.IsUnlocked = true;
					generator.Activating = true;
				}
			}
		}

		public void RevertChanges()
		{
			foreach (Scp079Generator generator in PluginAPI.Core.Map.Generators)
			{
				if (!generator.Engaged)
				{
					generator.IsUnlocked = true;
					generator.Activating = false;
				}
			}
		}
	}
}