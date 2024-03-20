namespace IntegrationTests
{
	public static class Global
	{
		#region Fields

		public static readonly DirectoryInfo ProjectDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.Parent?.Parent!;

		#endregion
	}
}