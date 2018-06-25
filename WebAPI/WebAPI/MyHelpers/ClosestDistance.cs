using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.MyHelpers
{
    public class Point
    {
        public Double X { get; set; }
        public Double Y { get; set; }
    }

    public class ClosestDistance
    {
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public List<string> OrderByDistance(List<Tuple<Point,string>> pointList,Point point)
        {
            var orderedList = new List<string>();

            var listaDouble = new List<Tuple<double, string>>();


            foreach(var var in pointList)
            {
                double k = Distance(var.Item1, point);
                listaDouble.Add(new Tuple<double, string>(k, var.Item2));
            }

            var lista = listaDouble.OrderBy(o => o.Item1).ToList();

            if (lista.Count() < 5)
            {
                for (int i = 0; i < lista.Count(); i++)
                {
                    string h = lista.ElementAt(i).Item2;
                    orderedList.Add(h);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    string h = lista.ElementAt(i).Item2;
                    orderedList.Add(h);
                }
            }

            return orderedList;
        }

    }
}