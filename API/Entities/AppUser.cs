namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } //Hashing performs a one-way transformation on a password, turning the password into another String, called the hashed password.
        public byte[] PasswordSalt { get; set; } //Salting is simply the addition of a unique, random string of characters known only to the site to each password before it is hashed, typically this “salt” is placed in front of each password
    }
}