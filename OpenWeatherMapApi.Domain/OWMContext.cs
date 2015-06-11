using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenWeatherMap.Model;

namespace OpenWeatherMapApi.Domain
{
    public class OWMContext:DbContext
    {
        public DbSet<OWM_Historical> OWM_Historicals{get;set;}
        public DbSet<Group_OWM_Current> OWM_Currents { get; set; }
        public DbSet<OWM_Forecast3H> OWM_Forecast3H { get; set; }

        public OWMContext() : base(nameOrConnectionString: "OWM") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group_OWM_Current>().ToTable("Group_OWM_Current", "public");
            modelBuilder.Entity<OWM_Current>().ToTable("OWM_Current", "public").HasKey(x=>x.Id);
            modelBuilder.Entity<OWM_Current_Clouds>().ToTable("OWM_Current_Clouds", "public");
            modelBuilder.Entity<OWM_Current_Coord>().ToTable("OWM_Current_Coord", "public");
            modelBuilder.Entity<OWM_Current_Main>().ToTable("OWM_Current_Main", "public");
            modelBuilder.Entity<OWM_Current_Sys>().ToTable("OWM_Current_Sys", "public");
            modelBuilder.Entity<OWM_Current_Weather>().ToTable("OWM_Current_Weather", "public").HasKey(x=>x.Id);
            modelBuilder.Entity<OWM_Current_Wind>().ToTable("OWM_Current_Wind", "public");
            modelBuilder.Entity<OWM_Forecast3H>().ToTable("OWM_Forecast3H", "public");
            modelBuilder.Entity<OWM_Forecast3H_City>().ToTable("OWM_Forecast3H_City", "public");
            modelBuilder.Entity<OWM_Forecast3H_Clouds>().ToTable("OWM_Forecast3H_Clouds", "public");
            modelBuilder.Entity<OWM_Forecast3H_Coordinates>().ToTable("OWM_Forecast3H_Coordinates", "public");
            modelBuilder.Entity<OWM_Forecast3H_Forecast>().ToTable("OWM_Forecast3H_Forecast", "public");
            modelBuilder.Entity<OWM_Forecast3H_Main>().ToTable("OWM_Forecast3H_Main", "public");
            modelBuilder.Entity<OWM_Forecast3H_Sys>().ToTable("OWM_Forecast3H_Sys", "public");
            modelBuilder.Entity<OWM_Forecast3H_Weather>().ToTable("OWM_Forecast3H_Weather", "public").HasKey(x=>x.Id);
            modelBuilder.Entity<OWM_Forecast3H_Wind>().ToTable("OWM_Forecast3H_Wind", "public");
            modelBuilder.Entity<OWM_Historical>().ToTable("OWM_Historical", "public");
            modelBuilder.Entity<OWM_Historical_Clouds>().ToTable("OWM_Historical_Clouds", "public");
            modelBuilder.Entity<OWM_Historical_ListElement>().ToTable("OWM_Historical_ListElement", "public");
            modelBuilder.Entity<OWM_Historical_Main>().ToTable("OWM_Historical_Main", "public");
            modelBuilder.Entity<OWM_Historical_Snow>().ToTable("OWM_Historical_Snow", "public");
            modelBuilder.Entity<OWM_Historical_WeatherElement>().ToTable("OWM_Historical_WeatherElement", "public");
            modelBuilder.Entity<OWM_Historical_Wind>().ToTable("OWM_Historical_Wind", "public");
            Database.SetInitializer<OWMContext>(null);
          //  base.OnModelCreating(modelBuilder);
        }
    }
}
