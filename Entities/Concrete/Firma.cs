using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class Firma
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaTelefonu { get; set; }
        public string FirmaKisi { get; set; }
        public string Kargo { get; set; }
        public string KargoKodu { get; set; }
    }
}
