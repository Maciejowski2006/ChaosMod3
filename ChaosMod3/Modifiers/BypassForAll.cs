using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class BypassForAll : IBase
	{
		public string Name { get; } = "Who needs keycards anyway?";
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				player.IsBypassEnabled = true;
			}
		}

		public void RevertChanges()
		{
			foreach (Player player in Player.GetPlayers())
			{
				player.IsBypassEnabled = false;
			}
		}
	}
}