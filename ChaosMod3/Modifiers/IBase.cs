namespace ChaosMod3.Modifiers
{
	public interface IBase
	{
		public string Name { get; }
		public void Execute();
		public void RevertChanges();
	}
}