using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA_BlogProject_2021.Models.ViewModel
{
   // Home-Index sayfamızda birden fazla tablodan veri çekmemiz gerekiyor
   //Sayafaya birden fazla veriyi gönderirken kontrolün bir yerden sağlanması için bu sınıf oluşturuldu
    public class IndexViewModel
    {
        public List<Services> Services { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<Sliders> Sliders { get; set; }
        public List<Contacts> Contacts { get; set; }
        public List<TeamDescriptions> TeamDescriptions   { get; set; }
    }
}