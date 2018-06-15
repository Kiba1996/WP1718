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
        public User User { get; set; }
        public Drive Drive { get; set; }
        public int Rating { get; set; }

        public Comment() { }
        public Comment(String d, DateTime dt,User u, Drive dr, int r)
        {
            Description = d;
            Date = dt;
            User = u;
            Drive = dr;
            Rating = r;
        }
    }
}