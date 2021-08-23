using System;
using Exchange.Domain.Common.Response;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Query;
using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.ExchangeUser.Service;
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
        /// <returns>Exchange User</returns>
        [HttpGet("{id}")]
        public ActionResult<ExchangeUserInfo> Get(int id)
        {
            var retVal = _userReadService.GetExchangeUser(new GetUserQuery(){ExchangeUserId = id});

            return Ok(retVal);
        }
        
        /// <summary>
        /// Gets Exchange users matching query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List of Exchange users with pagination</returns>
        [HttpGet]
        public PagedList<ExchangeUserInfo> GetAll([FromQuery] GetUsersWithPagingQuery query)
        {
            return _userReadService.GetExchangeUsers(query);
        }
        
        /// <summary>
        /// Creates an Exchange User
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Created Exchange User</returns>
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
        
        /// <summary>
        /// Updates Exchange User
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Updated Exchange User</returns>
        [HttpPut]
        public ActionResult Update(UpdateExchangeUserCommand command)
        {
            try
            {
                var resultItem = _userWriteService.UpdateExchangeUser(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}