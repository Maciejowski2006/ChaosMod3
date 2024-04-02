using PlayerRoles;
using PluginAPI.Core;
using UnityEngine;

namespace ChaosMod3.Modifiers
{
	public class SkinnyBois : IBase
	{
		public string Name { get; } = "Skinny bois";
		public void Execute()
		{
			foreach (var player in Player.GetPlayers())
			{
				if (player.Role == RoleTypeId.Scp939)
					continue;
				
				player.GameObject.transform.localScale = new Vector3(.25f, 1, .25f);
			}
		}
		public void RevertChanges()
		{
			foreach (var player in Player.GetPlayers())
			{
				player.GameObject.transform.localScale = new Vector3(1f, 1, 1f);
			}
		}
	}
}