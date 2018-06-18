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
        public List<Customer> ReadUsers(string fileName)
        {
            XmlSerializer desrializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> retVal = new List<Customer>();
            if (File.Exists(fileName)){
                using (TextReader reader = new StreamReader(fileName))
                {
                    object obj = desrializer.Deserialize(reader);
                    retVal = (List<Customer>)obj;
                }
            }
            return retVal;
        }

        public void WriteUsers(List<Customer> users, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Customer>));
            using (TextWriter write = new StreamWriter(fileName))
            {
                xml.Serialize(write, users);
            }
        }


        public List<Dispatcher> ReadDispatcher(string fileName)
        {
            XmlSerializer desrializer = new XmlSerializer(typeof(List<Dispatcher>));
            List<Dispatcher> retVal = new List<Dispatcher>();
            if (File.Exists(fileName))
            {
                using (TextReader reader = new StreamReader(fileName))
                {
                    object obj = desrializer.Deserialize(reader);
                    retVal = (List<Dispatcher>)obj;
                }
            }
            return retVal;
        }

        public void WriteDispatchers(List<Dispatcher> users, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Dispatcher>));
            using (TextWriter write = new StreamWriter(fileName))
            {
                xml.Serialize(write, users);
            }
        }

        public List<Drive> ReadDrives(string fileName)
        {
            XmlSerializer desrializer = new XmlSerializer(typeof(List<Drive>));
            List<Drive> retVal = new List<Drive>();
            if (File.Exists(fileName))
            {
                using (TextReader reader = new StreamReader(fileName))
                {
                    object obj = desrializer.Deserialize(reader);
                    retVal = (List<Drive>)obj;
                }
            }
            return retVal;
        }

        public void WriteDrives(List<Drive> drives, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Drive>));
            using (TextWriter write = new StreamWriter(fileName))
            {
                xml.Serialize(write, drives);
            }
        }



        public List<Driver> ReadDrivers(string fileName)
        {
            XmlSerializer desrializer = new XmlSerializer(typeof(List<Driver>));
            List<Driver> retVal = new List<Driver>();
            if (File.Exists(fileName))
            {
                using (TextReader reader = new StreamReader(fileName))
                {
                    object obj = desrializer.Deserialize(reader);
                    retVal = (List<Driver>)obj;
                }
            }
            return retVal;
        }

        public void WriteDrivers(List<Driver> users, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Driver>));
            using (TextWriter write = new StreamWriter(fileName))
            {
                xml.Serialize(write, users);
            }
        }



    }
}