using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    public class Element : IComparable
    {
        public double coefficient { get; set; }
        public int power { get; set; }
        public Element() { coefficient = 1; power = 0; }
        public Element(double coefficient, int power)
        {
            this.coefficient = coefficient;
            this.power = power;
        }
        public Element(Element value)
        {
            coefficient = value.coefficient;
            power = value.power;
        }
        public int CompareTo(object obj)
        {
            if (obj == null || this == null)
                throw new ArgumentNullException();
            Element elementObj = obj as Element;
            if (power > elementObj.power)
                return 1;
            else if (power == elementObj.power)
                return 0;
            else return -1;
        }
    }
    public class _Polynom 
    {
        private Dictionary<int,Element> listElements = new Dictionary<int, Element>();
        public int Length
        {
            get
            {
                return listElements.Count;
            }
        }
        public Element this[int power]
        {
            get
            {
                if (listElements[power] == null)
                    throw new NullReferenceException();
                return listElements[power];
            }
            set
            {
                listElements[power] = value ?? throw new ArgumentNullException();
            }
        }
        public _Polynom() { }
        public _Polynom(double coefficient,int power) => Add(coefficient, power);
        public _Polynom(Dictionary<int,Element> value)
        {
            listElements = value ?? throw new ArgumentNullException();
            Sort(ref listElements);
        }
        public _Polynom(_Polynom value)
        {
            foreach (var item in value.listElements)
            {
                listElements.Add(item.Value.power, new Element(item.Value));
            }
        }
        public bool ChangePowerInElement(int key, int newPower)
        {
            if (!listElements.ContainsKey(key))
                return false;

            Element newEl = new Element(listElements[key].coefficient,newPower);

            listElements.Remove(key);
            return Add(newEl.coefficient,newPower);
        }
        public bool ChangeCoefInElement(int key, int newCoef)
        {
            if (!listElements.ContainsKey(key))
                return false;

            listElements[key].coefficient = newCoef;

            return true;
        }
        public bool Add(double coefficient,int power)
        {
            if (power > 1000 || power < -1000)
                return false;

            if (!listElements.ContainsKey(power))
                listElements.Add(power, new Element(coefficient, power));
            else listElements[power].coefficient += coefficient;

            Sort(ref listElements);
            return true;
        }
        public bool Add(Element value)
        {
            if (value == null)
                throw new ArgumentNullException();
            return Add(value.coefficient, value.power);
        }
        public static _Polynom operator +(_Polynom data1, _Polynom data2)
        {
            if (!ValidateForOperation(data1, data2))
                throw new ArgumentNullException();

            _Polynom result = new _Polynom(data1);

            foreach (var item in data2.listElements)
            {
                if (result.listElements[item.Key] != null)
                    result.listElements[item.Key].coefficient += item.Value.coefficient;
                else result.Add(item.Value.coefficient,item.Value.power);
            }

            return result;
        }
        public static _Polynom operator -(_Polynom data1, _Polynom data2)
        {
            if (!ValidateForOperation(data1,data2))
                throw new ArgumentNullException();

            _Polynom result = new _Polynom(data1);

            foreach (var item in data2.listElements)
            {
                if (result.listElements[item.Key] != null)
                {
                    result.listElements[item.Key].coefficient -= item.Value.coefficient;

                    if (result.listElements[item.Key].coefficient == 0)
                        result.listElements.Remove(item.Key);
                }
                else result.Add(new Element(item.Value.coefficient * (-1), item.Value.power));
            }

            return result;
        }
        public static _Polynom operator *(_Polynom data1, _Polynom data2)
        {
            if (!ValidateForOperation(data1, data2))
                throw new ArgumentNullException();

            _Polynom result = new _Polynom();

            foreach (var item1 in data1.listElements)
            {
                foreach (var item2 in data2.listElements)
                {
                    int newPower = item1.Value.power + item2.Value.power;
                    double newCoef = item1.Value.coefficient * item2.Value.coefficient;

                    result.Add(newCoef, newPower);
                }
            }

            return result;
        }
        private static bool ValidateForOperation(_Polynom data1, _Polynom data2)
        {
            if (data1 == null || data2 == null || data1.listElements == null || data2.listElements == null)
                return false;
            return true;
        }
        private static void Sort(ref Dictionary<int,Element> data)
        {
            data = data.OrderBy(key => key.Value.power).ToDictionary(pair => pair.Value.power, pair => pair.Value);
        }
    }
}
