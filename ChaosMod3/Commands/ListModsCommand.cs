using System;
using System.Collections.Generic;
using ChaosMod3.Modifiers;
using CommandSystem;
using GameCore;
using Log = PluginAPI.Core.Log;

namespace ChaosMod3.Commands
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class ListModsCommand : ICommand
	{
		public string Command { get; } = "listmodifiers";

		public string[] Aliases { get; } = new string[] { "listmods", "lm" };

		public string Description { get; } = "Lists all available modifiers";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "List of available modifiers:\n";
			IReadOnlyList<IBase> modifiers = ModifierRoller.Instance().Modifiers;
			for (int i = 0; i < modifiers.Count; i++)
			{

				response += $"{i} - {modifiers[i].Name}\n";
			}
			return true;
		}
	}
}