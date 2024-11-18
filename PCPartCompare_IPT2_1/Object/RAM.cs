using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PCPartCompare_IPT2_1
{
    public class RAM
    {
        //Variables
        private int _ID;
        private string _FullName;
        private int _Size;
        private int _MegaTransferPerSec;
        private string _Latency;
        private string _Company;
        private int _DDRGeneration;
        private float _Price;
        private int _Importance;

        //Constructors
        public RAM()
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
        public int get_Size()
        {
            return _Size;
        }
        public void set_Size(int value)
        {
            _Size = value;
        }
        public int get_MegaTransferPerSec()
        {
            return _MegaTransferPerSec;
        }
        public void set_MegaTransferPerSec(int value)
        {
            _MegaTransferPerSec = value;
        }
        public string get_Latency()
        {
            return _Latency;
        }
        public void set_Latency(string value)
        {
            _Latency = value;
        }
        public string get_Company()
        {
            return _Company;
        }
        public void set_Company(string value)
        {
            _Company = value;
        }
        public int get_DDRGeneration()
        {
            return _DDRGeneration;
        }
        public void set_DDRGeneration(int value)
        {
            _DDRGeneration = value;
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
