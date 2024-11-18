using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PCPartCompare_IPT2_1.Object
{
    public class Computer
    {
        CPU CPUComp = new CPU();
        GPU GPUComp = new GPU();
        RAM RAMComp = new RAM();
        STOR STORComp = new STOR();
        STOR STORAUXComp= new STOR();

        public CPU getCPUComp()
        {
            return CPUComp;
        }
        public void setCPUComp(CPU value)
        {
            CPUComp = value;
        }   

        public GPU getGPUComp()
        {
            return GPUComp;
        }
        public void setGPUComp(GPU value)
        {
            GPUComp = value;
        }

        public RAM getRAMComp()
        {
            return RAMComp;
        }
        public void setRAMComp(RAM value)
        {
            RAMComp = value;
        }
        public STOR getStorageComp()
        {
            return STORComp;
        }

        public void setStorageComp(STOR value)
        {
            STORComp = value;
        }
        public STOR getStorageAuxComp()
        {
            return STORAUXComp;
        }

        public void setStorageAuxComp(STOR value)
        {
            STORAUXComp = value;
        }

    }
}
