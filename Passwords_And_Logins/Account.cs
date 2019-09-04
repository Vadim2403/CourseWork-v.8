using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords_And_Logins
{
    [Table("tblAccount")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("user")]
        public int UserID { get; set; }

        public virtual User user { get; set; }
    }
}
