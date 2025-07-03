using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.DTOs
{   //Oluşturduğumuz tokena yanıt verecek olan bazı parametreleri tutacak olan sınıfım
	public class TokenResponseDTO
	{
        public TokenResponseDTO(string token,DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
        public string Token { get; set; }
        //Ayakta Kalma süresi ne zaman oluşturuldu ne zamana kadar ayakta kalacağı süreyi tutacak değer
        public DateTime ExpireDate { get; set; }
    }
}
