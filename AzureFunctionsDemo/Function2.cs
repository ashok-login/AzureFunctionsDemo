using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDemo;

public class Function2
{
    private readonly ILogger<Function2> _logger;

    public Function2(ILogger<Function2> logger)
    {
        _logger = logger;
    }

    [Function("GetAllUsers")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/getallusers")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Ashok Kumar, Chalapathi");
    }

    [Function("GetExternalServiceURL")]
    public IActionResult GetExternalServiceURL([HttpTrigger(AuthorizationLevel.Function, "get", Route = "externalservice/getexternalserviceurl")] HttpRequest req)
    {
        var externalServiceURL = Environment.GetEnvironmentVariable("SomeExternalService");
        return new OkObjectResult(externalServiceURL);
    }
}