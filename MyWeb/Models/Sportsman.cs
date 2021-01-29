using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Sportsman
    {
        public int SportsmanID { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}