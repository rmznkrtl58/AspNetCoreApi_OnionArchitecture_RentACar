using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class AppRole
	{
        public int AppRoleId { get; set; }
        [StringLength(30)]
        public string AppRoleName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
