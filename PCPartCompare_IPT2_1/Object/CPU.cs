using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PCPartCompare_IPT2_1
{
    public class CPU
    {
        //Variables
        private int _ID;
        private string _FullName;
        private int _Cores;
        private int _Threads;
        private float _Frequency;
        private float _FrequencyBoost;
        private string _Socket;
        private string _Company;
        private int _Generation;
        private float _Price;
        private int _Importance;

        //Constructors
        public CPU()
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
        public int get_Cores()
        {
            return _Cores;
        }
        public void set_Cores(int value)
        {
            _Cores = value;
        }
        public int get_Threads()
        {
            return _Threads;
        }
        public void set_Threads(int value)
        {
            _Threads = value;
        }
        public float get_Frequency()
        {
            return _Frequency;
        }
        public void set_Frequency(float value)
        {
            _Frequency = value;
        }
        public float get_FrequencyBoost()
        {
            return _FrequencyBoost;
        }
        public void set_FrequencyBoost(float value)
        {
            _FrequencyBoost = value;
        }
        public string get_Socket()
        {
            return _Socket;
        }
        public void set_Socket(string value)
        {
            _Socket = value;
        }
        public string get_Company()
        {
            return _Company;
        }
        public void set_Company(string value)
        {
            _Company = value;
        }
        public int get_Generation()
        {
            return _Generation;
        }
        public void set_Generation(int value)
        {
            _Generation = value;
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
