using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mervegokpinar.com.Models
{
    public class Kullanici
    {
        public int ID { get; set; }       
        public string username { get; set; }       
        public string password { get; set; }
        public string email { get; set; }       
    }
}