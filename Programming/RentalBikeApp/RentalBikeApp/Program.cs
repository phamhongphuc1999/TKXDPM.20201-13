// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

using System;
using RentalBikeApp.Presentation;
using System.Windows.Forms;
using RentalBikeApp.Data;

namespace RentalBikeApp
{
    static class Program
    {
        public static SQLConnecter connecter;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
            HomePageForm homePage = new HomePageForm();
            Application.Run(homePage);
        }
    }
}
