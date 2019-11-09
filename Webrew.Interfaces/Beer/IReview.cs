using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces.Beer
{
	public interface IReview
	{
		ObjectId Id { get; set; }
        string BeerId { get; set; }
		string ReviewText { get; set; }
        float Look { get; set; }
        float Smell { get; set; }
        float Taste { get; set; }
        float Feel { get; set; }
        float Overall { get; set; }
		DateTime CreatedDate { get; set; }
		string CreatedByUser { get; set; }
	}
}