using System;

namespace Core.Libs.Client.Models.Json
{
    public class BaseJsonModel<T>
    {
        public T id { get; set; }
        
        public DateTime? created_at { get; set; }
        public long? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public long? updated_by { get; set; }
        public bool? is_deleted { get; set; }
    }
}