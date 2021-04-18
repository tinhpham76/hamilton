using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapMatrix
    {
        Task<int[,]> GetMatrix(
            List<Location> Locations,
            long Range);

        Task<int[,]> GetMatrix(
           List<string> Locations,
           long Range);
    }

    public class GoogleMapMatrix : IGoogleMapMatrix
    {
        private readonly GoogleMapDirection direction;
        public GoogleMapMatrix(
            GoogleMapDirection direction)
        {
            this.direction = direction;
        }

        public async Task<int[,]> GetMatrix(
            List<Location> locations,
            long range)
        {
            int[,] matrix = new int[locations.Count, locations.Count];

            for (int i = 0; i < locations.Count; i++)
                for (int j = 0; j < locations.Count; j++)
                {
                    var directions = await direction.GetDirection(
                        new DirectionRequest()
                        {
                            origin = GetLocationRequestParam(locations[i]),
                            destination = GetLocationRequestParam(locations[j])
                        });

                    var distanceDefault = GetDistance(directions.Data);

                    if (distanceDefault > 0 || i == j)
                        matrix[i, j] = 1;

                    for (int k = 0; k < locations.Count; k++)
                    {
                        var distanceCheck = 0L;

                        if (k == i || k == j)
                            continue;

                        var checkDirections = await direction.GetDirection(
                            new DirectionRequest()
                            {
                                origin = GetLocationRequestParam(locations[i]),
                                destination = GetLocationRequestParam(locations[j]),
                                waypoints = new string[] { GetLocationRequestParam(locations[k]) }
                            });

                        distanceCheck = GetDistance(checkDirections.Data);

                        if ((distanceCheck - distanceDefault) < range)
                        {
                            matrix[i, j] = 0;
                            break;
                        }

                    }
                }

            return matrix;
        }

        private string GetLocationRequestParam(Location location)
        {
            return $"{location.lat},{location.lng}";
        }

        public long GetDistance(Direction direction)
        {
            var distance = 0L;

            for (int i = 0; i < direction.routes.Count; i++)
                for (int j = 0; j < direction.routes[i].legs.Count; j++)
                    distance += direction.routes[i].legs[j].distance.value.Value;

            return distance;
        }

        public async Task<int[,]> GetMatrix(List<string> locations, long range)
        {
            int[,] matrix = new int[locations.Count, locations.Count];

            for (int i = 0; i < locations.Count; i++)
                for (int j = 0; j < locations.Count; j++)
                {
                    var directions = await direction.GetDirection(
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

                        var checkDirections = await direction.GetDirection(
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

            return matrix;
        }
    }
}