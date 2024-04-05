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
		
		public List<IBase> Modifiers { get; } = new();
		private IBase oldModifier;
		public int ForceNextModifier = -1;

		private ModifierRoller()
		{
			Modifiers.Add(new BypassForAll());
			// Modifiers.Add(new Fuck079InParticular());
			// modifiers.Add(new GhostParty());
			Modifiers.Add(new Hitman());
			Modifiers.Add(new IAmFree());
			Modifiers.Add(new IAmSpeed());
			Modifiers.Add(new InfinitePower());
			Modifiers.Add(new NinetyFourInSix());
			Modifiers.Add(new PowerOutage());
			// modifiers.Add(new SkinnyBois());
			// modifiers.Add(new SwapIt());
		}

		private IBase RollModifier()
		{
			// Roll new modifier
			int modifierIndex = Random.Range(0, Modifiers.Count - 1);
			IBase currentModifier;

			// Check if forcemod is set to any number apart from -1
			if (ForceNextModifier != -1)
			{
				currentModifier = Modifiers[ForceNextModifier];
				ForceNextModifier = -1;
			}
			else if (ChaosMod3.Singleton.PluginConfig.ForceMod != -1)
			{
				// Force a modifer from config
				currentModifier = Modifiers[ChaosMod3.Singleton.PluginConfig.ForceMod];
			}
			else
			{
				// Set a modifer rolled beforehand
				currentModifier = Modifiers[modifierIndex];
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