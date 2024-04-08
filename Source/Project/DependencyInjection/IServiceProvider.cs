using HansKindberg.PowerShell.Laboratory.Commands;
using HansKindberg.PowerShell.Laboratory.Dependencies;
using Microsoft.Extensions.Logging;

namespace HansKindberg.PowerShell.Laboratory.DependencyInjection
{
	public interface IServiceProvider
	{
		#region Methods

		ILaboratoryInformation GetLaboratoryInformation(ICommand command);
		ILoggerFactory GetLoggerFactory(ICommand command);
		ILoggingInformation GetLoggingInformation(ICommand command);

		#endregion
	}
}