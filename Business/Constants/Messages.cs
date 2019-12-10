using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string ProductNameAlreadyExists = "Ürün adı zaten sistemde kayıtlı";

        public static string CategoryAdded = "Kategori başarıyla eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı girildi";
        public static string SuccessfulLogin = "Kullanıcı girişi başarılıyla yapıldı";
        public static string UserAlreadyExists = "Kullanızı zaten kayıtlı";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt edildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Kullanıcı yetkisi yetersizdir";

    }
}
