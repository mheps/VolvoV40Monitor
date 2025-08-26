using Volvo.Domain.Entities;
namespace Volvo.Application.Interfaces
{
    public interface ISurusVerisiRepository
    {
        AracSurusVerisi Get();
        void Save(AracSurusVerisi surusVerisi);
    }
}
