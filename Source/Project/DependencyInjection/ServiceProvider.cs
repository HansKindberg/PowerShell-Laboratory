using HansKindberg.PowerShell.Laboratory.Commands;
using HansKindberg.PowerShell.Laboratory.Dependencies;
using HansKindberg.PowerShell.Laboratory.Logging;
using Microsoft.Extensions.Logging;

namespace HansKindberg.PowerShell.Laboratory.DependencyInjection
{
	public class ServiceProvider : IServiceProvider
	{
		#region Properties

		public static ServiceProvider Instance { get; } = new();

		#endregion

		#region Methods

		public virtual ILaboratoryInformation GetLaboratoryInformation(ICommand command)
		{
			return new LaboratoryInformation(this.GetLoggerFactory(command));
		}

		public virtual ILoggerFactory GetLoggerFactory(ICommand command)
		{
			if(command == null)
				throw new ArgumentNullException(nameof(command));

			return new CommandLoggerFactory(command);
		}

		public virtual ILoggingInformation GetLoggingInformation(ICommand command)
		{
			return new LoggingInformation(this.GetLoggerFactory(command));
		}

		#endregion
	}
}