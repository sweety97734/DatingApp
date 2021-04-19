using System;
using System.Collections.Generic;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } //Hashing performs a one-way transformation on a password, turning the password into another String, called the hashed password.
        public byte[] PasswordSalt { get; set; } //Salting is simply the addition of a unique, random string of characters known only to the site to each password before it is hashed, typically this “salt” is placed in front of each password
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }

        //public int GetAge()
       // {
           // return DateOfBirth.CalculateAge();
        //}
    }
}