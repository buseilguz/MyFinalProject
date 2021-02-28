using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "categori sayısı hatası";
        public  static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryError="15 ten fazla kategori oluşturulamaz.";
        internal static string AuthorizationDenied="Yetkiniz yok";
        internal static string UserRegistered="KAyıt oldu";
        internal static string SuccessfulLogin="BAşarılı giriş";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatası";
        internal static string UserAlreadyExists="Kullanıcı mevcut";
        internal static string AccessTokenCreated = "AccessTokenCreated";
        
    }
}
