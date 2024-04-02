using System.Collections.Generic;
using ChaosMod3.Configs;
using ChaosMod3.Factory;
using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace ChaosMod3
{ 
	public class ChaosMod3
	{
		public static ChaosMod3 Singleton { get; private set; }

		[PluginPriority(LoadPriority.Highest)]
		[PluginEntryPoint("Chaos Mod 3", "1.0.0", "3rd iteration of original Chaos Mod written for SCP: SL, inspired by Chaos Mod for GTA San Andreas/V", "Maciejowski")]
		void LoadPlugin()
		{
			Singleton = this;
			Log.Info("Loaded plugin, register events...");
			PluginAPI.Events.EventManager.RegisterEvents(this);
			PluginAPI.Events.EventManager.RegisterEvents<EventHandlers>(this);
			Log.Info($"Registered events, config &2&b{PluginConfig.IntValue}&B&r, register factory...");
			FactoryManager.RegisterPlayerFactory(this, new MyPlayerFactory());
			Log.Info("Registered player factory!");
			var handler = PluginHandler.Get(this);
			Log.Info(handler.PluginName);
			Log.Info(handler.PluginFilePath);
			Log.Info(handler.PluginDirectoryPath);
			
			List<string> modules = new List<string>()
			{
				"something1",
			};

			foreach (var module in modules)
			{
				if (!PluginConfig.DictionaryValue.ContainsKey(module))
				{
					PluginConfig.DictionaryValue.Add(module, "yes");
					handler.SaveConfig(this, nameof(PluginConfig));
				}
			}
			
			PluginConfig.StringValue = "test Value";
			handler.SaveConfig(this, nameof(PluginConfig));

			AnotherConfig.TestList = new List<string>() { "Template0" };
			handler.SaveConfig(this, nameof(AnotherConfig));
		}

		private bool roundEnded;
		private CoroutineHandle coroutine;
		
		[PluginEvent(ServerEventType.RoundStart)]
		void OnRoundStart()
		{
			coroutine = Timing.RunCoroutine(ChaosLoop());
		}

		[PluginEvent(ServerEventType.RoundEnd)]
		void OnRoundEnd(RoundSummary.LeadingTeam team)
		{
			Timing.KillCoroutines(coroutine);
		}

		private IEnumerator<float> ChaosLoop()
		{
			ModifierRoller api = ModifierRoller.Instance();

			while (!roundEnded)
			{
				yield return Timing.WaitForSeconds(60);
				api.NewModifier();
			}

			api.RemoveModifier();
			roundEnded = false;
		}
		
		
		[PluginConfig] public MainConfig PluginConfig;

		[PluginConfig("configs/another-config.yml")]
		public AnotherConfig AnotherConfig;
	}
}