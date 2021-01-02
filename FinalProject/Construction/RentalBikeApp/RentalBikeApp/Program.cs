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

namespace RentalBikeApp
{
    static class Program
    {
        public static HomePageForm homePageForm;
        public static StationDetailForm stationDetailForm;
        public static BikeDetailForm bikeDetailForm;
        public static CardInformationForm cardInformationForm;
        public static ListBikeForm listBikeForm;
        public static RentBikeForm rentBikeForm;
        public static RentBikeInfoForm rentBikeInfoForm;
        public static RentingBikeForm rentingBikeForm;
        public static ReturnBikeForm returnBikeForm;
        public static TransactionInformationForm transactionInformationForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            homePageForm = new HomePageForm();
            stationDetailForm = new StationDetailForm();
            bikeDetailForm = new BikeDetailForm();
            cardInformationForm = new CardInformationForm();
            listBikeForm = new ListBikeForm();
            rentBikeForm = new RentBikeForm();
            rentBikeInfoForm = new RentBikeInfoForm();
            rentingBikeForm = new RentingBikeForm();
            returnBikeForm = new ReturnBikeForm();
            transactionInformationForm = new TransactionInformationForm();

            Application.Run(homePageForm);
        }
    }
}
