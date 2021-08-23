using System;
using Exchange.Domain.Common.Response;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Query;
using Exchange.Domain.User.Response;
using Exchange.Domain.User.Service;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private IUserReadService _userReadService;
        private IUserWriteService _userWriteService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userReadService"></param>
        /// <param name="userWriteService"></param>
        public UserController(IUserReadService userReadService, IUserWriteService userWriteService)
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
        public ActionResult<UserInfo> Get(int id)
        {
            var retVal = _userReadService.GetUser(new GetUserQuery(){UserId = id});

            return Ok(retVal);
        }
        
        /// <summary>
        /// Gets Exchange users matching query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List of Exchange users with pagination</returns>
        [HttpGet]
        public PagedList<UserInfo> GetAll([FromQuery] GetUsersWithPagingQuery query)
        {
            return _userReadService.GetUsers(query);
        }
        
        /// <summary>
        /// Creates an Exchange User
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Created Exchange User</returns>
        [HttpPost]
        public ActionResult Create(CreateUserCommand command)
        {
            try
            {
                var resultItem = _userWriteService.CreateUser(command);
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
        public ActionResult Update(UpdateUserCommand command)
        {
            try
            {
                var resultItem = _userWriteService.UpdateUser(command);
                return this.CreatedAtAction("Get",new {id = resultItem.Id},resultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}