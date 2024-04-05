using System.Collections.Generic;
using PluginAPI.Core;
using UnityEngine;

namespace ChaosMod3.Modifiers
{
	public class SwapIt : IBase
	{
		public string Name { get; } = "Swap it!";
		public void Execute()
		{
			List<Player> players = Player.GetPlayers();
			List<Vector3> positions = new();
			players.ForEach(p => { positions.Add(p.Position); });

			int j = players.Count;
			foreach (Player player in players)
			{
				player.Position = positions[j];
				j--;
			}
		}

		public void RevertChanges()
		{
		}
	}
}