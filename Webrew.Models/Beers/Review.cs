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
        public decimal Look { get; set; }
        public decimal Smell { get; set; }
        public decimal Taste { get; set; }
        public decimal Feel { get; set; }
        public decimal Overall { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedByUser { get; set; }
	}
}