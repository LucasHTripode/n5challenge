using Confluent.Kafka;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using n5challenge.Application.Model;
using n5challenge.Core.Entity;
using n5challenge.Handlers.Commands;
using n5challenge.Handlers.Queries;
using Nest;
using Newtonsoft.Json;
using System.Net;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace n5challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ApiController
    {
        ProducerConfig _configuration;
        readonly ISender _mediator;
        readonly IElasticClient _elasticClient;
        readonly ILogger<PermissionsController> _logger;

        public PermissionsController(ISender mediator,
                                     ProducerConfig configuration, 
                                     IElasticClient elasticClient,
                                     ILogger<PermissionsController> logger)
        {
            _mediator = mediator;
            _configuration = configuration;
            _elasticClient = elasticClient;
            _logger = logger;
        }

        [HttpGet("GetPermissions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Permission>>> GetPermissions()
        {
            await _elasticClient.DeleteByQueryAsync<Permission>(q => q.MatchAll());

            var query = new GetPermissionsQuery();
            var result = await _mediator.Send(query);

            foreach (var permission in result)
            {
                await _elasticClient.IndexDocumentAsync(permission);

                string serializedData = JsonConvert.SerializeObject(permission);

                using (var producer = new ProducerBuilder<Null, string>(_configuration).Build())
                {
                    await producer.ProduceAsync("testdata", new Message<Null, string> { Value = serializedData });
                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(true);
                }
            }

            _logger.LogInformation("PermissionsController GetPermissions - ", DateTime.UtcNow);

            return result;            
        }

        [HttpPut("ModifyPermission")]
        public async Task<ActionResult> ModifyPermissions([FromBody] ModifyPermissionsCommand modifyPermissionsCommand)
        {
            var resultado = await _mediator.Send(modifyPermissionsCommand);

            await _elasticClient.UpdateAsync<Permission>(resultado, u => u.Doc(resultado));

            string serializedData = JsonConvert.SerializeObject(resultado);

            using (var producer = new ProducerBuilder<Null, string>(_configuration).Build())
            {
                await producer.ProduceAsync("testdata", new Message<Null, string> { Value = serializedData });
                producer.Flush(TimeSpan.FromSeconds(10));
            }

            _logger.LogInformation("PermissionsController ModifyPermissions - ", DateTime.UtcNow);

            return Ok(resultado);

        }

        [HttpPost("RequestPermission")]
        public async Task<ActionResult> RequestPermissions([FromBody] RequestPermissionsCommand requestPermissionsCommand)
        {
            var resultado = await _mediator.Send(requestPermissionsCommand);

            await _elasticClient.IndexDocumentAsync(resultado);

            string serializedData = JsonConvert.SerializeObject(resultado);

            using (var producer = new ProducerBuilder<Null, string>(_configuration).Build())
            {
                await producer.ProduceAsync("testdata", new Message<Null, string> { Value = serializedData });
                producer.Flush(TimeSpan.FromSeconds(10));
            }

            _logger.LogInformation("PermissionsController RequestPermissions - ", DateTime.UtcNow);

            return Ok(resultado);
        }
    }
}
