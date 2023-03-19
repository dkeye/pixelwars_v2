namespace BackendWebAPI.Models
{
    public class Person
    {
        public Person(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }


    }
}
