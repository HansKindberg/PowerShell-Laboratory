using HansKindberg.PowerShell.Laboratory.Commands;
using HansKindberg.PowerShell.Laboratory.Logging;
using Microsoft.Extensions.Logging;

namespace Tests.Logging
{
	public class CommandLoggerTest
	{
		#region Methods

		[Fact]
		public async Task Log_ShouldUseTheCommandToWrite()
		{
			await Task.CompletedTask;

			// This first test section is for verifying that no exception is thrown.
			var command = new ShowLaboratoryInformationCommand();
			var commandLoggerFactory = new CommandLoggerFactory(command);
			var commandLogger = commandLoggerFactory.CreateLogger(command.GetType());
			Assert.NotNull(commandLogger);
			//Global.InvokeCommand(loggerCommand);

			//var loggerCommandMock = new LoggerCommandMock();
			//commandLoggerFactory = new CommandLoggerFactory(loggerCommandMock);
			//commandLogger = commandLoggerFactory.CreateLogger(loggerCommandMock.GetType());
			//Assert.NotNull(commandLogger);
			//Assert.Empty(loggerCommandMock.Debug);
			//Assert.Empty(loggerCommandMock.Information);
			//Assert.Empty(loggerCommandMock.Trace);
			//Assert.Empty(loggerCommandMock.Warning);
			//Global.InvokeCommand(loggerCommandMock);
			//Assert.Equal(2, loggerCommandMock.Debug.Count);
			//Assert.Equal(6, loggerCommandMock.Information.Count);
			//Assert.Equal(2, loggerCommandMock.Trace.Count);
			//Assert.Equal(2, loggerCommandMock.Warning.Count);
		}

		#endregion
	}
}