using System.Management.Automation;

namespace HansKindberg.PowerShell.Laboratory.Commands
{
	public abstract class BasicCommand : Cmdlet, ICommand
	{
		#region Fields

		private const string _missingMethodExceptionMessage = "A method is missing. Make sure you have .NET Framework 4.6.2 or .NET Core 3.0 or .NET 5.0, or higher, installed. This PowerShell-module is built with .NET Standard 2.0.";

		#endregion

		#region Properties

		protected internal virtual string MissingMethodExceptionMessage => _missingMethodExceptionMessage;

		#endregion
	}
}