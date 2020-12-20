﻿// --------------------RENTAL BIKE APP-----------------
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

using RentalBikeApp.Entities.SQLEntities;
using System.Collections.Generic;

namespace RentalBikeApp.Data.ServiceAgents.BikeServices
{
    /// <summary>
    /// The service IBikeService implements the functions to interact BaseBike in database
    /// </summary>
    /// <typeparam name="TBike"></typeparam>
    public interface IBikeService<TBike>
    {
        public TBike GetBikeByQRCode(string QRCode);
        public TBike GetBikeById(int id);
        public List<TBike> GetListBikesInStation(int stationId);
        public TBike UpdateBike(int bikeId, UpdateBikeInfo update);
    }
}
