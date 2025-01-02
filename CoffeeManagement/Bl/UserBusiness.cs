using CoffeeManagement.DAL;

namespace CoffeeManagement.BL
{
    public class UserBusiness
    {
        public bool IsValidUser(string username, string password)
        {
            UserDAL dal = new UserDAL();
            return dal.CheckUserCredentials(username, password);
        }

        public string GetLoggedInUserName()
        {
            return MainClass.USER;
        }
    }
}
