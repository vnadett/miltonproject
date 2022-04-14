namespace miltonProject.Client.Core.Static
{
    public class Endpoints
    {
        private static string BaseURL = "https://localhost:44344/api/";

        //registration
        public static string Reg = BaseURL + "Registration/Registration";
        //login
        public static string Login = BaseURL + "Login/Login";
        //user details upload
        public static string Details = BaseURL + "UserDetail/Details";
        // get user details
        public static string GetDetails = BaseURL + "UserDetail/GetDetails";
    }
}
