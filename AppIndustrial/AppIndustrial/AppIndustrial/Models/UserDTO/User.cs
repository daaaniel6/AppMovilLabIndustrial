using System;
using System.Collections.Generic;
using System.Text;

namespace AppIndustrial.Models.UserDTO
{
    public class User
    {
        public int carnet { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public bool state { get; set; }
        public RolUser rolUser { get; set; }
        public Career career { get; set; }

        public User() { }

        public User(int carnet, string name, string email, int phone, bool state, RolUser rolUser, Career career)
        {
            this.carnet = carnet;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.rolUser = rolUser;
            this.career = career;
        }
    }
}
