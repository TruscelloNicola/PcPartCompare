using Microsoft.Win32;
using PCPartCompare_IPT2_1.ComponentDBDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static PCPartCompare_IPT2_1.ComponentDBDataSet;

namespace PCPartCompare_IPT2_1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Object.Data.ReadAllDataIn();
            fillUseCase();

        }

        List<string> CoreList = new List<string>();
        List<string> CoreList2 = new List<string>();
        List<string> CoreList3 = new List<string>();
        List<string> CoreList4 = new List<string>();
        List<string> CoreList5 = new List<string>();
        List<string> CoreList6 = new List<string>();
        List<string> CoreList7 = new List<string>();
        List<string> CoreList8 = new List<string>();
        UseCase SelUseCase;

        private void fillUseCase()
        {

            for (int i = 0; i < Object.Data.s_UseCase.Count; i++)
            {
                UseCaseBox.Items.Add(Object.Data.s_UseCase[i].get_FullName());
            }
        }
        private void CPULister(object sender, RoutedEventArgs e)
        {
            ClearList();


            for (int i = 0; i < Object.Data.s_CPUList.Count; i++)
            {
                CoreList.Add(Object.Data.s_CPUList[i].get_FullName());
                CoreList2.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Company()));
                CoreList3.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Cores()));
                CoreList4.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Threads()));
                CoreList5.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Socket()));
                CoreList6.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Frequency()));
                CoreList7.Add(Convert.ToString(Object.Data.s_CPUList[i].get_FrequencyBoost()));
                CoreList8.Add(Convert.ToString(Object.Data.s_CPUList[i].get_Price()));
            }


            fillList();
            Label1.Content = "Name";
            Label2.Content = "Company";
            Label3.Content = "Cores";
            Label4.Content = "Socket";
            Label5.Content = "Company";
            Label6.Content = "Frequency";
            Label7.Content = "Freq. Boost";
            Label8.Content = "Price";
        }
        private void GPULister(object sender, RoutedEventArgs e)
        {
            ClearList();


            CoreList.Clear();
            for (int i = 0; i < Object.Data.s_GPUList.Count; i++)
            {
                CoreList.Add(Object.Data.s_GPUList[i].get_FullName());
                CoreList2.Add(Convert.ToString(Object.Data.s_GPUList[i].get_Company()));
                CoreList3.Add(Convert.ToString(Object.Data.s_GPUList[i].get_Generation()));
                CoreList4.Add(Convert.ToString(Object.Data.s_GPUList[i].get_Price()));
            }


            fillList();
            Label1.Content = "Name";
            Label2.Content = "Generation";
            Label3.Content = "Company";
            Label4.Content = "Price";
        }
        private void RAMLister(object sender, RoutedEventArgs e)
        {
            ClearList();


            CoreList.Clear();
            for (int i = 0; i < Object.Data.s_RAMList.Count; i++)
            {
                CoreList.Add(Object.Data.s_RAMList[i].get_FullName());
                CoreList2.Add(Convert.ToString(Object.Data.s_RAMList[i].get_Company()));
                CoreList3.Add(Convert.ToString(Object.Data.s_RAMList[i].get_DDRGeneration()));
                CoreList4.Add(Convert.ToString(Object.Data.s_RAMList[i].get_Latency()));
                CoreList5.Add(Convert.ToString(Object.Data.s_RAMList[i].get_MegaTransferPerSec()));
                CoreList6.Add(Convert.ToString(Object.Data.s_RAMList[i].get_Size()));
                CoreList7.Add(Convert.ToString(Object.Data.s_RAMList[i].get_Price()));
            }




            fillList();
            Label1.Content = "Name";
            Label2.Content = "Company";
            Label3.Content = "DDR Gen";
            Label4.Content = "CL Latency";
            Label5.Content = "MT/s";
            Label6.Content = "Size";
            Label7.Content = "Price";
        }
        private void StorageLister(object sender, RoutedEventArgs e)
        {
            ClearList();

            CoreList.Clear();
            for (int i = 0; i < Object.Data.s_STORList.Count; i++)
            {
                CoreList.Add(Object.Data.s_STORList[i].get_FullName());
                CoreList2.Add(Convert.ToString(Object.Data.s_STORList[i].get_Company()));
                CoreList3.Add(Convert.ToString(Object.Data.s_STORList[i].get_Size()));
                CoreList4.Add(Convert.ToString(Object.Data.s_STORList[i].get_FormFactor()));
                CoreList5.Add(Convert.ToString(Object.Data.s_STORList[i].get_Type()));
                CoreList6.Add(Convert.ToString(Object.Data.s_STORList[i].get_Price()));
            }


            fillList();
            Label1.Content = "Name";
            Label2.Content = "Company";
            Label3.Content = "Size/GB";
            Label4.Content = "Form Factor";
            Label5.Content = "Type";
            Label6.Content = "Price";
        }
        private void ClearList()
        {
            CoreList.Clear();
            CoreList2.Clear();
            CoreList3.Clear();
            CoreList4.Clear();
            CoreList5.Clear();
            CoreList6.Clear();
            CoreList7.Clear();
            CoreList8.Clear();
            ListBoxCol1.ItemsSource = null;
            ListBoxCol2.ItemsSource = null;
            ListBoxCol3.ItemsSource = null;
            ListBoxCol4.ItemsSource = null;
            ListBoxCol5.ItemsSource = null;
            ListBoxCol6.ItemsSource = null;
            ListBoxCol7.ItemsSource = null;
            ListBoxCol8.ItemsSource = null;
            Label1.Content = "";
            Label2.Content = "";
            Label3.Content = "";
            Label4.Content = "";
            Label5.Content = "";
            Label6.Content = "";
            Label7.Content = "";
            Label8.Content = "";
        }
        private void fillList() {
            ListBoxCol1.ItemsSource = CoreList;
            ListBoxCol2.ItemsSource = CoreList2;
            ListBoxCol3.ItemsSource = CoreList3;
            ListBoxCol4.ItemsSource = CoreList4;
            ListBoxCol5.ItemsSource = CoreList5;
            ListBoxCol6.ItemsSource = CoreList6;
            ListBoxCol7.ItemsSource = CoreList7;
            ListBoxCol8.ItemsSource = CoreList8;
        }
        private void GenerationStart(object sender, RoutedEventArgs e)
        {

            switch (UseCaseBox.Text)
            {
                case "Office":
                    SelUseCase = Object.Data.s_UseCase[0];
                    break;
                case "Gaming":
                    SelUseCase = Object.Data.s_UseCase[1];
                    break;

                default:
                    SelUseCase = Object.Data.s_UseCase[0];
                    break;
            }

            Object.Data.ClearLists();
            Object.Data.Algo(SelUseCase, Convert.ToInt32(BudgetBox.Text));
            Object.Data.BuildPC();
            ResultWindow result = new ResultWindow();
            result.Show();
        }


        private void ChangedSelection(object sender, EventArgs e)
        {
            switch (UseCaseBox.Text)
            {
                case "Office":
                    SelUseCase = Object.Data.s_UseCase[0];
                    break;
                case "Gaming":
                    SelUseCase = Object.Data.s_UseCase[1];
                    break;

                default:
                    SelUseCase = Object.Data.s_UseCase[0];
                    break;
            }

            byte CPUGridProcessed = Convert.ToByte(Math.Round(230 * (SelUseCase.get_CPUPercent() / (SelUseCase.get_CPUPercent() + SelUseCase.get_GPUPercent()))));
            byte RAMGridProcessed = Convert.ToByte(Math.Round(230 * SelUseCase.get_RAMPercent() / (SelUseCase.get_RAMPercent() + SelUseCase.get_STORPercent() + SelUseCase.get_STORAUXPercent())));
            byte STORGridProcessed = Convert.ToByte(Math.Round(230 * SelUseCase.get_STORPercent() / (SelUseCase.get_RAMPercent() + SelUseCase.get_STORPercent() + SelUseCase.get_STORAUXPercent())));

            CPUBoxSplit.Width = new GridLength(CPUGridProcessed);
            GPUBoxSplit.Width = new GridLength(230 - CPUGridProcessed);
            RAMBoxSplit.Width = new GridLength(RAMGridProcessed);
            StorageBoxSplit.Width = new GridLength(STORGridProcessed);
            StorageAuxBoxSplit.Width = new GridLength(230 - RAMGridProcessed - STORGridProcessed);
        }
    }
}
