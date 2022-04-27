using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestMvcApp.Models
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}