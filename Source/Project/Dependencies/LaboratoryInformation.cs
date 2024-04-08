using Microsoft.Extensions.Logging;

namespace HansKindberg.PowerShell.Laboratory.Dependencies
{
	public class LaboratoryInformation : ILaboratoryInformation
	{
		#region Constructors

		public LaboratoryInformation(ILoggerFactory loggerFactory)
		{
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
		}

		#endregion

		#region Properties

		protected internal virtual ILogger Logger { get; }

		#endregion

		#region Methods

		public virtual string Get(string? value)
		{
			this.Logger.LogDebug("Getting value from dependency.");

			return $"Get from laboratory-information: {(value == null ? "null" : $"\"{value}\"")}";
		}

		#endregion
	}
}