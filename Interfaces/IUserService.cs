using ReservationsProject.Models.Entities;

namespace ReservationsProject.Interfaces
{
    public interface IUserService
    {
        User GetUserByID(int userID);
        bool CreateNewUser(User user);
        bool EditUser(User user);
        bool DeleteUser(int userID);
    }
}
