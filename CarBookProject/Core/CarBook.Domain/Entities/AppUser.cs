using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{   //burda jwt ile işlem yapacağımızdan dolayı AppUser adında bir 
	//kullanıcı tablosu oluşturcam Identity kullanmicam bu projede
	//sadece jwt ile işlemler yapacağız
	public class AppUser
	{
        public int AppUserId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
		[StringLength(15)]
		public string UserPassword { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole{ get; set; }
    }
}
