using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Product.Commands.CreateProduct;
using Store.Application.Store;
using Store.Application.Store.Commands.CreateStore;
using Store.Application.Store.Queries.GetAllStores;
using Store.Application.Store.Queries.GetStoreByName;

namespace StoreAPI.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateStoreCommand command)
        {
            await _mediator.Send(command);
            return Created($"You have created a store {command.Name}", null);
        }

        [HttpGet]
        public async Task<ActionResult<StoreDto>> GetAll()
        {
            var stores = await _mediator.Send(new GetAllStoresQuery());
            return Ok(stores);
        }

        [HttpGet]
        [Route("/getByName/{encodedName}")]
        public async Task<ActionResult<StoreDto>> GetByName([FromRoute] string encodedName)
        {
            var store = await _mediator.Send(new GetStoreByNameQuery(encodedName));
            return Ok(store);
        }

        [HttpPost]
        [Route("{storeId}/product/create")]
        public async Task<ActionResult> CreateProduct(CreateProductCommand command, [FromRoute] string storeId)
        {
            command.StoreId = storeId;
            var storeProduct = await _mediator.Send(command);
            return Ok(storeProduct);
        }
    }
}