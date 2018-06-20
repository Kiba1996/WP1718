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

    public class DriveR
    {
        public string XCoord { get; set; }
        public string YCoord { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public string tipAuta { get; set; }
        public string korisnicko { get; set; }
    }
    }