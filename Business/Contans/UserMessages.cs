using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contans
{
    public static class UserMessages
    {
       
        public static string CurrentWrongPassword = "Mevcut şifrenizi yanlış girdiniz.";
        public static string ChangePassword = "Şifreniz başarı ile güncellendi";
        public static string AddMessages = "Ekleme işlemi başarılı";
        public static string UpdatedUser = "Kullanıcı başarı ile güncellendi";
        public static string DeletedUser = "Kullanıcınız başarı ile silindi";
        public static string WrongDeletedUser = "Bu kullanıcıya ait tanımlanmış yetkiler var.";
    }
}
