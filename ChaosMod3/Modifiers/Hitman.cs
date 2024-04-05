using System.Collections.Generic;
using InventorySystem.Items;
using PluginAPI.Core;

namespace ChaosMod3.Modifiers
{
	public class Hitman : IBase
	{
		public string Name { get; } = "Hitman";
		private List<ItemBase> spawnedItems = new();
		public void Execute()
		{
			foreach (Player player in Player.GetPlayers())
			{
				if (player.IsSCP)
					continue;
				
				ItemBase com = player.AddItem(ItemType.GunCOM15);
				spawnedItems.Add(com);
				player.AddAmmo(ItemType.Ammo9x19, 12);
			}
		}
		public void RevertChanges()
		{
			foreach (Player player in Player.GetPlayers())
			{
				player.RemoveItems(ItemType.GunCOM15);
			}
		}
	}
}