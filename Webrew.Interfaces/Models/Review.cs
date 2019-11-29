using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
    public class Review : Entity
    {
        public ObjectId BeerId { get; set; }
        public string Summary { get; set; }
        public decimal Look { get; set; }
        public decimal Smell { get; set; }
        public decimal Taste { get; set; }
        public decimal Feel { get; set; }
        public decimal Overall { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUser { get; set; }
    }
}
