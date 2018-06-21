using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Comment
    {
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public String user { get; set; }//User User { get; set; }
        public String Drive { get; set; }//Drive Drive { get; set; }
        public int Rating { get; set; }

        public Comment() {
            Rating = 0;
        }
        //public Comment(String d, DateTime dt,String u, String dr, int r)
        //{
        //    Description = d;
        //    Date = dt;
        //    User = u;
        //    Drive = dr;
        //    Rating = r;
        //}
    }
}