using System;
using System.Collections.Generic;

namespace Core.Libs.Client.Models.Json
{
    public class ResponsePagingJsonModel<T> : ResponseJsonModel<List<T>> where T : class
    {
        public long total { get; set; }

        public int page { get; set; }
        public int limit { get; set; }

        public string next { get; set; }
        public string previous { get; set; }

        public static ResponsePagingJsonModel<T> From<TEntity>(ResponsePagingModel<TEntity> obj, Func<TEntity, T> func) where TEntity : class
        {
            if (obj == null)
                return null;

            var model = new ResponsePagingJsonModel<T>()
            {
                total = obj.Total,
                data = new List<T>()
            };

            foreach (var item in obj.Data)
                model.data.Add(func(item));

            return model;
        }
    }
}