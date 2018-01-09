using System;
using System.Collections.Generic;
using ListApp.Models;
using Xamarin.Forms;

namespace ListApp.VIews
{
    public partial class ListContentView : ContentView
    {
        public ListContentView(ListPageModel data)
        {
            InitializeComponent();
            this.BindingContext = data;
        }
    }
}
