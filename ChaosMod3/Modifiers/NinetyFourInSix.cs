using System.Collections.Generic;
using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class NinetyFourInSix : IBase
	{
		public string Name { get; } = "94 in 6...";
		public void Execute()
		{
			foreach (var player in Player.GetPlayers())
			{
				if (player.IsSCP)
					return;
				
				player.Health = 1;
				player.ArtificialHealth = 0;
				
			}
		}
		public void RevertChanges()
		{
			foreach (var player in Player.GetPlayers())
			{
				if (player.IsSCP)
					return;
				
				player.Health = player.MaxHealth;
			}
		}
	}
}