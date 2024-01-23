using WorkerService2.contracts;

namespace WorkerService2
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmail _email;
        private readonly IHttpService _httpService;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public Worker(ILogger<Worker> logger, IEmail email, IHttpService httpService, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _email = email;
            _httpService = httpService;
            _applicationLifetime = applicationLifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var statusSite = await _httpService.CheckStatusSite("Url do site que vai ser monitorado");

                if (statusSite != System.Net.HttpStatusCode.OK)
                {
                    _email.SendEmail("EmailQuevaireceber", "Worker Service Test", $"Site not running at: {DateTimeOffset.Now}");
                    _applicationLifetime.StopApplication();
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
