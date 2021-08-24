using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
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
        /// <returns>Item</returns>
        [HttpGet("{id}")]
        public ActionResult<ItemInfo> Get(int id)
        {
            try{
                var retVal = _itemReadService.GetItem(new GetItemQuery() { ItemId = id });

                return Ok(retVal);
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get List of item matching query with desired pagination
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List of items with paging data</returns>
        [HttpGet]
        public ActionResult<PagedList<ItemInfo>> GetAll([FromQuery] GetItemsWithPagingQuery query)
        {
            try{
                return Ok(_itemReadService.GetItems(query));
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Creates an Item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ItemInfo),StatusCodes.Status201Created)]
        public ActionResult<ItemInfo> Create(CreateItemCommand command)
        {
            try
            {
                var resultItem = _itemWriteService.CreateItem(command);
                return this.CreatedAtAction("Get", new { id = resultItem.Id }, resultItem);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update Item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ItemInfo> Update(UpdateItemCommand command)
        {
            try{
                var updatedItem = _itemWriteService.UpdateItem(command);

                return Ok(updatedItem);
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id">Item Id to delete</param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _itemWriteService.DeleteItem(new DeleteItemCommand(){ItemId = id});
                return NoContent();
            }
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}