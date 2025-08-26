namespace Volvo.Domain.Entities
{
    public class AracSurusVerisi
    {
        public double OrtalamaYakitTuketimi { get; private set; }
        public double ToplamMesafeKm { get; private set; }
        public double OrtalamaHiz { get; private set; }
        public TimeSpan GecenSure { get; private set; }
        private double _toplamTuketilenYakit;

        public AracSurusVerisi() { VerileriSifirla(); }

        public void VerileriSifirla()
        {
            OrtalamaYakitTuketimi = 0.0;
            ToplamMesafeKm = 0.0;
            OrtalamaHiz = 0.0;
            GecenSure = TimeSpan.Zero;
            _toplamTuketilenYakit = 0.0;
        }

        public void SurusVerisiGuncelle(double gidilenMesafeKm, double tuketilenYakitLitre, int gecenDakika)
        {
            ToplamMesafeKm += gidilenMesafeKm;
            _toplamTuketilenYakit += tuketilenYakitLitre;
            GecenSure += TimeSpan.FromMinutes(gecenDakika);
            OrtalamaYakitTuketimi = ToplamMesafeKm > 0 ? (_toplamTuketilenYakit / ToplamMesafeKm) * 100 : 0;
            OrtalamaHiz = GecenSure.TotalHours > 0 ? ToplamMesafeKm / GecenSure.TotalHours : 0;
        }
    }
}
