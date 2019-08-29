using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mervegokpinar.com.Models.VM
{
    public class LoginVM
    {
        [
            Required(ErrorMessage ="Kullanıcı adı boş geçilemez"),
            DisplayName("username")
        ]
        public string username { get; set; }

        [
           Required(ErrorMessage = "Parola boş geçilemez"),
           DisplayName("Parola")
       ]
        public string password { get; set; }
        public bool IsPersistant { get; set; }
    }
    
}