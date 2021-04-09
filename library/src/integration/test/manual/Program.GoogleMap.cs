using System.Collections.Generic;
using System.Net.Http;
using Core.Libs.Integration.GoogleMap;

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

            var directionRequest = new GoogleMap.Models.Direction.DirectionRequest()
            {
                origin = "Thành phố Quảng Ngãi",
                destination = "Thành phố Hồ Chí Minh",
                language = "vi"
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
            GoogleMap.Models.Direction.DirectionRequest request)
        {
            var result = googleMapClient.Direction
                        .GetDirection(request)
                        .Result;

            var data = result.Data;
        }
    }
}