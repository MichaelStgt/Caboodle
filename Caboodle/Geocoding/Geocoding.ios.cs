﻿using CoreLocation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Caboodle
{
	public partial class Geocoding
    {
        public static async Task<IEnumerable<Address>> GetAddressesAsync(double latitude, double longitude)
        {
            using (var geocoder = new CLGeocoder())
            {
                var addressList = await geocoder.ReverseGeocodeLocationAsync(new CLLocation(latitude, longitude));

                return addressList?.ToAddresses();
            }
        }

        public static async Task<IEnumerable<Position>> GetPositionsAsync(string address)
        {

            using (var geocoder = new CLGeocoder())
            {
                var positionList = await geocoder.GeocodeAddressAsync(address);

                return positionList?.Select(p => new Position
                {
                    Latitude = p.Location.Coordinate.Latitude,
                    Longitude = p.Location.Coordinate.Longitude
                });
            }
        }
    }
}
