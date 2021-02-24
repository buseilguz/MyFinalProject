using System;
using System.Collections.Generic;
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
        internal static string CategoryError="15 ten fazla kategori oluşturulamaz.";
    }
}
