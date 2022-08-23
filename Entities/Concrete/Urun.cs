using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Urun
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string SeriNumarasi { get; set; }
        public int MarkamodelId { get; set; }
        public DateTime AlimTarihi { get; set; }
        public DateTime GarantiBitisTarihi { get; set; }
        public string DemirbasNumarasi { get; set; }
        public int FirmaId { get; set; }
        public string Fatura { get; set; }
        public int CpuId { get; set; }
        public int AnakartId { get; set; }
        public int Ram { get; set; }
        public int Ssd { get; set; }
        public int Hdd { get; set; }
        public string Lisans { get; set; }
        public int İsletimSistemiId { get; set; }
        public int EkranKartiId { get; set; }
        public string Mac { get; set; }
        public string Wifimac { get; set; }
        public string Aciklama { get; set; }
        public int LambaOmru { get; set; }
        public int Saat { get; set; }
        public decimal EkranBoyutu { get; set; }
        public int DahiliNumara { get; set; }
        public bool Verildi { get; set; }

    }
}
