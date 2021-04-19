using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapHamilton
    {
        Task<List<Models.Hamilton.Hamilton>> Find(
            List<string> Locations,
            long Range);
    }

    public class GoogleMapHamilton : IGoogleMapHamilton
    {
        private readonly GoogleMapRoutes routes;
        public GoogleMapHamilton(
            GoogleMapRoutes routes)
        {
            this.routes = routes;
        }

        public async Task<List<Models.Hamilton.Hamilton>> Find(
            List<string> locations,
            long range)
        {
            int[,] matrix = new int[locations.Count, locations.Count];

            for (int i = 0; i < locations.Count; i++)
                for (int j = 0; j < locations.Count; j++)
                {
                    var directions = await routes.GetDirection(
                        new DirectionRequest()
                        {
                            origin = locations[i],
                            destination = locations[j]
                        });

                    var distanceDefault = GetDistance(directions.Data);

                    if (distanceDefault > 0 || i == j)
                        matrix[i, j] = 1;

                    for (int k = 0; k < locations.Count; k++)
                    {
                        var distanceCheck = 0L;

                        if (k == i || k == j)
                            continue;

                        var checkDirections = await routes.GetDirection(
                            new DirectionRequest()
                            {
                                origin = locations[i],
                                destination = locations[j],
                                waypoints = new string[] { locations[k] }
                            });

                        distanceCheck = GetDistance(checkDirections.Data);

                        if ((distanceCheck - distanceDefault) < range)
                        {
                            matrix[i, j] = 0;
                            break;
                        }
                    }
                }

            var hamilton = new Hamilton(locations.Count + 1);

            var arrHamiltons = hamilton.FindHamilton(matrix, locations.Count);

            var response = new List<Models.Hamilton.Hamilton>();

            foreach (var arrHamilton in arrHamiltons)
            {
                var arrHamiltonResponse = arrHamilton.Select(a => locations[a]).ToArray();

                var directions = new List<Direction>();

                for (int i = 0; i < arrHamiltonResponse.Length - 1; i++)
                {
                    var Temp1 = await routes.GetDirection(new DirectionRequest()
                    {
                        origin = arrHamiltonResponse[i],
                        destination = arrHamiltonResponse[i + 1]
                    });

                    directions.Add(Temp1.Data);
                }

                var result = new Models.Hamilton.Hamilton()
                {
                    hamiltons = arrHamiltonResponse,
                    directions = directions
                };

                response.Add(result);
            }

            return response;
        }

        public long GetDistance(Direction direction)
        {
            var distance = 0L;

            for (int i = 0; i < direction.routes.Count; i++)
                for (int j = 0; j < direction.routes[i].legs.Count; j++)
                    distance += direction.routes[i].legs[j].distance.value.Value;

            return distance;
        }
    }
}