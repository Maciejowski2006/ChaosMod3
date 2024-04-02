using System.Collections.Generic;
using CustomPlayerEffects;
using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class IAmSpeed : IBase
	{
		public string Name { get; } = "I am speed";
		public void Execute()
		{
			foreach (var player in Player.GetPlayers())
			{
				Scp207 t = player.EffectsManager.EnableEffect<Scp207>(60);
				
			}
		}
		public void RevertChanges()
		{
			foreach (var player in Player.GetPlayers())
			{
				player.EffectsManager.DisableEffect<Scp207>();
			}
		}
	}
}