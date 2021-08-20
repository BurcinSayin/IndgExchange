using System;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.ServiceInterfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExchangeUserController : ControllerBase
    {

        private IExchangeUserReadService _userReadService;
        private IExchangeUserWriteService _userWriteService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userReadService"></param>
        /// <param name="userWriteService"></param>
        public ExchangeUserController(IExchangeUserReadService userReadService, IExchangeUserWriteService userWriteService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
        }
        
        /// <summary>
        /// Gets the Exchange User with the given Id
        /// </summary>
        /// <param name="id">User Id to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ExchangeUserInfo> Get(int id)
        {
            var retVal = _userReadService.GetItem(id);

            return Ok(retVal);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedList<ExchangeUserInfo> GetAll([FromQuery] FindUsersWithPagingQuery query)
        {
            return _userReadService.FindItems(query);
        }
        
        /// <summary>
        /// Creates an Exchange User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CreateExchangeUserCommand command)
        {
            try
            {
                var resultItem = _userWriteService.CreateExchangeUser(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}