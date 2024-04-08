using System.Management.Automation;
using HansKindberg.PowerShell.Laboratory.Commands;
using Tests.Helpers.Management.Automation.Extensions;
using Tests.Mocks.Management.Automation;

namespace IntegrationTests.Commands
{
	public class ShowLoggingInformationCommandTest
	{
		#region Methods

		private static ShowLoggingInformationCommand CreateCommand(ICommandRuntime? commandRuntime = null)
		{
			var command = new ShowLoggingInformationCommand
			{
				CommandRuntime = commandRuntime
			};

			command.PrepareForTest();

			return command;
		}

		[Fact]
		public async Task ProcessRecord_IfDefaultCommandRuntime_ShouldThrowAnException()
		{
			await Task.CompletedTask;

			var command = CreateCommand();

			Assert.Throws<Exception>(() => command.Invoke<object>().ToArray());
		}

		[Fact]
		public async Task ProcessRecord_IfICommandRuntime_ShouldThrowANotImplementedException()
		{
			await Task.CompletedTask;

			var command = CreateCommand(new CommandRuntimeMock());
			Assert.Throws<NotImplementedException>(() => command.Invoke<object>().ToArray());
		}

		[Fact]
		public async Task ProcessRecord_IfICommandRuntime2_ShouldWriteLogsToTheCommandRuntime()
		{
			await Task.CompletedTask;

			var commandRuntime = new CommandRuntime2Mock();
			var command = CreateCommand(commandRuntime);
			var result = command.Invoke<object>().ToArray();

			Assert.NotNull(result);
			Assert.Empty(result);

			Assert.Equal(2, commandRuntime.Debugs.Count);
			Assert.Equal(4, commandRuntime.Errors.Count);
			Assert.Equal(2, commandRuntime.Informations.Count);
			Assert.Equal(2, commandRuntime.Verboses.Count);
			Assert.Equal(2, commandRuntime.Warnings.Count);
		}

		#endregion
	}
}