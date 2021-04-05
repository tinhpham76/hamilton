using System;

namespace Core.Libs.Utils.Models.Businesses
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        
        public long AccountId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}