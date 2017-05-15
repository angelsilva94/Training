using System;
using Newtonsoft.Json;



namespace Shop.Models
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "error")]
        public virtual string Error { get; set; }
        [JsonProperty(PropertyName = "message")]
        public virtual string Message { get; set; }
        [JsonProperty(PropertyName = "moreInfo")]
        public virtual string MoreInfo { get; set; }
    }

    public class InvalidNullUser :ErrorResponse
    {
        public override string Error => "#400User";
        public override string Message => "The Object User cannot be null.";
        public override string MoreInfo => "www.moreinfo.info";
    }

    public class InvalidEmailUser : ErrorResponse
    {
        public override string Error => "#400Email";
        public override string Message => "The Email is not Valid";
        public override string MoreInfo => "www.moreinfo.info";
    }
}
