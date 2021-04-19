using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;

namespace Hamilton.Business
{
    public interface IHamiltonBusiness
    {
        Task<List<string[]>> Check(
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

        public async Task<List<string[]>> Check(
            List<string> locations,
            long range)
        {
            var response = new List<string[]>();
            
            var matrix = await client.Matrix.GetMatrix(locations, range);

            var hamilton = new Core.Libs.Integration.Hamilton(locations.Count + 1);

            var result = hamilton.Check(matrix, locations.Count);

            for (int i = 0; i < result.Count; i++)              
                response.Add(result[i].Select(a => locations[a]).ToArray());

            return response;
        }
    }
}