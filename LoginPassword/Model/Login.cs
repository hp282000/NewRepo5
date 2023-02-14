namespace LoginPassword.Model
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] Password { get; set; }

        public byte[] KeyPassword { get; set; }
    }

    public class LoginView
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

      
    }
}
