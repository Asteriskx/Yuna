using System.Runtime.Serialization;

namespace Yuna.Models
{
	[DataContract]
	public class SongArtist
	{
		[DataMember(Name = "artistName")]
		public string ArtistName { get; set; }

		[DataMember(Name = "artistId")]
		public long ArtistId { get; set; }

		[DataMember(Name = "artistType")]
		public string ArtistType { get; set; }

		[DataMember(Name = "artistLinkUrl")]
		public string ArtistLinkUrl { get; set; }

		[DataMember(Name = "amgArtistId")]
		public long AMGArtistId { get; set; }

		[DataMember(Name = "primaryGenreName")]
		public string PrimaryGenreName { get; set; }

		[DataMember(Name = "primaryGenreId")]
		public long PrimaryGenreId { get; set; }
	}
}
