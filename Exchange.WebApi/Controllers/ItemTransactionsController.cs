using System;
using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Command;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Query;
using Exchange.Domain.ItemTransaction.Response;
using Exchange.Domain.ItemTransaction.Service;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ItemTransactionsController : ControllerBase
    {
        private IItemTransactionReadService _readService;
        private IItemTransactionWriteService _writeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readService"></param>
        /// <param name="writeService"></param>
        public ItemTransactionsController(IItemTransactionReadService readService, IItemTransactionWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }
        
        

        [HttpGet("{id}")]
        public ActionResult<ItemTransactionInfo> Get(int id)
        {
            var retVal = _readService.GetItemTransaction(new GetItemTransactionQuery() { ItemTransactionId = id });

            return Ok(retVal);
        }


        [HttpGet]
        public ActionResult<PagedList<ItemTransactionInfo>> GetAll([FromQuery] GetItemTransactionsWithPagingQuery query)
        {
            return Ok(_readService.GetTransactionItems(query));
        }
        

        [HttpPost]
        public ActionResult<ItemTransactionInfo> Create(CreateItemTransactionCommand command)
        {
            try
            {
                var resultItem = _writeService.CreateItemTransaction(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}