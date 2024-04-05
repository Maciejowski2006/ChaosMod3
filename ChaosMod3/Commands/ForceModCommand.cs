using System;
using CommandSystem;
using GameCore;
using Log = PluginAPI.Core.Log;

namespace ChaosMod3.Commands
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class ForceModCommand : ICommand
	{
		public string Command { get; } = "forcemod";

		public string[] Aliases { get; } = new string[] { "fm" };

		public string Description { get; } = "Forces a specified modifier by its ID";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.Count != 1)
			{
				response = "This command requires one argument - Modifier ID. You can get the list of modifiers by invoking 'listmodifiers'";
				return false;
			}

			ushort modifierId = UInt16.Parse(arguments.Array![1]);
			
			if (modifierId >= ModifierRoller.Instance().Modifiers.Count)
			{
				response = "Invalid ID. You can get the list of modifiers by invoking 'listmodifiers'";
				return false;
			}

			ModifierRoller.Instance().ForceNextModifier = modifierId;
			
			response = $"Next modifier set to: \"{ModifierRoller.Instance().Modifiers[modifierId].Name}\"";
			return true;
		}
	}
}