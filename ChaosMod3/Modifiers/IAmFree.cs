using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class IAmFree : IBase
	{
		public string Name { get; } = "I AM FREEEEE!";
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				player.IsDisarmed = false;
			}
		}

		public void RevertChanges()
		{
		}
	}
}