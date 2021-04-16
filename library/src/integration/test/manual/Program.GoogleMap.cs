using System.Collections.Generic;
using System.Net.Http;
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
                        Key = "AIzaSyB0OTBpLqOJS0EfYaU-FN4u95OLVagi-ck"
                    }
                });

            var distanceMatrixRequest = new GoogleMap.Models.Routes.DistanceMatrix.DistanceMatrixRequest()
            {
                origins = new string[] { "Bệnh viện Thủ Đức" },
                destinations = new string[] { "Bệnh viện Quân Dân Y Miền Đông" },
                language = "vi"
            };

            var directionRequest = new DirectionRequest()
            {
                origin = "Thành phố Quảng Ngãi",
                destination = "Thành phố Hồ Chí Minh",
                language = "vi",
                waypoints = new string[] { "Thành phố Đà Lạt", "Thành phố Vũng Tàu" },
                mode = GoogleMap.Models.Enum.Routes.Direction.TravelMode.Driving,
                units = GoogleMap.Models.Enum.Routes.Direction.Unit.Imperial
            };

            var cities = new List<string>
            {
                "Thành phố Hồ Chí Minh",
                "Thành phố Vũng Tàu",
                "Thành phố Bà Rịa",
                "Thành phố Biên Hòa",
                "Thành phố Phan Thiết",
                "Thành phố Bảo Lộc",
                "Thành phố Đà Lạt",
                "Thành phố Phan Rang - Tháp Chàm",
                "Thành phố Tây Ninh"
            };

            // TestGetDistanceMatrix(googleMapClient, distanceMatrixRequest);

            // TestGetDirection(googleMapClient, directionRequest);

            // TestInitMatrix1(googleMapClient, cities);

            TestInitMatrix2(googleMapClient, cities);
        }

        static void TestGetDistanceMatrix(
            IGoogleMapClient googleMapClient,
            GoogleMap.Models.Routes.DistanceMatrix.DistanceMatrixRequest request)
        {
            var result = googleMapClient.DistanceMatrix
                        .GetDistanceMatrix(request)
                        .Result;

            var data = result.Data;
        }

        static void TestGetDirection(
            IGoogleMapClient googleMapClient,
            DirectionRequest request)
        {
            var result = googleMapClient.Direction
                        .GetDirection(request)
                        .Result;

            var data = result.Data;
        }

        static void TestInitMatrix1(
            IGoogleMapClient googleMapClient,
            List<string> cities)
        {
            int[,] matrix = new int[9, 9];

            for (int i = 0; i < cities.Count; i++)
            {
                for (int j = 0; j < cities.Count; j++)
                {
                    // if (i == j)
                    //     continue;

                    var direction = googleMapClient.Direction
                                    .GetDirection(new DirectionRequest()
                                    {
                                        origin = cities[i],
                                        destination = cities[j]
                                    }).Result;

                    if (direction.Data.status.Equals("OK"))
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                        continue;
                    }

                    var routes = direction.Data.routes;

                    foreach (var route in routes)
                    {
                        var legs = route.legs;

                        foreach (var leg in legs)
                        {
                            var steps = leg.steps;

                            foreach (var step in steps)
                            {

                                var geocodeDetails = googleMapClient.Geocoding
                                                .GetGeocoding(new GoogleMap.Models.Places.Geocoding.GeocodingRequest
                                                {
                                                    address = $"{step.end_location.lat},{step.end_location.lng}"
                                                }).Result;

                                var details = geocodeDetails.Data.results;

                                foreach (var detail in details)
                                {
                                    var addressComponents = detail.address_components;

                                    foreach (var addressComponent in addressComponents)
                                    {
                                        for (int k = 0; k < cities.Count; k++)
                                        {
                                            if (string.Compare(cities[k], addressComponent.long_name, true) == 0
                                                && !(string.Compare(cities[i], addressComponent.long_name, true) == 0)
                                                && !(string.Compare(cities[j], addressComponent.long_name, true) == 0))
                                            {
                                                matrix[i, j] = 0;
                                                continue;
                                            }

                                            if (string.Compare(cities[k], addressComponent.short_name, true) == 0
                                                && !(string.Compare(cities[i], addressComponent.short_name, true) == 0)
                                                && !(string.Compare(cities[j], addressComponent.short_name, true) == 0))
                                            {
                                                matrix[i, j] = 0;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void TestInitMatrix2(
            IGoogleMapClient googleMapClient,
            List<string> cities)
        {
            var range = 10000;

            int[,] matrix = new int[9, 9];

            for (int i = 0; i < cities.Count; i++)
            {
                for (int j = 0; j < cities.Count; j++)
                {
                    // if (i == j)
                    //     continue;

                    var directions = googleMapClient.Direction
                               .GetDirection(new DirectionRequest()
                               {
                                   origin = cities[i],
                                   destination = cities[j]
                               }).Result;

                    var distanceDefault = GetDistance(directions.Data);

                    if (distanceDefault > 0 || i == j)
                        matrix[i, j] = 1;

                    for (int k = 0; k < cities.Count; k++)
                    {
                        var distanceCheck = 0L;

                        if (k == i || k == j)
                            continue;

                        var checkDirections = googleMapClient.Direction
                                        .GetDirection(new DirectionRequest()
                                        {
                                            origin = cities[i],
                                            destination = cities[j],
                                            waypoints = new string[] { cities[k] }
                                        }).Result;

                        distanceCheck = GetDistance(checkDirections.Data);

                        if ((distanceCheck - distanceDefault) < range)
                            matrix[i, j] = 0;
                    }
                }
            }
        }

        static long GetDistance(Direction direction)
        {
            var distance = 0L;

            for (int i = 0; i < direction.routes.Count; i++)
            {
                for (int j = 0; j < direction.routes[i].legs.Count; j++)
                {
                    distance += direction.routes[i].legs[j].distance.value.Value;
                }
            }

            return distance;
        }
    }
}