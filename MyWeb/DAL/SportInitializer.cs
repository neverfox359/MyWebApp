using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.DAL
{
    public class SportInitializer
    {
        public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SportContext>
        {
            protected override void Seed(SportContext context)
            {
                var sportmans = new List<Sportsman>
            {
            new Sportsman{SurName="Carson",Name="Alexander",BirthDay=DateTime.Parse("2005-09-01")},
            new Sportsman{SurName="Meredith",Name="Alonso",BirthDay=DateTime.Parse("2002-09-01")},
            new Sportsman{SurName="Arturo",Name="Anand",BirthDay=DateTime.Parse("2003-09-01")},
            new Sportsman{SurName="Gytis",Name="Barzdukas",BirthDay=DateTime.Parse("2002-09-01")},
            new Sportsman{SurName="Yan",Name="Li",BirthDay=DateTime.Parse("2002-09-01")},
            new Sportsman{SurName="Peggy",Name="Justice",BirthDay=DateTime.Parse("2001-09-01")},
            new Sportsman{SurName="Laura",Name="Norman",BirthDay=DateTime.Parse("2003-09-01")},
            new Sportsman{SurName="Nino",Name="Olivetto",BirthDay=DateTime.Parse("2005-09-01")}
            };

                sportmans.ForEach(s => context.Sportsmans.Add(s));
                context.SaveChanges();
                var Disciplines = new List<Discipline>
            {
            new Discipline{DisciplineID=1050,Name="Chemistry",AgeGroup=3,},
            new Discipline{DisciplineID=4022,Name="Microeconomics",AgeGroup=3,},
            new Discipline{DisciplineID=4041,Name="Macroeconomics",AgeGroup=3,},
            new Discipline{DisciplineID=1045,Name="Calculus",AgeGroup=4,},
            new Discipline{DisciplineID=3141,Name="Trigonometry",AgeGroup=4,},
            new Discipline{DisciplineID=2021,Name="Composition",AgeGroup=3,},
            new Discipline{DisciplineID=2042,Name="Literature",AgeGroup=4,}
            };
                Disciplines.ForEach(s => context.Disciplines.Add(s));
                context.SaveChanges();
                var Deliveries = new List<Delivery>
            {
            new Delivery{SportsmanID=1,DisciplineID=1050,},
            new Delivery{SportsmanID=1,DisciplineID=4022,},
            new Delivery{SportsmanID=1,DisciplineID=4041,},
            new Delivery{SportsmanID=2,DisciplineID=1045,},
            new Delivery{SportsmanID=2,DisciplineID=3141,},
            new Delivery{SportsmanID=2,DisciplineID=2021,},
            new Delivery{SportsmanID=3,DisciplineID=1050},
            new Delivery{SportsmanID=4,DisciplineID=1050,},
            new Delivery{SportsmanID=4,DisciplineID=4022,},
            new Delivery{SportsmanID=5,DisciplineID=4041,},
            new Delivery{SportsmanID=6,DisciplineID=1045},
            new Delivery{SportsmanID=7,DisciplineID=3141,},
            };
                Deliveries.ForEach(s => context.Deliveries.Add(s));
                context.SaveChanges();
            }
        }
    }
}