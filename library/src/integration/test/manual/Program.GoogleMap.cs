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
                        Key = "AIzaSyB0OTBpLqOJS0EfYaU-FN4u95OLVagi-ck"
                    }
                });

            var distanceMatrixRequest = new GoogleMap.Models.DistanceMatrix.DistanceMatrixRequest()
            {
                origins = new List<string>() { "Bệnh viện Thủ Đức" },
                destinations = new List<string>() { "Bệnh viện Quân Dân Y Miền Đông" },
                language = "vi"
            };

            TestGetDistanceMatrix(googleMapClient, distanceMatrixRequest);
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
    }
}