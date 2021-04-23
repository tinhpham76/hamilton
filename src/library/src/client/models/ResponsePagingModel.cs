using System;
using System.Collections.Generic;

namespace Core.Libs.Client.Models
{
    public class ResponsePagingModel<T> where T : class
    {
        public long Total { get; set; }
        public List<T> Data { get; set; }

        public int Page { get; set; }
        public int Limit { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }

        public static ResponsePagingModel<T> From<TEntity>((long total, List<TEntity> datas) obj, Func<TEntity, T> func) where TEntity : class
        {
            if (obj.datas == null)
                return null;
                
            var model = new ResponsePagingModel<T>()
            {
                Total = obj.total,
                Data = new List<T>()
            };

            foreach (var item in obj.datas)
                model.Data.Add(func(item));

            return model;
        }
    }
}