using System;
using System.Collections.Generic;
using System.Text;

namespace AppIndustrial.Models.UserDTO
{
    public class NewUser : User
    {
        public string password { get; set; }

        public NewUser() { }

        public NewUser(int carnet, string password) :
            base(carnet, String.Empty, String.Empty, 0, true, null, null)
        {
            this.password = password;
        }
        public NewUser(int carnet, string name, string email, int phone, bool state, RolUser rolUser, Career career, string password) : 
            base(carnet, name, email, phone, state, rolUser, career)
        {
            this.password = password;
        }
    }
}
