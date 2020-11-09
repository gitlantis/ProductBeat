using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskAPI.Models
{
    public class Beat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BeaterId { get; set; }
        public decimal Price { get; set; }
        public DateTime BeatTime { get; set; }
    }
}