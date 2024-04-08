using System.Collections.Concurrent;
using HansKindberg.PowerShell.Laboratory.Commands;
using Microsoft.Extensions.Logging;

namespace HansKindberg.PowerShell.Laboratory.Logging
{
	public class CommandLoggerFactory(ICommand command) : ILoggerFactory
	{
		#region Properties

		public virtual ICommand Command { get; } = command ?? throw new ArgumentNullException(nameof(command));
		protected internal virtual ConcurrentDictionary<string, ILogger> Loggers { get; } = new(StringComparer.OrdinalIgnoreCase);

		#endregion

		#region Methods

		public virtual void AddProvider(ILoggerProvider provider) { }

		public virtual ILogger CreateLogger(string categoryName)
		{
			return this.Loggers.GetOrAdd(categoryName, key => new CommandLogger(key, this.Command));
		}

		public virtual void Dispose() { }

		#endregion
	}
}