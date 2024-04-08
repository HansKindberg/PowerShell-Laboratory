using HansKindberg.PowerShell.Laboratory.Commands;
using HansKindberg.PowerShell.Laboratory.Dependencies;
using HansKindberg.PowerShell.Laboratory.DependencyInjection;
using HansKindberg.PowerShell.Laboratory.Logging;
using Moq;

namespace Tests.DependencyInjection
{
	public class ServiceProviderTest
	{
		#region Methods

		[Fact]
		public async Task GetLaboratoryInformation_ShouldReturnALaboratoryInformation()
		{
			await Task.CompletedTask;

			var laboratoryInformation = (LaboratoryInformation)ServiceProvider.Instance.GetLaboratoryInformation(Mock.Of<ICommand>());
			Assert.NotNull(laboratoryInformation);
			Assert.True(laboratoryInformation.Logger is CommandLogger);
		}

		[Fact]
		public async Task GetLoggerFactory_ShouldReturnALoggerFactory()
		{
			await Task.CompletedTask;

			var loggerFactory = ServiceProvider.Instance.GetLoggerFactory(Mock.Of<ICommand>());
			Assert.NotNull(loggerFactory);
			Assert.True(loggerFactory is CommandLoggerFactory);
		}

		[Fact]
		public async Task GetLoggingInformation_ShouldReturnALoggingInformation()
		{
			await Task.CompletedTask;

			var loggingInformation = (LoggingInformation)ServiceProvider.Instance.GetLoggingInformation(Mock.Of<ICommand>());
			Assert.NotNull(loggingInformation);
			Assert.True(loggingInformation.Logger is CommandLogger);
		}

		[Fact]
		public async Task Instance_ShouldAlwaysReturnTheSameInstance()
		{
			await Task.CompletedTask;

			var firstInstance = ServiceProvider.Instance;
			var secondInstance = ServiceProvider.Instance;
			Assert.NotNull(firstInstance);
			Assert.NotNull(secondInstance);
			Assert.True(ReferenceEquals(firstInstance, secondInstance));
		}

		#endregion
	}
}