using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Diagnostics.Tracing;

namespace PCPartCompare_IPT2_1.Object
{
    internal class Data
    {
        private static OleDbConnection s_cnn = new OleDbConnection();

        public static List<CPU> s_CPUList = new List<CPU>();
        public static List<GPU> s_GPUList = new List<GPU>();
        public static List<RAM> s_RAMList = new List<RAM>();
        public static List<STOR> s_STORList = new List<STOR>();
        public static List<UseCase> s_UseCase = new List<UseCase>();
        public static List<STOR> s_STORAuxList = s_STORList;

        public static List<CPU> s_SortedCPUList = new List<CPU>();
        public static List<GPU> s_SortedGPUList = new List<GPU>();
        public static List<RAM> s_SortedRAMList = new List<RAM>();
        public static List<STOR> s_SortedSTORList = new List<STOR>();
        public static List<STOR> s_SortedSTORAuxList = new List<STOR>();

        public static List<Computer> s_ComputerList = new List<Computer>();

        //Klassenmethoden
        public static bool ConnectToDB()
        {
            //Connection string
            s_cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;User ID=Admin;PASSWORD=";
            //Window to select database
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Component Database";
            ofdlg.InitialDirectory = Application.StartupPath;
            ofdlg.Filter = "Component Database (ComponentDB.accdb)|ComponentDB.accdb";
            //Takes either default path or selected bath.
            if (ofdlg.ShowDialog() != DialogResult.OK)
                s_cnn.ConnectionString += ";Data Source=..\\..\\ComponentDB.accdb";
            else
                s_cnn.ConnectionString += ";Data Source=" + ofdlg.FileName;
            try{
                s_cnn.Open();
                return true;
            }

            catch (OleDbException err){
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)s_cnn.Close();
            }
            return false; //If the connection didn't go through.
        }
        public static bool ReadAllDataIn()
        {
            //checks connection
            if (ConnectToDB() == false)
                return false;
            //Calls all read functions in.
            try
            {
                ReadAllCPUsIn();
                ReadAllUseCasesIn();
                ReadAllGPUIn();
                ReadAllStorIn();
                ReadAllRAMIn();

                s_cnn.Close();
            }
            //Looks for any errors
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
            return true;
        }
        public static void ReadAllCPUsIn()
        {
            s_CPUList.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = s_cnn;
                if (s_cnn.State != ConnectionState.Open)
                    s_cnn.Open();
                cmd.CommandText = "SELECT * FROM CPU order by ID";
                OleDbDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    CPU h = new CPU();

                    h.setID(Convert.ToInt32(myReader["ID"]));
                    h.set_FullName(Convert.ToString(myReader["FullName"]));
                    h.set_Cores(Convert.ToInt32(myReader["Cores"]));
                    h.set_Threads(Convert.ToInt32(myReader["Threads"]));
                    h.set_Frequency(Convert.ToSingle(myReader["Frequency"]));
                    h.set_FrequencyBoost(Convert.ToSingle(myReader["FrequencyBoost"]));
                    h.set_Socket(Convert.ToString(myReader["Socket"]));
                    h.set_Company(Convert.ToString(myReader["Company"]));
                    h.set_Generation(Convert.ToInt32(myReader["Generation"]));
                    h.set_Price(Convert.ToSingle(myReader["Cost"]));
                    h.set_Importance(Convert.ToInt32(myReader["Importance"]));
                    s_CPUList.Add(h);
                }
                myReader.Close();


            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)
                    s_cnn.Close();
            }
        }
        private static void ReadAllUseCasesIn()
        {
            s_UseCase.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = s_cnn;
                if (s_cnn.State != ConnectionState.Open)
                    s_cnn.Open();
                cmd.CommandText = "SELECT * FROM UseCase order by ID";
                OleDbDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    UseCase h = new UseCase();

                    h.setID(Convert.ToInt32(myReader["ID"]));
                    h.set_FullName(Convert.ToString(myReader["FullName"]));
                    h.set_CPUPercent(Convert.ToInt32(myReader["CPUPercent"]));
                    h.set_GPUPercent(Convert.ToInt32(myReader["GPUPercent"]));
                    h.set_RAMPercent(Convert.ToInt32(myReader["RAMPercent"]));
                    h.set_STORPercent(Convert.ToInt32(myReader["STORPercent"]));
                    h.set_STORAUXPercent(Convert.ToInt32(myReader["STORAUXPercent"]));

                    s_UseCase.Add(h);
                }
                myReader.Close();
            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)
                    s_cnn.Close();
            }
        }
        public static void ReadAllGPUIn()
        {
            s_GPUList.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = s_cnn;
                if (s_cnn.State != ConnectionState.Open)
                    s_cnn.Open();
                cmd.CommandText = "SELECT * FROM GPU order by ID";
                OleDbDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    GPU h = new GPU();

                    h.setID(Convert.ToInt32(myReader["ID"]));
                    h.set_FullName(Convert.ToString(myReader["FullName"]));
                    h.set_Company(Convert.ToString(myReader["Company"]));
                    h.set_Generation(Convert.ToInt32(myReader["Generation"]));
                    h.set_Price(Convert.ToSingle(myReader["Cost"]));
                    h.set_Importance(Convert.ToInt32(myReader["Importance"]));

                    s_GPUList.Add(h);
                }
                myReader.Close();


            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)
                    s_cnn.Close();
            }
        }
        public static void ReadAllRAMIn()
        {
            s_RAMList.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = s_cnn;
                if (s_cnn.State != ConnectionState.Open)
                    s_cnn.Open();
                cmd.CommandText = "SELECT * FROM RAM order by ID";
                OleDbDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    RAM h = new RAM();

                    h.setID(Convert.ToInt32(myReader["ID"]));
                    h.set_FullName(Convert.ToString(myReader["FullName"]));
                    h.set_Company(Convert.ToString(myReader["Company"]));
                    h.set_DDRGeneration(Convert.ToInt32(myReader["DDRGen"]));
                    h.set_Price(Convert.ToSingle(myReader["Cost"]));
                    h.set_MegaTransferPerSec(Convert.ToInt32(myReader["MegaTransfer"]));
                    h.set_Latency(Convert.ToString(myReader["Latency"]));
                    h.set_Size(Convert.ToInt32(myReader["Size"]));
                    h.set_Importance(Convert.ToInt32(myReader["Importance"]));

                    s_RAMList.Add(h);
                }
                myReader.Close();


            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)
                    s_cnn.Close();
            }
        }
        public static void ReadAllStorIn()
        {
            s_STORList.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = s_cnn;
                if (s_cnn.State != ConnectionState.Open)
                    s_cnn.Open();
                cmd.CommandText = "SELECT * FROM STOR order by ID";
                OleDbDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    STOR h = new STOR();

                    h.setID(Convert.ToInt32(myReader["ID"]));
                    h.set_FullName(Convert.ToString(myReader["FullName"]));
                    h.set_Company(Convert.ToString(myReader["Company"]));
                    h.set_Size(Convert.ToSingle(myReader["Size"]));
                    h.set_Type(Convert.ToString(myReader["Type"]));
                    h.set_Price(Convert.ToSingle(myReader["Cost"]));
                    h.set_FormFactor(Convert.ToString(myReader["Type"]));
                    h.set_Importance(Convert.ToInt32(myReader["Importance"]));

                    s_STORList.Add(h);
                }
                myReader.Close();


            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (s_cnn.State == ConnectionState.Open)
                    s_cnn.Close();
            }
        }


        /// <summary>
        /// BELOW ARE ALL ALGORITHMS FOR EACH COMPONENT, WHICH SORT OUT INCOMPATIBLE COMPONENTS AND SORTS THEM BY IMPORTANCE. 
        /// 
        /// </summary>

        public static void Algo(UseCase Usecase, int Budget)
        {


            float CPUSplitval = ((Usecase.get_CPUPercent()) / 100 * Budget) + 10;
            float GPUSplitval = ((Usecase.get_GPUPercent()) / 100 * Budget) + 10;
            float RAMSplitval = ((Usecase.get_RAMPercent()) / 100 * Budget) + 10;
            float STORSplitval = ((Usecase.get_STORPercent()) / 100 * Budget) + 10;

            CPU CPUtemp;
            GPU GPUtemp;
            RAM RAMtemp;
            STOR Storagetemp;

            //Fills in all compatible CPUs withing range of budget of CPUsplit
            for (int i = 0; i < s_CPUList.Count; i++)
            {
                if (s_CPUList[i].get_Price() <= CPUSplitval)
                {
                    s_SortedCPUList.Add(s_CPUList[i]);
                }
            }
            
            //Sorts all CPUs by importance
            for (int b = 0; b < s_SortedCPUList.Count; b++)
            {
                for (int sort = 0; sort < s_SortedCPUList.Count - 1; sort++)
                {
                    if (s_SortedCPUList[sort].get_Importance() < s_SortedCPUList[sort + 1].get_Importance())
                    {
                        CPUtemp = s_SortedCPUList[sort + 1];
                        s_SortedCPUList[sort + 1] = s_SortedCPUList[sort];
                        s_SortedCPUList[sort] = CPUtemp;
                    }
                }
                for (int sort = 0; sort < s_SortedCPUList.Count - 1; sort++)
                {
                    if (s_SortedCPUList[sort].get_Importance() == s_SortedCPUList[sort + 1].get_Importance() && s_SortedCPUList[sort].get_Price() < s_SortedCPUList[sort + 1].get_Price())
                    {
                        CPUtemp = s_SortedCPUList[sort + 1];
                        s_SortedCPUList[sort + 1] = s_SortedCPUList[sort];
                        s_SortedCPUList[sort] = CPUtemp;
                    }
                }
            }

            //Fills in all compatible GPUs withing range of budget of GPUsplit
            for (int i = 0; i < s_GPUList.Count; i++)
            {
                if (s_GPUList[i].get_Price() <= GPUSplitval)
                {
                    s_SortedGPUList.Add(s_GPUList[i]);
                }
            }

            //Sorts all GPUs by importance
            for (int b = 0; b < s_SortedGPUList.Count; b++)
            {
                for (int sort = 0; sort < s_SortedGPUList.Count - 1; sort++)
                {
                    if (s_SortedGPUList[sort].get_Importance() < s_SortedGPUList[sort + 1].get_Importance())
                    {
                        GPUtemp = s_SortedGPUList[sort + 1];
                        s_SortedGPUList[sort + 1] = s_SortedGPUList[sort];
                        s_SortedGPUList[sort] = GPUtemp;
                    }
                }
                for (int sort = 0; sort < s_SortedGPUList.Count - 1; sort++)
                {
                    if (s_SortedGPUList[sort].get_Importance() == s_SortedGPUList[sort + 1].get_Importance() && s_SortedGPUList[sort].get_Price() < s_SortedGPUList[sort + 1].get_Price())
                    {
                        GPUtemp = s_SortedGPUList[sort + 1];
                        s_SortedGPUList[sort + 1] = s_SortedGPUList[sort];
                        s_SortedGPUList[sort] = GPUtemp;
                    }
                }
            }

            //Fills in all compatible RAMs withing range of budget of RAMsplit
            for (int i = 0; i < s_RAMList.Count; i++)
            {
                if (s_RAMList[i].get_Price() <= RAMSplitval)
                {
                    s_SortedRAMList.Add(s_RAMList[i]);
                }
            }

            //Sorts all RAMs by importance
            for (int b = 0; b < s_SortedRAMList.Count; b++)
            {
                for (int sort = 0; sort < s_SortedRAMList.Count - 1; sort++)
                {
                    if (s_SortedRAMList[sort].get_Importance() < s_SortedRAMList[sort + 1].get_Importance())
                    {
                        RAMtemp = s_SortedRAMList[sort + 1];
                        s_SortedRAMList[sort + 1] = s_SortedRAMList[sort];
                        s_SortedRAMList[sort] = RAMtemp;
                    }
                }
                for (int sort = 0; sort < s_SortedRAMList.Count - 1; sort++)
                {
                    if (s_SortedRAMList[sort].get_Importance() == s_SortedRAMList[sort + 1].get_Importance() && s_SortedRAMList[sort].get_Price() < s_SortedRAMList[sort + 1].get_Price())
                    {
                        RAMtemp = s_SortedRAMList[sort + 1];
                        s_SortedRAMList[sort + 1] = s_SortedRAMList[sort];
                        s_SortedRAMList[sort] = RAMtemp;
                    }
                }
            }

            //Fills in all compatible STORs withing range of budget of STORsplit
            for (int i = 0; i < s_STORList.Count; i++)
            {
                if (s_STORList[i].get_Price() <= STORSplitval)
                {
                    s_SortedSTORList.Add(s_STORList[i]);
                }
            }

            //Sorts all STORs by importance
            for (int b = 0; b < s_SortedSTORList.Count; b++)
            {
                for (int sort = 0; sort < s_SortedSTORList.Count - 1; sort++)
                {
                    if (s_SortedSTORList[sort].get_Importance() < s_SortedSTORList[sort + 1].get_Importance())
                    {
                        Storagetemp = s_SortedSTORList[sort + 1];
                        s_SortedSTORList[sort + 1] = s_SortedSTORList[sort];
                        s_SortedSTORList[sort] = Storagetemp;
                    }
                }
                for (int sort = 0; sort < s_SortedSTORList.Count - 1; sort++)
                {
                    if (s_SortedSTORList[sort].get_Importance() == s_SortedSTORList[sort + 1].get_Importance() && s_SortedSTORList[sort].get_Price() < s_SortedSTORList[sort + 1].get_Price())
                    {
                        Storagetemp = s_SortedSTORList[sort + 1];
                        s_SortedSTORList[sort + 1] = s_SortedSTORList[sort];
                        s_SortedSTORList[sort] = Storagetemp;
                    }
                }
            }

            //Fills in all compatible Auxiliary STORs withing range of budget of STORAAUXsplit
            for (int i = 0; i < s_STORAuxList.Count; i++)
            {
                if (s_STORAuxList[i].get_Price() <= STORSplitval)
                {
                    s_SortedSTORAuxList.Add(s_STORAuxList[i]);
                }
            }

            //Sorts all Auxiliary STORs by importance
            for (int b = 0; b < s_SortedSTORAuxList.Count; b++)
            {
                for (int sort = 0; sort < s_SortedSTORList.Count - 1; sort++)
                {
                    if (s_SortedSTORList[sort].get_Size() < s_SortedSTORList[sort + 1].get_Size())
                    {
                        Storagetemp = s_SortedSTORList[sort + 1];
                        s_SortedSTORList[sort + 1] = s_SortedSTORList[sort];
                        s_SortedSTORList[sort] = Storagetemp;
                    }
                }
                for (int sort = 0; sort < s_SortedSTORList.Count - 1; sort++)
                {
                    if (s_SortedSTORList[sort].get_Size() == s_SortedSTORList[sort + 1].get_Size() && s_SortedSTORList[sort].get_Price() < s_SortedSTORList[sort + 1].get_Price())
                    {
                        Storagetemp = s_SortedSTORList[sort + 1];
                        s_SortedSTORList[sort + 1] = s_SortedSTORList[sort];
                        s_SortedSTORList[sort] = Storagetemp;

                    }
                }
            }


        }

        public static void ClearLists() {

            s_SortedCPUList.Clear();
            s_SortedGPUList.Clear();
            s_SortedRAMList.Clear();
            s_SortedSTORList.Clear();
            s_SortedSTORAuxList.Clear();
            s_ComputerList.Clear();
        }

        /// <summary>
        /// This next function fills in the "Computer object" and adds them to an array of all generated computers. It first checks if there are any missing components and marks them as "None applicable". Then, it creates one good computer example, then moves one component up in its respective component list periodically,
        /// before generating 3 more computers that go up the component list in synchron.
        /// </summary>
        public static void BuildPC() {

            byte holder1 = 0;
            byte holder2 = 0;
            byte holder3 = 0;
            byte holder4 = 0;
            byte holder5 = 0;

            bool MissingCPU = false;
            bool MissingGPU = false;
            bool MissingRAM = false;
            bool MissingSTORAGE = false;
            bool MissingSTORAGEAUX = false;

            Computer Comp1 = new Computer();

            s_ComputerList.Add(Comp1);

            //Checks if there are no available CPU options and adds a "Non Applicable" object.
            if (s_SortedCPUList.Count == 0)
            {
                CPU cpu = new CPU();
                cpu.set_FullName("NoneApplicable");
                s_ComputerList[0].setCPUComp(cpu);

                MissingCPU = true;
            }

            if (s_SortedGPUList.Count == 0)
            {
                GPU gpu = new GPU();
                gpu.set_FullName("NoneApplicable");
                s_ComputerList[0].setGPUComp(gpu);
                MissingGPU = true;
            }

            if (s_SortedRAMList.Count == 0)
            {
                RAM ram = new RAM();
                ram.set_FullName("NoneApplicable");
                s_ComputerList[0].setRAMComp(ram);
                MissingRAM = true;
            }

            if (s_SortedSTORList.Count == 0)
            {
                STOR storage = new STOR();
                storage.set_FullName("NoneApplicable");
                s_ComputerList[0].setStorageComp(storage);
                MissingSTORAGE = true;
            }
            if (s_SortedSTORAuxList.Count == 0)
            {
                STOR storage = new STOR();
                storage.set_FullName("NoneApplicable");
                s_ComputerList[0].setStorageAuxComp(storage);
                MissingSTORAGEAUX = true;
            }


            //Creates ONE best optimal computer
            if (MissingCPU == false) s_ComputerList[0].setCPUComp(Object.Data.s_SortedCPUList[0]);
            if (MissingGPU == false) s_ComputerList[0].setGPUComp(Object.Data.s_SortedGPUList[0]);
            if (MissingRAM == false) s_ComputerList[0].setRAMComp(Object.Data.s_SortedRAMList[0]);
            if (MissingSTORAGE == false) s_ComputerList[0].setStorageComp(Object.Data.s_SortedSTORList[0]);
            if (MissingSTORAGEAUX == false) s_ComputerList[0].setStorageAuxComp(Object.Data.s_SortedSTORAuxList[0]);

            //Goes one up the list of the sorted components.
            if (Object.Data.s_SortedCPUList.Count + Object.Data.s_SortedGPUList.Count + Object.Data.s_SortedRAMList.Count + Object.Data.s_SortedSTORList.Count >= 12) {
                for (int i = 1; i < 11;i++)
                {
                    Computer TempComp = new Computer();

                    switch (i)
                    {
                        case (2):
                            if (holder1 + 1 < s_SortedCPUList.Count) holder1++;
                            break;
                        case (3):
                            if (holder2 + 1 < s_SortedGPUList.Count) holder2++;
                            break;
                        case (4):
                            if (holder3 + 1 < s_SortedRAMList.Count) holder3++;
                            break;
                        case (5):
                            if (holder4 + 1 < s_SortedSTORList.Count) holder4++;
                            break;
                        case(6):
                            if (holder5 + 1 < s_SortedSTORList.Count) holder5++;
                            break;
                        default:
                            //After 7 have been generated, it generates 3 more with all components going up their list at the same time.
                            if (holder1 + 1 < s_SortedCPUList.Count) holder1++;
                            if (holder2 + 1 < s_SortedGPUList.Count) holder2++;
                            if (holder3 + 1 < s_SortedRAMList.Count) holder3++;
                            if (holder4 + 1 < s_SortedSTORList.Count) holder4++;
                            if (holder5 + 1 < s_SortedSTORList.Count) holder5++;
                            break;

                    }



                    TempComp.setCPUComp(Data.s_SortedCPUList[holder1]);
                    TempComp.setGPUComp(Data.s_SortedGPUList[holder2]);
                    TempComp.setRAMComp(Data.s_SortedRAMList[holder3]);
                    TempComp.setStorageComp(Data.s_SortedSTORList[holder4]);
                    TempComp.setStorageAuxComp(Data.s_SortedSTORAuxList[holder5]);

                    s_ComputerList.Add(TempComp);
                }
            }



        }

    }
}
