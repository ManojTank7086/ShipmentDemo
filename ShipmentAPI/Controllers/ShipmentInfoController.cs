using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShipmentModel.Models;
using ShipmentAPI.RabitMQ;
using ShipmentAPI.Repository;
using System.Reflection;
using System.Reflection.Metadata;
using System.Transactions;
using ShipmentModel.CModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentInfoController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ILogger<ShipmentInfoController> _logger;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ShipmentInfoController(IShipmentRepository shipmentRepository, ILogger<ShipmentInfoController> logger, IRabitMQProducer rabitMQProducer)
            => (_shipmentRepository, _logger, _rabitMQProducer) = (shipmentRepository, logger, rabitMQProducer);


        // GET: api/<ShipmentInfoController>
        [HttpGet]
        public async Task<IEnumerable<ShipmentInfo>> GetAsync()
        {
            _logger.LogInformation("Get All Shipment");
            var result2 = await _shipmentRepository.GetShipments();
            return (IEnumerable<ShipmentInfo>)result2;
        }

        // GET api/<ShipmentInfoController>/5
        /// <summary>
        /// Get Shipment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [CustomSwagger("Get Shipment By Id", "", "")]
        public async Task<ShipmentInfo> GetAsync(long id)
        {
            _logger.LogInformation("Get Shipment By Id", id);
            var result = await _shipmentRepository.GetShipmentById(id);
            return result;
        }

        // POST api/<ShipmentInfoController>        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ShipmentInfoModel shipment)
        {
            var k = shipment.GetType().Name;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _shipmentRepository.CreateShipment(shipment);
                scope.Complete();
                _rabitMQProducer.SendProductMessage(result);
                return new OkObjectResult("result");
            }
        }

        // PUT api/<ShipmentInfoController>/5
        /// <summary>
        /// Update Shipment Information.
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> PutAsync([FromBody] ShipmentInfoModel shipment)
        {
            if (shipment == null)
                return new NoContentResult();


            using (var scope = new TransactionScope())
            {
                var result = await _shipmentRepository.UpdateShipment(shipment);
                scope.Complete();
                _rabitMQProducer.SendProductMessage(result);
                return new OkObjectResult(result);
            }
        }

        /// <summary>
        /// Delete Shipment with details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ShipmentInfoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            using (var scope = new TransactionScope())
            {
                var result = await _shipmentRepository.DeleteShipment(id);
                scope.Complete();
                return new OkObjectResult(result);
            }
        }
    }
}
