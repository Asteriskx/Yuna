using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Yuna.Models
{
	[DataContract]
	public class AlbumResponse
	{
		[DataMember(Name = "resultCount")]
		public int Count { get; set; }

		[DataMember(Name = "results")]
		public List<Album> Albums { get; set; }
	}
}
