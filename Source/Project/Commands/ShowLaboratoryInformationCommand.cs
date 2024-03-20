using System.Management.Automation;
using System.Runtime.InteropServices;

namespace HansKindberg.PowerShell.Laboratory.Commands
{
	[Cmdlet(VerbsCommon.Show, "LaboratoryInformation")]
	public class ShowLaboratoryInformationCommand : Cmdlet
	{
		#region Fields

		// ReSharper disable ConvertToConstant.Local
		private static readonly string _dependency = "Dependency value"; // Example for using dependency.
		// ReSharper restore ConvertToConstant.Local

		private const string _missingMethodExceptionMessage = "A method is missing. Make sure you have .NET Framework 4.6.2 or .NET Core 3.0 or .NET 5.0, or higher, installed. This PowerShell-module is built with .NET Standard 2.0.";

		#endregion

		#region Constructors

		public ShowLaboratoryInformationCommand() : this(_dependency) { }

		protected internal ShowLaboratoryInformationCommand(string dependency)
		{
			this.Dependency = dependency ?? throw new ArgumentNullException(nameof(dependency));
		}

		#endregion

		#region Properties

		protected internal virtual string Dependency { get; }
		protected internal virtual string MissingMethodExceptionMessage => _missingMethodExceptionMessage;

		[Parameter(Position = 0, Mandatory = false)]
		public virtual string? Value { get; set; }

		#endregion

		#region Methods

		protected override void ProcessRecord()
		{
			try
			{
				this.WriteObject($"WriteObject this.Value: {this.Value}");
				this.WriteObject($"WriteObject Environment.Version: {Environment.Version}");
				this.WriteObject($"WriteObject Environment.OSVersion: {Environment.OSVersion}");
				this.WriteObject($"WriteObject RuntimeInformation.IsOSPlatform(OSPlatform.Windows): {RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}");
				this.WriteCommandDetail($"WriteCommandDetail this.Value: {this.Value}");
				this.WriteDebug("Debug");
				this.WriteVerbose("Verbose");
				this.WriteWarning("Warning");
			}
			catch(MissingMethodException missingMethodException)
			{
				throw new InvalidOperationException(this.MissingMethodExceptionMessage, missingMethodException);
			}
		}

		#endregion
	}
}