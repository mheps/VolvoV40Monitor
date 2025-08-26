using Volvo.Application.Interfaces;
using Volvo.Domain.Entities;
namespace Volvo.Infrastructure.Persistence
{
    // Bu sınıf, Application katmanındaki ISurusVerisiRepository sözleşmesini uygular.
    // Bu "In-Memory" (bellekte tutan) versiyon, test veya basit uygulamalar için idealdir.
    // Yarın bir veritabanı kullanmak istediğimizde, sadece bu sınıfın yerine veritabanına bağlanan yeni bir sınıf yazarız. Application katmanı hiç değişmez.
    public class InMemorySurusVerisiRepository : ISurusVerisiRepository
    {
        private static readonly AracSurusVerisi _surusVerisi = new AracSurusVerisi();
        public AracSurusVerisi Get()
        {
            return _surusVerisi;
        }
        public void Save(AracSurusVerisi surusVerisi)
        {
            // In-memory olduğu için _surusVerisi zaten referans olarak güncellendi.
            // Gerçek bir veritabanı olsaydı burada "SaveChanges()" gibi bir komut olurdu.
            Console.WriteLine("[Infrastructure]: Sürüş verileri belleğe kaydedildi.");
        }
    }
}