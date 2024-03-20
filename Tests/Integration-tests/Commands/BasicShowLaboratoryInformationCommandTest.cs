using System.Runtime.InteropServices;
using HansKindberg.PowerShell.Laboratory.Commands;

namespace IntegrationTests.Commands
{
	/// <summary>
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/cmdlet.cs
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/ICommandRuntime.cs
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/DefaultCommandRuntime.cs
	/// </summary>
	public abstract class BasicShowLaboratoryInformationCommandTest
	{
		#region Methods

		[Fact]
		public async Task Test()
		{
			await Task.CompletedTask;

			var command = new ShowLaboratoryInformationCommand
			{
				Value = "Test-value"
			};

			var result = command.Invoke();

			Assert.NotNull(result);

			var resultLines = result.OfType<string>().ToList();

			Assert.Equal(4, resultLines.Count);

			Assert.Equal("WriteObject this.Value: Test-value", resultLines.First());
			Assert.Equal($"WriteObject Environment.Version: {Environment.Version}", resultLines[1]);
			Assert.Equal($"WriteObject Environment.OSVersion: {Environment.OSVersion}", resultLines[2]);
			Assert.Equal($"WriteObject RuntimeInformation.IsOSPlatform(OSPlatform.Windows): {RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}", resultLines.Last());
		}

		#endregion
	}
}