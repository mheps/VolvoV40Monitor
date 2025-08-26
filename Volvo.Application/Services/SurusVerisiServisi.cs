using Volvo.Application.Interfaces;
using Volvo.Domain.Entities;
namespace Volvo.Application.Services
{
    // Bu servis, kullanıcı arayüzü (ConsoleApp) ile Domain arasında bir köprü görevi görür.
    // İş akışlarını yönetir: "Veriyi sıfırla" dendiğinde, repository'den veriyi alır, Domain'deki sıfırlama metodunu çağırır ve sonucu tekrar repository'e kaydeder.
    public class SurusVerisiServisi
    {
        private readonly ISurusVerisiRepository _repository;
        public SurusVerisiServisi(ISurusVerisiRepository repository) 
        { 
            _repository = repository; 
        }
        public AracSurusVerisi MevcutVerileriGetir() 
        { 
            return _repository.Get(); 
        }
        public void SurusVerileriniSifirla() 
        { 
            var d = _repository.Get(); 
            d.VerileriSifirla(); 
            _repository.Save(d); 
        }
        public void SurusSimulasyonuYap(double mesafe, double yakit, int sure) 
        { 
            var d = _repository.Get(); 
            d.SurusVerisiGuncelle(mesafe, yakit, sure); 
            _repository.Save(d); 
        }
    }
}