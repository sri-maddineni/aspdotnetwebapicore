using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Mongocrud.Models
{
	public class InsertRecordRequest
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		public string? createdAt { get; set; }

		public string? updatedAt { get; set; }

		[Required]
		[BsonElement("Name")]
		public string? Firstname {  get; set; }

		[Required]
		public string? Lastname { get; set; }

		[Required]
		public int? age { get; set; }

		[Required]
		public string? contact { get; set; }

		
		public double salary { get; set; }
	}

	public class InsertRecordResponse
	{
		public bool success { get; set; }
		public string? message { get; set; }

	}
}
