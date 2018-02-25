﻿using Android.App;
using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
	public partial class Geocoding
    {
        public static async Task<IEnumerable<Address>> GetAddressesAsync(double latitude, double longitude)
        {
            using (var geocoder = new Geocoder(Application.Context))
            {
                var addressList = await geocoder.GetFromLocationAsync(latitude, longitude, 10);
                return addressList?.ToAddresses();
            }
        }

        public static async Task<IEnumerable<Position>> GetPositionsAsync(string address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            using (var geocoder = new Geocoder(Application.Context))
            {
                var addressList = await geocoder.GetFromLocationNameAsync(address, 10);

                return addressList?.Select(p => new Position
                {
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                });
            }
        }
    }

}