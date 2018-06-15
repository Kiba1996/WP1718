using project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
namespace WebAPI.DataIO
{
    public class XMLDataIO
    {
        public List<User> ReadUsers(string fileName)
        {
            XmlSerializer desrializer = new XmlSerializer(typeof(List<User>));
            List<User> retVal = new List<User>();
            if (File.Exists(fileName)){
                using (TextReader reader = new StreamReader(fileName))
                {
                    object obj = desrializer.Deserialize(reader);
                    retVal = (List<User>)obj;
                }
            }
            return retVal;
        }

        public void WriteUsers(List<User> users, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<User>));
            using (TextWriter write = new StreamWriter(fileName))
            {
                xml.Serialize(write, users);
            }
        }
    }
}