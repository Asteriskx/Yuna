using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Yuna.Models
{
	[DataContract]
	public class SongResponse
	{
		[DataMember(Name = "resultCount")]
		public int Count { get; set; }

		[DataMember(Name = "results")]
		public List<Song> Songs { get; set; }
	}
}