namespace Core.Libs.Client.Models.Json
{
    public class RequestPagingJsonModel
    {
        public int page { get; set; }
        public int limit { get; set; }
        
        public static RequestPagingModel To(RequestPagingJsonModel obj)
        {
            var model = new RequestPagingModel()
            {
                Page = 1,
                Limit = 20
            };

            if (obj != null)
            {
                model.Page = obj.page;
                model.Limit = obj.limit;
            }
            
            return model;
        }
    }
}