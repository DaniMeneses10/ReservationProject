using ReservationsProject.Interfaces;
using ReservationsProject.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationsProject.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }
        
        public User GetUserByID(int userID)
        {
            //var user = this._context.Users.Where(x => x.UserID == userID).FirstOrDefault();
            var user = new User();
            return user;
        }

        public bool CreateNewUser(User user)
        {
            //var newUser = this._context.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
            var newUser = new User();

            if (newUser == null)
            {
                newUser = new User();
                newUser.UserID = user.UserID;
                newUser.Name = user.Name; 
                newUser.Email = user.Email;
                newUser.Cellphone = user.Cellphone;
                newUser.Type = user.Type;
                newUser.BirthDate = user.BirthDate;
                newUser.Status = user.Status;
                newUser.IsHost = user.IsHost;
                newUser.CreateDate = DateTime.UtcNow;
            }
            else
            {
                throw new ValidationException("The User already exists");
            }

            return true;
        }

        public bool EditUser(User newUser)
        {
            //var user = this._context.Users.Where(x => x.UserID == newUser.UserID).FirstOrDefault();
            var user = new User();

            user = new User();
            user.UserID = newUser.UserID;
            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Cellphone = newUser.Cellphone;
            user.Type = newUser.Type;
            user.BirthDate = newUser.BirthDate;
            user.Status = newUser.Status;
            user.IsHost = newUser.IsHost;            

            return true;
        }

        public bool DeleteUser(int userID)
        {
            //var user = this._context.Users.Where(x => x.UserID == user.userID).FirstOrDefault();            
            var user = new User();

            user.DeleteDate = DateTime.UtcNow;
                        
            return true;
        }


    }
}
