using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Yuna.Models
{
	[DataContract]
	public class SongArtistResponse
	{
		[DataMember(Name = "resultCount")]
		public int Count { get; set; }

		[DataMember(Name = "results")]
		public List<SongArtist> Artists { get; set; }
	}
}
