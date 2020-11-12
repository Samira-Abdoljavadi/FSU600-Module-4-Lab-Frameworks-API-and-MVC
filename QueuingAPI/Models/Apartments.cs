using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QueuingAPI.Models
{
    public class Apartments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string objectId { get; set; }

        public int id { get; set; }

        //[JsonProperty(PropertyName = "id")]
        //public string Id { get; set; }


        [JsonProperty(PropertyName = "Situation")]
        public string Situation { get; set; }

        [JsonProperty(PropertyName = "Street")]
        [Required]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "Area")]
        [Display(Name = "Zone")]
        public string Area { get; set; }

        [JsonProperty(PropertyName = "City")]
        [Required]
        public string City { get; set; }

        [JsonProperty(PropertyName = "Rooms")]
        [Required]
        public int Rooms { get; set; }

        [JsonProperty(PropertyName = "SquareMeters")]
        [Display(Name = "Area")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal SquareMeters { get; set; }

        [JsonProperty(PropertyName = "Rent")]
        [Required]
        public int Rent { get; set; }

        [JsonProperty(PropertyName = "MoveInDate")]
        [Display(Name = "Move in Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime MoveInDate { get; set; }

        [JsonProperty(PropertyName = "Floor")]
        [Required]
        public int Floor { get; set; }

        [JsonProperty(PropertyName = "WholeFloor")]
        [Display(Name = "Whole Floor")]
        public int WholeFloor { get; set; }

        [JsonProperty(PropertyName = "PublishDate")]
        [Display(Name = "Publish Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] //To remove time from display
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "Pets")]
        public string Pets { get; set; }

        [JsonProperty(PropertyName = "Smoke")]
        public string Smoke { get; set; }

        [JsonProperty(PropertyName = "LandlordComments")]
        [Display(Name = "Landlord Comments")]
        public string LandlordComments { get; set; }

        [JsonProperty(PropertyName = "Properties")]
        public string Properties { get; set; }

        [JsonProperty(PropertyName = "RentInclude")]
        [Display(Name = "Rent Include")]
        public string RentInclude { get; set; }

        [JsonProperty(PropertyName = "ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

    }
}
