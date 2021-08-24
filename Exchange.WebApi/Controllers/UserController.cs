using System;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Query;
using Exchange.Domain.User.Response;
using Exchange.Domain.User.Service;
using FluentValidation;
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
        /// Gets the User with the given Id
        /// </summary>
        /// <param name="id">User Id to get</param>
        /// <returns>Exchange User</returns>
        [HttpGet("{id}")]
        public ActionResult<UserInfo> Get(int id)
        {
            try{
                var retVal = _userReadService.GetUser(new GetUserQuery() { UserId = id });

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
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Delete User with the given Id
        /// </summary>
        /// <param name="id">User Id to delete</param>
        /// <returns>Exchange User</returns>
        [HttpDelete("{id}")]
        public ActionResult<UserInfo> Delete(int id)
        {
             try
             {
                 _userWriteService.DeleteUser(new DeleteUserCommand() { UserId = id });
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
        
        /// <summary>
        /// Gets users matching query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List of Exchange users with pagination</returns>
        [HttpGet]
        public ActionResult<PagedList<UserInfo>> GetAll([FromQuery] GetUsersWithPagingQuery query)
        {
            try{
                return _userReadService.GetUsers(query);
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
        /// Creates an User
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
            catch(NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Updates User
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