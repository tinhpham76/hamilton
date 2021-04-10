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
                        Key = ""
                    }
                });

            var distanceMatrixRequest = new GoogleMap.Models.DistanceMatrix.DistanceMatrixRequest()
            {
                origins = new List<string>() { "Bệnh viện Thủ Đức" },
                destinations = new List<string>() { "Bệnh viện Quân Dân Y Miền Đông" },
                language = "vi"
            };

            var directionRequest = new DirectionRequest()
            {
                origin = "Thành phố Quảng Ngãi",
                destination = "Thành phố Hồ Chí Minh",
                language = "vi",
                waypoints = new string[]{"Thành phố Đà Lạt", "Thành phố Vũng Tàu"},
                mode = GoogleMap.Models.Enum.Routes.Direction.TravelMode.Driving,
                units = GoogleMap.Models.Enum.Routes.Direction.Unit.Imperial
            };


            // TestGetDistanceMatrix(googleMapClient, distanceMatrixRequest);

            TestGetDirection(googleMapClient, directionRequest);
        }

        static void TestGetDistanceMatrix(
            IGoogleMapClient googleMapClient,
            GoogleMap.Models.DistanceMatrix.DistanceMatrixRequest request)
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
    }
}