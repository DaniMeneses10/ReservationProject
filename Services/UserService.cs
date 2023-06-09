﻿using ReservationsProject.Database;
using ReservationsProject.Interfaces;
using ReservationsProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReservationsProject.Services
{    
    public class UserService : IUserService
    {
        ReservationDBContext _context;
        public UserService(ReservationDBContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            var users = this._context.Users.ToList();
            return users;
        }
        public User GetUserByID(Guid userID)
        {
            var user = this._context.Users.Where(x => x.UserID == userID).FirstOrDefault();            
            return user;
        }

        public bool CreateNewUser(User user)
        {
            var newUser = this._context.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();            

            if (newUser == null)
            {
                newUser = new User();
                newUser.UserID = Guid.NewGuid();
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
            var user = this._context.Users.Where(x => x.UserID == newUser.UserID).FirstOrDefault();
            
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

        public bool DeleteUser(Guid userID)
        {
            var user = this._context.Users.Where(x => x.UserID == userID).FirstOrDefault();            
            
            user.DeleteDate = DateTime.UtcNow;
                        
            return true;
        }
    }
}
