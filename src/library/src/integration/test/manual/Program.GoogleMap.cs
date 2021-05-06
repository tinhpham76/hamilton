using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Core.Libs.Integration.GoogleMap;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void TestGoogleMap()
        {
            var googleMapClient = new GoogleMapClient(
                new HttpClient(),
                new IntegrationConfig()
                {
                    GoogleMap = new GoogleMapConfig()
                    {

                    }
                });

            var key = "AIzaSyB0OTBpLqOJS0EfYaU-FN4u95OLVagi-ck";

            var distanceMatrixRequest = new GoogleMap.Models.Routes.DistanceMatrix.DistanceMatrixRequest()
            {
                origins = "Bệnh viện Thủ Đức",
                destinations = "Bệnh viện Quân Dân Y Miền Đông",
                language = "vi"
            };

            var directionRequest = new DirectionRequest()
            {
                origin = "Thành phố Quảng Ngãi",
                destination = "Thành phố Hồ Chí Minh",
                language = "vi",
                waypoints = "Thành phố Đà Lạt|Thành phố Vũng Tàu",
                mode = GoogleMap.Models.Enum.Routes.TravelMode.Driving,
                units = GoogleMap.Models.Enum.Routes.Unit.Imperial
            };

            var cities = new List<string>
            {
                "Thành phố Hồ Chí Minh",
                "Thành phố Vũng Tàu",
                "Thành phố Biên Hòa",
                "Thành phố Phan Thiết",
                "Thành phố Bảo Lộc",
                "Thành phố Đà Lạt",
            };

            var locations = new List<Location>()
                {   
                    // Thành phố Hồ Chí Minh
                    new Location()
                    {
                        lat = 10.8230989,
                        lng = 106.6296638
                    },
                    // Thành phố Vũng Tàu
                    new Location()
                    {
                        lat = 10.4113797,
                        lng = 107.136224
                    },
                    // Thành phố Biên Hòa
                    new Location()
                    {
                        lat = 10.9574128,
                        lng = 106.8426871
                    },
                    // Thành phố Phan Thiết
                    new Location()
                    {
                        lat = 10.9804603,
                        lng = 108.2614775
                    },
                    // Thành phố Bảo Lộc
                    new Location()
                    {
                        lat = 11.5731051,
                        lng = 107.8346924
                    },
                    // Thành phố Đà Lạt
                    new Location()
                    {
                        lat = 11.9404192,
                        lng = 108.4583132
                    },
                };

            // TestGetDistanceMatrix(googleMapClient, distanceMatrixRequest);

            // TestGetDirection(googleMapClient, directionRequest);

            // TestInitMatrix(googleMapClient, cities);

            // var result = polyliner.Decode(polyline);

            // TestInitMatrixAsync(googleMapClient, cities);

            // TestFindPlace(googleMapClient, key);

            // TestNearbySearch(googleMapClient, key);

            // TestTextSearch(googleMapClient, key);

            TestGetGeocoding(googleMapClient, key);

            // TestGetPlaceDetail(googleMapClient, key);

            // TestGetPlaceAutocomplete(googleMapClient, key);

            // TestGetQueryAutocomplete(googleMapClient, key);

            // TestHamilton(googleMapClient, cities, key);
        }

        static void TestHamilton(
            IGoogleMapClient googleMapClient,
            List<string> cities,
            string key)
        {
            var result = googleMapClient.Hamilton
                        .Find(cities, 10000, key)
                        .Result;
        }

        static void TestGetQueryAutocomplete(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .QueryAutocomplete(new GoogleMap.Models.Places.QueryAutocompleteRequest()
                        {
                            input = "Bến Thà"
                        }, key).Result;
        }

        static void TestGetPlaceAutocomplete(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .PlaceAutocomplete(new GoogleMap.Models.Places.PlaceAutocompleteRequest()
                        {
                            input = "Bến Thành"
                        }, key).Result;
        }

        static void TestGetPlaceDetail(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .PlaceDetail(new GoogleMap.Models.Places.PlaceDetailRequest()
                        {
                            place_id = "ChIJN1t_tDeuEmsRUsoyG83frY4"
                        }, key).Result;
        }

        static void TestGetGeocoding(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .Geocoding(new GoogleMap.Models.Places.GeocodingRequest()
                        {
                            address = "Thành phố Hồ Chí Minh"
                        }, key).Result;
        }

        static void TestTextSearch(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .TextSearch(new GoogleMap.Models.Places.PlaceSearch.TextSearchRequest()
                        {
                            query = "Bến Thành"
                        }, key).Result;
        }

        static void TestNearbySearch(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                    .NearbySearch(new GoogleMap.Models.Places.PlaceSearch.NearbySearchRequest()
                    {
                        location = "10.8230989,106.6296638",
                        radius = 150000
                    }, key).Result;
        }

        static void TestFindPlace(
            IGoogleMapClient googleMapClient,
            string key)
        {
            var result = googleMapClient.Places
                        .FindPlace(new GoogleMap.Models.Places.PlaceSearch.FindPlaceRequest()
                        {
                            input = "Thành phố Hồ Chí Minh"
                        }, key).Result;
        }

        static void TestInitMatrixAsync(
           IGoogleMapClient googleMapClient,
           List<string> locations,
           string key)
        {
            var result = googleMapClient.Hamilton
                .Find(locations, 10000, key).Result;
        }

        static void TestGetDistanceMatrix(
            IGoogleMapClient googleMapClient,
            GoogleMap.Models.Routes.DistanceMatrix.DistanceMatrixRequest request,
            string key)
        {
            var result = googleMapClient.Routes
                        .GetDistanceMatrix(request, key)
                        .Result;

            var data = result.Data;
        }

        static void TestGetDirection(
            IGoogleMapClient googleMapClient,
            DirectionRequest request,
            string key)
        {
            var result = googleMapClient.Routes
                        .GetDirection(request, key)
                        .Result;

            var data = result.Data;
        }

        static void TestInitMatrix(
            IGoogleMapClient googleMapClient,
            List<string> cities,
            string key)
        {
            var range = 10000;

            int[,] matrix = new int[9, 9];

            for (int i = 0; i < cities.Count; i++)
                for (int j = 0; j < cities.Count; j++)
                {
                    var directions = googleMapClient.Routes
                                .GetDirection(new DirectionRequest()
                                {
                                    origin = cities[i],
                                    destination = cities[j]
                                }, key).Result;

                    var distanceDefault = GetDistance(directions.Data);

                    if (distanceDefault > 0 || i == j)
                        matrix[i, j] = 1;

                    for (int k = 0; k < cities.Count; k++)
                    {
                        var distanceCheck = 0L;

                        if (k == i || k == j)
                            continue;

                        var checkDirections = googleMapClient.Routes
                                        .GetDirection(new DirectionRequest()
                                        {
                                            origin = cities[i],
                                            destination = cities[j],
                                            waypoints = cities[k]
                                        }, key).Result;

                        distanceCheck = GetDistance(checkDirections.Data);

                        if ((distanceCheck - distanceDefault) < range)
                            matrix[i, j] = 0;
                    }
                }
            var hamilton = new Hamilton(10);
            var arrayHamilton = hamilton.FindHamilton(matrix, cities.Count);
        }

        static long GetDistance(Direction direction)
        {
            var distance = 0L;

            for (int i = 0; i < direction.routes.Count; i++)
                for (int j = 0; j < direction.routes[i].legs.Count; j++)
                    distance += direction.routes[i].legs[j].distance.value.Value;

            return distance;
        }

        #region Google Direction PolyLine
        static IEnumerable<Location> Decode(string polylineString)
        {
            if (string.IsNullOrEmpty(polylineString))
                throw new ArgumentNullException(nameof(polylineString));

            var polylineChars = polylineString.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Next lat
                var sum = 0;
                var shifter = 0;
                int nextFiveBits;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Next lng
                sum = 0;
                shifter = 0;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && nextFiveBits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                yield return new Location
                {
                    lat = Convert.ToDouble(currentLat) / 1E5,
                    lng = Convert.ToDouble(currentLng) / 1E5
                };
            }
        }

        static string Encode(IEnumerable<Location> locations)
        {
            var str = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                var shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                var rem = shifted;

                while (rem >= 0x20)
                {
                    str.Append((char)((0x20 | (rem & 0x1f)) + 63));

                    rem >>= 5;
                }

                str.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;

            foreach (var point in locations)
            {
                var lat = (int)Math.Round(point.lat.Value * 1E5);
                var lng = (int)Math.Round(point.lng.Value * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return str.ToString();
        }

        #endregion
    }
}