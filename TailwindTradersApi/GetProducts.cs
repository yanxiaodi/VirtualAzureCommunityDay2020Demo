using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TailwindTradersApi
{
    public class GetProducts
    {
        private readonly IOptions<MyOptions> _options;
        public GetProducts(IOptions<MyOptions> options)
        {
            _options = options;
        }

        [FunctionName("GetProducts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")]
            HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";
            var cosmosClient = new CosmosClient(_options.Value.ConnectionString);
            var database = cosmosClient.GetDatabase(_options.Value.Database);
            var container = database.GetContainer(_options.Value.Container);

            var result = new List<Product>();

            // Use GetItemQueryIterator
            //var sqlQueryText = "SELECT * FROM c";
            //QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            //using var iterator = container.GetItemQueryIterator<Product>(queryDefinition);

            // Use GetItemLinqQueryable
            using var iterator = container.GetItemLinqQueryable<Product>().ToFeedIterator();
            while (iterator.HasMoreResults)
            {
                foreach (var item in await iterator.ReadNextAsync())
                {
                    result.Add(item);
                }
            }

            return new OkObjectResult(result);
        }

    }
}
