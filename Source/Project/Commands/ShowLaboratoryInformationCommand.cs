using System.Management.Automation;
using System.Runtime.InteropServices;
using HansKindberg.PowerShell.Laboratory.Dependencies;
using IServiceProvider = HansKindberg.PowerShell.Laboratory.DependencyInjection.IServiceProvider;

namespace HansKindberg.PowerShell.Laboratory.Commands
{
	[Cmdlet(VerbsCommon.Show, "LaboratoryInformation")]
	public class ShowLaboratoryInformationCommand(IServiceProvider serviceProvider) : BasicCommand
	{
		#region Fields

		private ILaboratoryInformation? _laboratoryInformation;

		#endregion

		#region Constructors

		public ShowLaboratoryInformationCommand() : this(DependencyInjection.ServiceProvider.Instance) { }

		#endregion

		#region Properties

		protected internal virtual ILaboratoryInformation LaboratoryInformation => this._laboratoryInformation ??= this.ServiceProvider.GetLaboratoryInformation(this);
		protected internal virtual IServiceProvider ServiceProvider => serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

		[Parameter(Position = 0, Mandatory = false)]
		public virtual string? Value { get; set; }

		#endregion

		#region Methods

		protected override void ProcessRecord()
		{
			try
			{
				this.WriteObject($"WriteObject: CommandOrigin = {this.CommandOrigin}");
				this.WriteObject($"WriteObject: CommandRuntime = {this.CommandRuntime}");
				this.WriteObject($"WriteObject: CommandRuntime is ICommandRuntime2 = {this.CommandRuntime is ICommandRuntime2}");

				this.WriteObject($"WriteObject - this.Value: {this.Value}");
				this.WriteObject($"WriteObject - Environment.Version: {Environment.Version}");
				this.WriteObject($"WriteObject - Environment.OSVersion: {Environment.OSVersion}");
				this.WriteObject($"WriteObject - RuntimeInformation.IsOSPlatform(OSPlatform.Windows): {RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}");

				this.WriteCommandDetail($"WriteCommandDetail - this.Value: {this.Value}");
				this.WriteDebug("WriteDebug - Debug");
				this.WriteError(new ErrorRecord(new InvalidOperationException("WriteError - Exception"), "Error-id", ErrorCategory.NotSpecified, this));
				this.WriteInformation(new InformationRecord("WriteInformation - MessageData", "Source"));
				this.WriteInformation("WriteInformation - MessageData", ["First tag"]);
				this.WriteProgress(new ProgressRecord(1, "Activity", "Status-description"));
				this.WriteVerbose("WriteVerbose - Verbose");
				this.WriteWarning("WriteWarning - Warning");

				var value = this.LaboratoryInformation.Get(this.Value);

				this.WriteObject($"WriteObject - value from laboratory-information: {value}");
			}
			catch(MissingMethodException missingMethodException)
			{
				throw new InvalidOperationException(this.MissingMethodExceptionMessage, missingMethodException);
			}
		}

		#endregion
	}
}