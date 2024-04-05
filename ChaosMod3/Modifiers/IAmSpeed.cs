using System.Collections.Generic;
using CustomPlayerEffects;
using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class IAmSpeed : IBase
	{
		public string Name { get; } = "I am speed";
		private List<KeyValuePair<Player, byte>> effects = new();
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				effects.Add(new(player, player.EffectsManager.GetEffect<Scp207>().Intensity));
				player.EffectsManager.EnableEffect<Scp207>(ChaosMod3.Singleton.PluginConfig.Delay);
				player.EffectsManager.ChangeState<Scp207>(4, ChaosMod3.Singleton.PluginConfig.Delay);
			}
		}
		public void RevertChanges()
		{
			foreach (KeyValuePair<Player, byte> effect in effects)
			{
				effect.Key.EffectsManager.EnableEffect<Scp207>().ForceIntensity(effect.Value);
			}
		}
	}
}