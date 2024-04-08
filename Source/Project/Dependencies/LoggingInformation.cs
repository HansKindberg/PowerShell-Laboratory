using Microsoft.Extensions.Logging;

namespace HansKindberg.PowerShell.Laboratory.Dependencies
{
	public class LoggingInformation : ILoggingInformation
	{
		#region Constructors

		public LoggingInformation(ILoggerFactory loggerFactory)
		{
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
		}

		#endregion

		#region Properties

		protected internal virtual ILogger Logger { get; }

		#endregion

		#region Methods

		public virtual void Execute()
		{
			this.Logger.LogCritical("Critical message");
			this.Logger.LogCritical(new InvalidOperationException("Critical exception"), "Critical message");

			this.Logger.LogDebug("Debug message");
			this.Logger.LogDebug(new InvalidOperationException("Debug exception"), "Debug message");

			this.Logger.LogError("Error message");
			this.Logger.LogError(new InvalidOperationException("Error exception"), "Error message");

			this.Logger.LogInformation("Information message");
			this.Logger.LogInformation(new InvalidOperationException("Information exception"), "Information message");

			this.Logger.LogTrace("Trace message");
			this.Logger.LogTrace(new InvalidOperationException("Trace exception"), "Trace message");

			this.Logger.LogWarning("Warning message");
			this.Logger.LogWarning(new InvalidOperationException("Warning exception"), "Warning message");
		}

		#endregion
	}
}