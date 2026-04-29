using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDemo;

public class AppInsightsDemo
{
    private readonly ILogger<AppInsightsDemo> _logger;

    public AppInsightsDemo(ILogger<AppInsightsDemo> logger)
    {
        _logger = logger;
    }

    [Function("LongRunningFunction")]
    public IActionResult LongRunningFunction([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        Task.Delay(TimeSpan.FromSeconds(10)).Wait(); // Simulate a long-running operation
        return new OkObjectResult("LongRunningFunction execution completed.");
    }

    [Function("FunctionWithException")]
    public IActionResult FunctionWithException([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        throw new InvalidOperationException("This is a test exception for App Insights.");
    }

}
