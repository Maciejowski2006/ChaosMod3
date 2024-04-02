using System.Collections.Generic;
using Footprinting;
using PlayerRoles;
using PlayerStatsSystem;
using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class ZombieApocalypse : IBase
	{
		public string Name { get; } = "Zombie Apocalypse";
		private List<Player> zombiesSpawned = new();
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				if (player.Role == RoleTypeId.Spectator)
				{
					zombiesSpawned.Add(player);
					player.SetRole(RoleTypeId.Scp0492, RoleChangeReason.Revived);
				}
			}
		}

		public void RevertChanges()
		{
			foreach (Player player in zombiesSpawned)
			{
				if (player.Role == RoleTypeId.Scp0492)
				{
					player.Damage(new DisruptorDamageHandler(new Footprint(player.ReferenceHub), 1000));
					// player.Vaporize();
				}
			}
		}
	}
}