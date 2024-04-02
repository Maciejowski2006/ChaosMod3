using System;
using PluginAPI.Core;
using PluginAPI.Core.Factories;
using PluginAPI.Core.Interfaces;

namespace ChaosMod3.Factory
{
	public class MyPlayerFactory : PlayerFactory
	{
		public override Type BaseType { get; } = typeof(MyPlayer);

		public override Player Create(IGameComponent component)
		{
			if (component is ReferenceHub hub && hub.isLocalPlayer)
				return new Server(hub);

			return new MyPlayer(component);
		}
	}
}