using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
       // public string ConfirmValue { get; set; }
     //   public bool IsConfirm { get; set; }
       // public string ForgotPasswordValue { get; set; }
      //  public DateTime? ForgotPasswordRequestDate { get; set; }
      //  public bool IsForgotPasswordComplete { get; set; }
        //public int BirimId { get; set; }

    }
}
