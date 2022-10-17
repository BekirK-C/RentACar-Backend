using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // static yapmamızın nedeni her kullanımda Messages class'ını new'lememek. Direkt Messages. şeklinde kullabiliriz. Proje boyunca sadece 1 instance oluşturur

        public static string MaintenanceTime = "Sistem Bakımda!";
        public static string CarCountofBrandError = "Bir markada en fazla 10 araç olabilir!";
        public static string ImagesPath = "wwwroot\\Uploads\\Images\\";

        public static string BrandAdded = "Araba markası eklendi.";
        public static string BrandDeleted = "Araba markası silindi.";
        public static string BrandUpdated = "Araba markası güncellendi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandGet = "Marka getirildi.";
        public static string SameNameExist = "Aynı araba markası mevcut";

        public static string CarAdded = "Araba eklendi:";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba bilgisi güncellendi.";
        public static string CarListed = "Arabalar listelendi";
        public static string CarNotAdded = "Araba Eklenemedi. Araba ismi geçersiz.";
        public static string CarNotUpdated = "Araba Güncellenemedi";
        public static string CarNotDeleted = "Araba Silinemedi";
        public static string CarCantFind = "güncellenecek Araba bulunamadı";
        public static string CarDetailList = "Araba Detay Listesi";
        public static string CarCountOfOpelError = "Opel Marka Araçtan 2 den fazla olamaz.";

        public static string ColorAdded = "Yeni renk eklendi.";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorGet = "Renk getirildi.";

        public static string ColorNotAdded = "Yeni renk eklenemedi.";
        public static string ColorNotDeleted = "Renk silinemedi";
        public static string ColorNotUpdated = "Renk güncellenemedi";
        public static string ColorNotListed = "Renkler listelenemedi.";
        public static string ColorNotGet = "Renk getirilemedi.";

        public static string CustomerAdded = "Yeni müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed = "Müşteriler listelendi.";
        public static string CustomerGet = "Müşteri bilgileri getildi.";

        public static string CustomerNotAdded = "Yeni müşteri eklenemedi.";
        public static string CustomerNotDeleted = "Müşteri silinemedi.";
        public static string CustomerNotUpdated = "Müşteri güncellenemedi";
        public static string CustomerNotListed = "Müşteriler listelenemedi.";
        public static string CustomerNotGet = "Müşteri bilgileri getilemedi.";

        public static string RentalAdded = "Araba kiralandı.";
        public static string RentalDeleted = "Kiralık araba silindi.";
        public static string RentalUpdated = "Kiralık araba güncellendi.";

        public static string RentalNotAdded = "Araba kiralanamadı.";
        public static string RentalNotDeleted = "Kiralık araba silinemedi.";
        public static string RentalNotUpdated = "Kiralık araba güncellenemedi.";

        public static string RentalListed = "Kiralık arabalar listelendi.";
        public static string RentalGet = "Kiralık araba getirildi.";
    }
}
