using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ListApp.Models;
using ListApp.ViewModels;
using Xamarin.Forms;

namespace ListApp.VIews
{
    public partial class ListPage : ContentPage
    {
        public int stackchildrencount = 3;
        public bool nxtclk = true;
        public bool bckclk = false;
        public static int listcurrentholder = 0;
        public static bool Namecondition = true;
        public static bool Datecondition = true;
        public static bool Pricecondition = true;
        public ListPageViewModel modeldata;

        public ListPage()
        {
            InitializeComponent();
            modeldata = new ListPageViewModel();
            ListMethod();
        }

        private void ListMethod()
        {
            for (int i = 0; i < stackchildrencount; i++)
            {
                if (!(listcurrentholder > modeldata.sorteddata.Count - 1))
                {
                    if (modeldata.sorteddata[listcurrentholder] != null)
                    {
                        ListContentView view = new ListContentView(modeldata.sorteddata[listcurrentholder]);
                        lstData.Children.Add(view);
                    }
                ++listcurrentholder;
                }
                else
                {
                    nxtbtn.IsEnabled = false;
                    break ;
                }
            }
        }

        void NextHandle_Clicked(object sender, System.EventArgs e)
        {
            if(nxtclk)
            {
                NextBtnlistMethod();
            }

            if(bckclk)
            {
                listcurrentholder = listcurrentholder + stackchildrencount; 
                NextBtnlistMethod();
            }
            bckclk = false;
            nxtclk = true;
        }

        public void NextBtnlistMethod()
        {
            prvbtn.IsEnabled = true;
            lstData.Children.Clear();
            if (!(listcurrentholder > modeldata.sorteddata.Count - 1))
            {
                if (modeldata.sorteddata[listcurrentholder] != null)
                    ListMethod();
            }
            else
            {
                lstData.Children.Clear();
                listcurrentholder = listcurrentholder - stackchildrencount;
                nxtbtn.IsEnabled = false;
                for (int i = 0; i < stackchildrencount; i++)
                {
                    if (!(listcurrentholder > modeldata.sorteddata.Count - 1))
                        if (modeldata.sorteddata[listcurrentholder] != null)
                        {
                            ListContentView view = new ListContentView(modeldata.sorteddata[listcurrentholder]);
                            lstData.Children.Add(view);
                        }
                }
            }
        }

        void PrevHandle_Clicked(object sender, System.EventArgs e)
        {
            if (nxtclk)
            {
                listcurrentholder = listcurrentholder - lstData.Children.Count();
                BackBtnlistMethod();
            }
            if(bckclk)
            {
                BackBtnlistMethod(); 
            }
            nxtclk = false;
            bckclk = true;
        }

        public void BackBtnlistMethod()
        {
            listcurrentholder = listcurrentholder - stackchildrencount;
            nxtbtn.IsEnabled = true;
            lstData.Children.Clear();

            if (!(listcurrentholder < 0))
            {
                for (int i = 0; i < stackchildrencount; i++)
                {
                    if (modeldata.sorteddata[listcurrentholder] != null)
                    {
                        ListContentView view = new ListContentView(modeldata.sorteddata[listcurrentholder]);
                        lstData.Children.Add(view);
                    }
                    ++listcurrentholder;
                }
                listcurrentholder = listcurrentholder - stackchildrencount;
            }
            else
            {
                ++listcurrentholder;
                lstData.Children.Clear();
                for (int j = 0; j < stackchildrencount; j++)
                {
                    ListContentView view = new ListContentView(modeldata.sorteddata[j]);
                    lstData.Children.Add(view);
                    ++listcurrentholder;
                }
                prvbtn.IsEnabled = false;
            }
            if(listcurrentholder == 0)
            {
                prvbtn.IsEnabled = false;
            }
        }

        void NameHandle_Tapped(object sender, System.EventArgs e)
        {
            prvbtn.IsEnabled = false;
            nxtbtn.IsEnabled = true;
            nxtclk = true;
            bckclk = false;
            lstData.Children.Clear();
            listcurrentholder = 0;
            if(Namecondition)
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderBy(X => X.Name));
                Namecondition = false;
                ListMethod();
            }
            else
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderByDescending(X => X.Name));
                Namecondition = true;
                ListMethod();
            }
        }

        void DateRcvdHandle_Tapped(object sender, System.EventArgs e)
        {
            prvbtn.IsEnabled = false;
            nxtbtn.IsEnabled = true;
            nxtclk = true;
            bckclk = false;
            lstData.Children.Clear();
            listcurrentholder = 0;
            if (Datecondition)
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderBy(x=>x.DateReceived));
                Datecondition = false;
                ListMethod();
            }
            else
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderByDescending(X => X.DateReceived));
                Datecondition = true;
                ListMethod();
            }
        }

        void PriceHandle_Tapped(object sender, System.EventArgs e)
        {
            prvbtn.IsEnabled = false;
            nxtbtn.IsEnabled = true;
            nxtclk = true; 
            bckclk = false;
            lstData.Children.Clear();
            listcurrentholder = 0;
            if (Pricecondition)
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderBy(X => X.Price));
                Pricecondition = false;
                ListMethod();
            }
            else
            {
                modeldata.sorteddata = new ObservableCollection<ListPageModel>(modeldata.data.OrderByDescending(X => X.Price));
                Pricecondition = true;
                ListMethod();
            }
        }
    }
}
