using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationsProject.Interfaces;
using ReservationsProject.Models.Entities;
using System;

namespace ReservationsProject.Controllers
{
    public class UserController : ControllerBase
    {
        IUserService _userservice;
        public UserController(IUserService userService)
        {
            _userservice = userService;
        }

        [HttpGet]
        [Route("GetUserByID")]
        public ActionResult<User>GetUserByID(Guid userID)
        {
            return this._userservice.GetUserByID(userID);
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public ActionResult<bool>CreateNewUser(User user)
        {
            return this._userservice.CreateNewUser(user);
        }

        [HttpPut]
        [Route("EditUser")]
        public ActionResult<bool>EditUser(User user)
        {
            return this._userservice.EditUser(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult<bool>DeleteUser(Guid userID)
        {
            return this._userservice.DeleteUser(userID);
        }
    }
}
