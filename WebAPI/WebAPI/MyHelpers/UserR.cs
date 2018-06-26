using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.MyHelpers
{
    public class UserR
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        
    }

    public class UserEDit
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string OldUsername { get; set; }

    }

    public class DriverR
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public string Reg { get; set; }
        public string tipVoz { get; set; }
        //public string Car { get; set; }


    }

    public class UserR1
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserFilter
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Stat { get; set; }
        public List<Drive> Driv { get; set; }
    }
    public class UserSort
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Stat { get; set; }
        public List<Drive> Driv { get; set; }
        public int PoCemu { get; set; }
    }

    public class UserSearch
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public List<Drive> Driv { get; set; }
        //public DateTime DatumOd { get; set; }
        //public DateTime DatumDo { get; set; }
        public string DatumOd { get; set; }
        public string DatumDo { get; set; }
        public string OcenaOd { get; set; }
        public string OcenaDo { get; set; }
        public string CenaOd { get; set; }
        public string CenaDo { get; set; } 
        public string VozIme { get; set; }
        public string VozPre { get; set; }
        public string MusIme { get; set; }
        public string MusPre { get; set; }

    }

    public class DriveR
    {
        public string XCoord { get; set; }
        public string YCoord { get; set; }
        public string Street { get; set; }
        //public string Number { get; set; }
        //public string Town { get; set; }
        //public string PostalCode { get; set; }
        public string tipAuta { get; set; }
        public string korisnicko { get; set; }
    }

    public class konacnaVoznja
    {
        public DriveR voz { get; set; }
        public string korisnickoAdmin { get; set; }
        public string korisnickoVozac { get; set; }
    }

    public class konacnaVoznjaObrada
    {
        public Drive voz { get; set; }
        public string korisnickoAdmin { get; set; }
        public string korisnickoVozac { get; set; }
    }


    public class ChangeDrivePrenos
    {
        public string XCoord { get; set; }
        public string YCoord { get; set; }
        public string Street { get; set; }
        //public string Number { get; set; }
        //public string Town { get; set; }
        //public string PostalCode { get; set; }
        public string tipAuta { get; set; }
        public string korisnicko { get; set; }
        public string datum { get; set; }
    }

    public class VoznjaPrenos
    {
        public Drive dr { get; set; }
    }
    public class ObradaPrenos
    {
        public Drive dr { get; set; }
        public List<Drive> voznje { get; set; }
        public string korisnicko { get; set; }
    }

    public class DriverPrenos
    {
        public bool zauzet { get; set; }
        public Enums.CarType tipAuta { get; set; }
        public Location lokacija { get; set; }
        
       
    }




    public class KomentarPrenos
    {
        public String KommOpis { get; set; }
        public String KommOcena { get; set; }
        public Drive voz { get; set; }
    }

    public class KomentarVozacPrenos
    {
        public String KommOpis { get; set; }
       // public String KommOcena { get; set; }
        public Drive voz { get; set; }
    }
    
   

    public class SuccessDrivePrenos
    {
        public string XCoord { get; set; }
        public string YCoord { get; set; }
        public string Street { get; set; }
        //public string Number { get; set; }
        //public string Town { get; set; }
        //public string PostalCode { get; set; }
        public Drive voznja { get; set; }
        public int Cena { get; set; }
    }

}