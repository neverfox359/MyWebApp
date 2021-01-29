using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Delivery
    {
      
            public int DeliveryID { get; set; }
            public int DisciplineID { get; set; }
            public int SportsmanID { get; set; }

            public virtual Sportsman Sportsman { get; set; }
            public virtual Discipline Discipline { get; set; }
    }
}
