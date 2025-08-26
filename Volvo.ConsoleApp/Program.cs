using Volvo.Application.Services;
using Volvo.Domain.Entities;
using Volvo.Infrastructure.Persistence;

// Uygulamanın başlangıç noktası (Composition Root).
// Burada, soyut arayüzlerin (ISurusVerisiRepository) hangi somut sınıflarla (InMemorySurusVerisiRepository) çalışacağını belirleriz.
// Bu işleme Dependency Injection (Bağımlılık Enjeksiyonu) denir.
var surusVerisiRepository = new InMemorySurusVerisiRepository();
var surusVerisiServisi = new SurusVerisiServisi(surusVerisiRepository);

Console.Title = "Volvo V40 Sürüş Monitörü (.NET 9 - Clean Architecture)";
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("--- Volvo V40 Sürüş Veri Monitörüne Hoş Geldiniz ---");
Console.ResetColor();

bool devam = true;
while (devam)
{
    Console.WriteLine("\nLütfen bir işlem seçin:");
    Console.WriteLine("1: Mevcut Sürüş Verilerini Görüntüle");
    Console.WriteLine("2: Sürüş Simülasyonu Yap (100km)");
    Console.WriteLine("3: Tüm Verileri Sıfırla");
    Console.WriteLine("4: Çıkış");
    Console.Write("Seçiminiz: ");

    string secim = Console.ReadLine() ?? "";
    switch (secim)
    {
        case "1":
            VerileriGoster(surusVerisiServisi.MevcutVerileriGetir());
            break;
        case "2":
            surusVerisiServisi.SurusSimulasyonuYap(100, 7.5, 90);
            VerileriGoster(surusVerisiServisi.MevcutVerileriGetir());
            break;
        case "3":
            surusVerisiServisi.SurusVerileriniSifirla();
            Console.WriteLine("Tüm sürüş verileri başarıyla sıfırlandı.");
            break;
        case "4":
            devam = false;
            break;
        default: Console.WriteLine("Geçersiz seçim!");
            break;
    }
}

void VerileriGoster(AracSurusVerisi veri)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n--- SÜRÜŞ VERİ RAPORU ---");
    Console.WriteLine($"Toplam Gidilen Mesafe: {veri.ToplamMesafeKm:F2} km");
    Console.WriteLine($"Ortalama Yakıt Tüketimi: {veri.OrtalamaYakitTuketimi:F2} L/100km");
    Console.WriteLine($"Ortalama Hız: {veri.OrtalamaHiz:F1} km/s");
    Console.WriteLine($"Toplam Geçen Süre: {veri.GecenSure.Hours} saat {veri.GecenSure.Minutes} dakika");
    Console.WriteLine("--------------------------");
    Console.ResetColor();
}