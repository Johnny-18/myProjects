using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,Element> le = new Dictionary<int, Element>();
            le.Add(1,new Element(1,9));
            le.Add(2,new Element(2,2));
            le.Add(4,new Element(4,7));
            le.Add(7,new Element(77,4));
            le.Add(9,new Element(2,1));
            _Polynom p1 = new _Polynom(le);
            p1.ChangeCoefInElement(2, 20);
            p1.ChangePowerInElement(7, 22);
            Dictionary<int, Element> dict = new Dictionary<int, Element>();

            _Polynom p2 = new _Polynom(p1);
            _Polynom p3 = p1 * p2;
            Console.ReadKey();
        }
    }
}
