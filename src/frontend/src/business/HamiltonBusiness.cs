using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;

namespace Hamilton.Business
{
    public interface IHamiltonBusiness
    {
        Task<List<Core.Libs.Integration.GoogleMap.Models.Hamilton.Hamilton>> Check(
            List<string> locations,
            long range,
            string key);
    }

    public class HamiltonBusiness : IHamiltonBusiness
    {
        private readonly IGoogleMapClient client;
        public HamiltonBusiness(
            IGoogleMapClient client)
        {
            this.client = client;
        }

        public async Task<List<Core.Libs.Integration.GoogleMap.Models.Hamilton.Hamilton>> Check(
            List<string> locations,
            long range,
            string key)
        {
            var response = await client.Hamilton.Find(locations, range, key);

            return response;
        }
    }
}