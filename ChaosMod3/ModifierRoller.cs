using System.Collections.Generic;
using ChaosMod3.Modifiers;
using PluginAPI.Core;
using UnityEngine;

namespace ChaosMod3
{
	public class ModifierRoller
	{
		private static ModifierRoller instance;
		private static readonly object _lock = new();
		
		public static ModifierRoller Instance()
		{
			if (instance is null)
				lock (_lock)
				{
					instance ??= new();
				}

			return instance;
		}
		
		private List<IBase> modifiers = new();
		private IBase oldModifier;
		public int forceNextModifier = -1;

		private ModifierRoller()
		{
			modifiers.Add(new BypassForAll());
		}

		private IBase RollModifier()
		{
			// Roll new modifier
			int modifierIndex = Random.Range(0, modifiers.Count);
			IBase currentModifier;

			// Check if forcemod is set to any number apart from -1
			if (forceNextModifier != -1)
			{
				currentModifier = modifiers[forceNextModifier];
				forceNextModifier = -1;
			}
			else if (false)
			{
				// Force a modifer from config
			}
			else
			{
				// Set a modifer rolled beforehand
				currentModifier = modifiers[modifierIndex];
			}

			oldModifier = currentModifier;
			return currentModifier;
		}

		public void NewModifier()
		{
			RemoveModifier();

			IBase modifier = RollModifier();
			
			modifier.Execute();
			AnnounceNewModifier(modifier);
		}

		private void AnnounceNewModifier(IBase modifier)
		{
			Log.Info($"New modifier: {modifier.Name}");
			Map.Broadcast(5, $"New modifier: {modifier.Name}");
		}

		public void RemoveModifier()
		{
			if (oldModifier != null)
			{
				oldModifier.RevertChanges();
			}
		}
	}
}