using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
	public class Review : Entity
	{
		public ObjectId BeerId { get; set; }
		public string ReviewText { get; set; }
		public float Look { get; set; }
		public float Smell { get; set; }
		public float Taste { get; set; }
		public float Feel { get; set; }
		public float Overall { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedByUser { get; set; }
	}
}
