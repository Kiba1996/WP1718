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
        public String user { get; set; }
        public String Driver { get; set; }
        public int Rating { get; set; }

        public Comment() {
            Rating = 0;
        }
        
    }
}