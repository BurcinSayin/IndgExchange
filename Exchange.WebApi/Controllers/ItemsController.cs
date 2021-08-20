using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private IItemReadService _itemReadService;
        private IItemWriteService _itemWriteService;

        public ItemsController(IItemWriteService itemWriteService, IItemReadService itemReadService)
        {
            _itemWriteService = itemWriteService;
            _itemReadService = itemReadService;
        }


        [HttpGet]
        public IEnumerable<ItemInfo> Get()
        {
            return _itemReadService.GetAllItems();
        }
    }
}