using System.Management.Automation;
using HansKindberg.PowerShell.Laboratory.Commands;
using Tests.Helpers.Management.Automation.Extensions;
using Tests.Mocks.Management.Automation;

namespace IntegrationTests.Commands
{
	/// <summary>
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/cmdlet.cs
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/ICommandRuntime.cs
	/// - https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/DefaultCommandRuntime.cs
	/// </summary>
	public class ShowLaboratoryInformationCommandTest
	{
		#region Methods

		private static ShowLaboratoryInformationCommand CreateCommand(ICommandRuntime? commandRuntime = null, string? value = null)
		{
			var command = new ShowLaboratoryInformationCommand
			{
				CommandRuntime = commandRuntime,
				Value = value
			};

			command.PrepareForTest();

			return command;
		}

		[Fact]
		public async Task ProcessRecord_IfDefaultCommandRuntime_ShouldThrowAnInvalidOperationException()
		{
			await Task.CompletedTask;

			var command = CreateCommand(null, "Test-value");

			Assert.Throws<InvalidOperationException>(() => command.Invoke<object>().ToArray());
		}

		[Fact]
		public async Task ProcessRecord_IfICommandRuntime_ShouldThrowANotImplementedException()
		{
			await Task.CompletedTask;

			var command = CreateCommand(new CommandRuntimeMock(), "Test-value");
			Assert.Throws<NotImplementedException>(() => command.Invoke<object>().ToArray());
		}

		[Fact]
		public async Task ProcessRecord_IfICommandRuntime2_ShouldWriteToTheCommandRuntime()
		{
			await Task.CompletedTask;

			var commandRuntime = new CommandRuntime2Mock();
			var command = CreateCommand(commandRuntime, "Test-value");
			var result = command.Invoke<object>().ToArray();

			Assert.NotNull(result);
			Assert.Empty(result);

			Assert.Single(commandRuntime.CommandDetails);
			Assert.Equal(2, commandRuntime.Debugs.Count);
			Assert.Single(commandRuntime.Errors);
			Assert.Equal(2, commandRuntime.Informations.Count);
			Assert.Equal(8, commandRuntime.Objects.Count);
			Assert.Single(commandRuntime.Progresses);
			Assert.Single(commandRuntime.Verboses);
			Assert.Single(commandRuntime.Warnings);
		}

		#endregion
	}
}