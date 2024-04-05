using System.Collections.Generic;
using PluginAPI.Core;
using UnityEngine;

namespace ChaosMod3.Modifiers
{
	public class GhostParty : IBase
	{
		public string Name { get; } = "Ghost Party";
		private List<MeshRenderer> meshRenderers = new();
		public void Execute()
		{
			Player.GetPlayers().ForEach(player => { meshRenderers.Add(player.GameObject.GetComponent<MeshRenderer>()); });

			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				meshRenderer.enabled = false;
			}
		}
		public void RevertChanges()
		{
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				meshRenderer.enabled = true;
			}
		}
	}
}