using ReservationsProject.Models.Entities;
using System;
using System.Collections.Generic;

namespace ReservationsProject.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserByID(Guid userID);
        bool CreateNewUser(User user);
        bool EditUser(User user);
        bool DeleteUser(Guid userID);
    }
}
