using ReservationsProject.Models.Entities;
using System;

namespace ReservationsProject.Interfaces
{
    public interface IUserService
    {
        User GetUserByID(Guid userID);
        bool CreateNewUser(User user);
        bool EditUser(User user);
        bool DeleteUser(Guid userID);
    }
}
