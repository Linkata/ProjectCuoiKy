using CoffeeManagement.BL;

namespace CoffeeManagement.TL
{
    public class UserTransaction
    {
        private readonly UserBusiness _userBusiness = new UserBusiness();

        public bool Login(string username, string password)
        {
            return _userBusiness.IsValidUser(username, password);
        }

        public string GetUserName()
        {
            return _userBusiness.GetLoggedInUserName();
        }
    }
}
