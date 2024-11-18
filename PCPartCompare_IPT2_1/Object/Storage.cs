using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PCPartCompare_IPT2_1
{
    public class STOR
    {
        //Variables
        private int _ID;
        private string _FullName;
        private string _Type;
        private string _FormFactor;
        private float _Size;
        private float _Price;
        private string _Company;
        private int _Importance;

        //Constructors
        public STOR()
        {
            setID(0);
            set_FullName("Error");
        }
        //Methoden
        public int getID()
        {
            return _ID;
        }
        public void setID(int value)
        {
            _ID = value;
        }
        public string get_FullName()
        {
            return _FullName;
        }
        public void set_FullName(string value)
        {
            _FullName = value;
        }
        public string get_Company()
        {
            return _Company;
        }
        public void set_Company(string value)
        {
            _Company = value;
        }
        public string get_Type() {
            return _Type;
        }
        public void set_Type(string value)
        {
            _Type = value;
        }
        public string get_FormFactor()
        {
            return _FormFactor;
        }
        public void set_FormFactor(string value)
        {
            _FormFactor = value;
        }
        public float get_Size()
        {
            return _Size;
        }
        public void set_Size(float value)
        {
            _Size = value;
        }
        public float get_Price()
        {
            return _Price;
        }
        public void set_Price(float value)
        {
            _Price = value;
        }

        public void set_Importance(int value)
        {
            _Importance = value;
        }
        public int get_Importance()
        {
            return _Importance;
        }
    }
}
