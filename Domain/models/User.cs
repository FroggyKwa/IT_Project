using Domain.Logic;

namespace Domain.Models
{
    public class User
    {
        public int Id;
        public string PhoneNumber;
        public string Fullname;
        public Role Role;

        public string UserName;
        public string Password;

        public User() : this(0, "", "", "", "") { }

        public User(int id, string phoneNumber, string fullname, string userName, string password, Role role = Role.Patient)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Fullname = fullname;
            Role = role;
            UserName = userName;
            Password = password;
        }

        public Result IsValid()
        {
            if (string.IsNullOrEmpty(UserName))
                return Result.Fail("Empty username");
            if (string.IsNullOrEmpty(Password))
                return Result.Fail("Empty password");
            if (string.IsNullOrEmpty(PhoneNumber))
                return Result.Fail("Empty phone number");
            if (string.IsNullOrEmpty(Fullname))
                return Result.Fail("Empty fullname");
            if (Id < 0)
                return Result.Fail("Incorrect user id");

            return Result.Ok();
        }
        public static bool operator true(User u) => u.Id != -1;
        public static bool operator false(User u) => u.Id == -1;

    }
}