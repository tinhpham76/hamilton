using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;

namespace Hamilton.Business
{
    public interface IHamiltonBusiness
    {
        Task<List<int[]>> Check(
            List<string> locations,
            long range);
    }

    public class HamiltonBusiness : IHamiltonBusiness
    {
        private readonly IGoogleMapClient client;
        public HamiltonBusiness(
            IGoogleMapClient client)
        {
            this.client = client;
        }

        public async Task<List<int[]>> Check(
            List<string> locations,
            long range)
        {
            var matrix = await client.Matrix.GetMatrix(locations, range);

            var hamilton = new Core.Libs.Integration.Hamilton(locations.Count + 1);

            return hamilton.Check(matrix, locations.Count);
        }
    }
}