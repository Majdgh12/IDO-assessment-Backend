﻿using System.ComponentModel.DataAnnotations;

namespace IDO_Backend.Data
{
    public class User
    {

        [Key]
        public int userId { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
