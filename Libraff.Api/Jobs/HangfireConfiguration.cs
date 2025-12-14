using Hangfire;
using Libraff.Domain.Repositories;

namespace Libraff.Api.Jobs
{
    public static class HangfireJobs
    {
        public const string MarkTransfersAsDelivered = "mark-transfers-as-delivered";

        public static class Schedule
        {
            public const string EveryFiveMinutes = "*/5 * * * *";
            public const string EveryTenMinutes = "*/10 * * * *";
            public const string Hourly = "0 */1 * * *";
            public const string Daily = "0 0 * * *";
        }
    }
    public static class HangfireConfiguration
    {
        public static void ConfigureRecurringJobs()
        {
            RecurringJob.AddOrUpdate<IBranchStockRepository>(
                HangfireJobs.MarkTransfersAsDelivered,
                repository => repository.MarkConfirmedTransfersAsDelivered(),
                HangfireJobs.Schedule.EveryFiveMinutes);
        }
    }
}
