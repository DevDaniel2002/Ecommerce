using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndEcommerce.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }
        public bool? State { get; set; }
    }
}
