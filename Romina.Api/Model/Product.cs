
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Romina.Api.Model
{
    [DataContract]
    public class Product
    {

        // [JsonProperty(PropertyName = "id")]
        [DataMember(Name = "id", IsRequired =true)]
        public string ProductId { get; set; }


        [DataMember(IsRequired = true)]
        public string Make { get; set; }
       
        [DataMember(IsRequired = true)]
        public string Model { get; set; }

        [DataMember(IsRequired = false)]
        public string Description { get; set; }

      
        [DataMember(IsRequired = true)]
        public double Price { get; set; }
        
        public Product()
        {

        }

        public Product(string pProductId, string pMake, string pModel, string pDescription, double pPrice)
        {
            ProductId = pProductId;
            Make = pMake;
            Model = pModel;
            Description = pDescription;
            Price = pPrice;
 
        }

    }
}
