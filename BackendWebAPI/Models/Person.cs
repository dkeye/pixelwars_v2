namespace BackendWebAPI.Models
{
    public class Person
    {
        public Person(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
