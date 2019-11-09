using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces.Beer;

namespace Webrew.Models.Beers
{
	public class Review : Entity, IReview
	{
		public string BeerId { get; set; }
        public string ReviewText { get; set; }
        public float Look { get; set; }
        public float Smell { get; set; }
        public float Taste { get; set; }
        public float Feel { get; set; }
        public float Overall { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedByUser { get; set; }
	}
}