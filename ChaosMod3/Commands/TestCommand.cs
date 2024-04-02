using System;
using CommandSystem;

namespace ChaosMod3.Commands
{
	public class TestCommand : ICommand
	{
		public string Command { get; } = "test";

		public string[] Aliases { get; } = new string[] { "tstcmd", "testcommand" };

		public string Description { get; } = "Test command.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "Success response";
			return true;
		}
	}
}