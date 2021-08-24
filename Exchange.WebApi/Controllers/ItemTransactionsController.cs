using System;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Command;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Query;
using Exchange.Domain.ItemTransaction.Response;
using Exchange.Domain.ItemTransaction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
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
        
        

        /// <summary>
        /// Get transaction with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ItemTransactionInfo> Get(int id)
        {
            try{
                var retVal = _readService.GetItemTransaction(new GetItemTransactionQuery() { ItemTransactionId = id });

                return Ok(retVal);
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Search Item TRansactions
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Paged List</returns>
        [HttpGet]
        public ActionResult<PagedList<ItemTransactionInfo>> GetAll([FromQuery] GetItemTransactionsWithPagingQuery query)
        {
            try{
                return Ok(_readService.GetItemTransactions(query));
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        

        [HttpPost]
        public ActionResult<ItemTransactionInfo> Create(CreateItemTransactionCommand command)
        {
            try
            {
                var resultItem = _writeService.CreateItemTransaction(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}