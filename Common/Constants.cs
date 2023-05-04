namespace ReservationsProject.Common
{
    public class Constants
    {
        public static class UserType
        {
            public static string COMPANY = "Company";
            public static string REGULARUSER = "RegularUser";            
        }
        public static class UserStatus
        {
            public static string AVAILABLE = "Available";
            public static string DUE = "Due";
            public static string CANCELED = "Canceled";
        }
        public static class EventType
        {
            public static string BIRTHDAYS = "Birthdays";
            public static string WEDDINGS = "Weddings";
            public static string CONFERENCES = "Conferences";
            public static string TRAININGS = "Trainings";
        }
    }
}
