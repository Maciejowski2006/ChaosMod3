using System.Collections.Generic;
using InventorySystem.Items;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Items;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ChaosMod3.Modifiers
{
	public class Hitman : IBase
	{
		public string Name { get; } = "Hitman";
		private List<ItemBase> spawnedItems;
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				if (player.IsSCP)
					continue;
				
				ItemBase com = player.AddItem(ItemType.GunCOM15);
				spawnedItems.Add(com);
			}
		}
		public void RevertChanges()
		{
			foreach (ItemBase com in spawnedItems)
			{
				Item.Remove(com);
			}
		}
	}
}