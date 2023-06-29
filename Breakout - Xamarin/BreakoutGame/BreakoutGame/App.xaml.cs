﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BreakoutGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                MainPage = new NavigationPage(new HomePage());
                
                return false;
            });
        }

    }
}
