using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    //USerOperationClaimManager da kullanmak için. farklı tablodaki alanları listelemek için kullanılacak.
    public  class UserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string KullaniciAdi { get; set; }
        public string OperasyonAdi { get; set; }
    }
}
