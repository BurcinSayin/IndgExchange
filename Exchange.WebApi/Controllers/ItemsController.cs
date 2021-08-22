using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using Exchange.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private IItemReadService _itemReadService;
        private IItemWriteService _itemWriteService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemWriteService"></param>
        /// <param name="itemReadService"></param>
        public ItemsController(IItemWriteService itemWriteService, IItemReadService itemReadService)
        {
            _itemWriteService = itemWriteService;
            _itemReadService = itemReadService;
        }


        /// <summary>
        /// Gets the item with the given Id
        /// </summary>
        /// <param name="id">Item Id to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ItemInfo> Get(int id)
        {
            var retVal = _itemReadService.GetItem(new GetItemQuery(){ItemId = id});

            return Ok(retVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PagedList<ItemInfo>> GetAll([FromQuery] GetItemsWithPagingQuery query)
        {
            return Ok(_itemReadService.GetItems(query));
        }
        
        /// <summary>
        /// Creates an Item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ItemInfo> Create(CreateItemCommand command)
        {
            try
            {
                var resultItem = _itemWriteService.CreateItem(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ItemInfo> Update(UpdateItemCommand command)
        {
            var updatedItem = _itemWriteService.UpdateItem(command);

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _itemWriteService.DeleteItem(new DeleteItemCommand(){ItemId = id});
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}