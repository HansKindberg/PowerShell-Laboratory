using System.Management.Automation;
using HansKindberg.PowerShell.Laboratory.Dependencies;
using IServiceProvider = HansKindberg.PowerShell.Laboratory.DependencyInjection.IServiceProvider;

namespace HansKindberg.PowerShell.Laboratory.Commands
{
	[Cmdlet(VerbsCommon.Show, "LoggingInformation")]
	public class ShowLoggingInformationCommand(IServiceProvider serviceProvider) : BasicCommand
	{
		#region Fields

		private ILoggingInformation? _loggingInformation;

		#endregion

		#region Constructors

		public ShowLoggingInformationCommand() : this(DependencyInjection.ServiceProvider.Instance) { }

		#endregion

		#region Properties

		protected internal virtual ILoggingInformation LoggingInformation => this._loggingInformation ??= this.ServiceProvider.GetLoggingInformation(this);
		protected internal virtual IServiceProvider ServiceProvider => serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

		#endregion

		#region Methods

		protected override void ProcessRecord()
		{
			try
			{
				this.LoggingInformation.Execute();
			}
			catch(MissingMethodException missingMethodException)
			{
				throw new InvalidOperationException(this.MissingMethodExceptionMessage, missingMethodException);
			}
		}

		#endregion
	}
}