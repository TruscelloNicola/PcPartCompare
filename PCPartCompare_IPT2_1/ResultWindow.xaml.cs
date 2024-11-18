using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PCPartCompare_IPT2_1
{
    /// <summary>
    /// Interaktionslogik für ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        List<string> CPUDisp = new List<string>();
        List<string> GPUDisp = new List<string>();
        List<string> RAMDisp = new List<string>();
        List<string> STORDisp = new List<string>();
        List<string> STORAUXDisp = new List<string>();
        public ResultWindow()
        {
            InitializeComponent();
            ComputerLister();
        }

        private void ComputerLister()
        {
            Object.Computer Cache;
            CPU CPUCache;
            GPU GPUCache;
            RAM RAMCache;
            STOR STORCache;
            STOR STORAUXCache;

            CPUDisp.Clear();
            GPUDisp.Clear();
            RAMDisp.Clear();
            STORDisp.Clear();
            STORAUXDisp.Clear();

            for (int i = 0; i < Object.Data.s_ComputerList.Count; i++)
            {
                Cache = (Object.Computer)Object.Data.s_ComputerList[i];
                CPUCache = Cache.getCPUComp();
                GPUCache = Cache.getGPUComp();
                RAMCache = Cache.getRAMComp();
                STORCache = Cache.getStorageComp();
                STORAUXCache = Cache.getStorageAuxComp();

                CPUDisp.Add(CPUCache.get_FullName());
                GPUDisp.Add(GPUCache.get_FullName());
                RAMDisp.Add(RAMCache.get_FullName());
                STORDisp.Add(STORCache.get_FullName());
                STORAUXDisp.Add(STORAUXCache.get_FullName());


            }

            ListBoxCol1.ItemsSource = CPUDisp;
            ListBoxCol2.ItemsSource = GPUDisp;
            ListBoxCol3.ItemsSource = RAMDisp;
            ListBoxCol4.ItemsSource = STORDisp;
            ListBoxCol5.ItemsSource = STORAUXDisp;
        }

    }
}
