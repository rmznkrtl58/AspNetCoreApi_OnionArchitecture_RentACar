using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JWTTokenDefaults
	{
		//Bizim default olarak atanan tokenimizin içeriğinde olmasını istediğimiz parametreler olacak
		public const string ValidAudience = "https://localhost";//dinleyici
		public const string ValidIssuer = "https://localhost";//Yayıncı
		public const string Key = "CarBook+*010203CARBOOK01*+*+*CAR";//Sahip olunan keyim hangi keye sahip olursak kullanıcım ilgili sayfayı açabilir
		public const int Expire = 3;//Tokenin ayakta kalma süresi 3 dk
	}
}
