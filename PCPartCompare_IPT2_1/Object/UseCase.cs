using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PCPartCompare_IPT2_1
{
    public class UseCase
    {
        //Variables
        private int _ID;
        private string _FullName;
        private float _CPUPercent;
        private float _GPUPercent;
        private float _RAMPercent;
        private float _STORPercent;
        private float _STORAUXPercent;

        //Constructors
        public UseCase()
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
        public float get_CPUPercent() {
            return _CPUPercent;
        }
        public void set_CPUPercent(float value)
        {
            _CPUPercent = value;
        }
        public float get_GPUPercent()
        {
            return _GPUPercent;
        }
        public void set_GPUPercent(float value)
        {
            _GPUPercent = value;
        }
        public float get_RAMPercent()
        {
            return _RAMPercent;
        }
        public void set_RAMPercent(float value)
        {
            _RAMPercent = value;
        }
        public float get_STORPercent()
        {
            return _STORPercent;
        }
        public void set_STORPercent(float value)
        {
            _STORPercent = value;
        }
        public float get_STORAUXPercent()
        {
            return _STORAUXPercent;
        }
        public void set_STORAUXPercent(float value)
        {
            _STORAUXPercent = value;
        }

    }
}
