using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Discipline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisciplineID { get; set; }
        public string Name { get; set; }
        public int AgeGroup { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}