using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Yuna.Interop.Utility;

namespace Yuna.Models
{
	/// <summary>
	/// iTunes Search API 管理クラス
	/// </summary>
	public class SearchManager
	{
		#region Readonly Field

		/// <summary>
		/// iTunes Search API 検索用の URL
		/// </summary>
		private static readonly string _searchUrl = "https://itunes.apple.com/search?{0}";

		/// <summary>
		/// iTunes Search API 検索用の URL
		/// </summary>
		private static readonly string _lookupUrl = "https://itunes.apple.com/lookup?{0}";

		#endregion Readonly Field

		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SearchManager() { }

		#endregion Constructor

		#region Search Methods

		/// <summary>
		/// iTunes ID に紐付く一意なアーティストを取得します。
		/// </summary>
		/// <param name="artistId">アーティストID</param>
		/// <returns></returns>
		public async Task<SongArtist> GetSongArtistByArtistIdAsync(long artistId)
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);
			parsedString.Add("id", artistId.ToString());

			string url = string.Format(_lookupUrl, parsedString.ToString());
			return (await this.CreateConnection<SongArtistResponse>(url)).Artists.FirstOrDefault() ?? new SongArtist();
		}

		/// <summary>
		/// AMG ID に紐付く一意なアーティストを取得します。
		/// </summary>
		/// <param name="amgArtistId">AMG ID</param>
		/// <returns></returns>
		public async Task<SongArtist> GetSongArtistByAMGArtistIdAsync(long amgArtistId)
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);
			parsedString.Add("amgArtistId", amgArtistId.ToString());

			string url = string.Format(_lookupUrl, parsedString.ToString());
			return (await this.CreateConnection<SongArtistResponse>(url)).Artists.FirstOrDefault() ?? new SongArtist();
		}

		/// <summary>
		/// iTunes ID に紐付くアーティストが属するアルバムを取得します。
		/// </summary>
		/// <param name="artistId">アーティストID</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<AlbumResponse> GetAlbumsByArtistIdAsync(long artistId, int limit = 100, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("id", artistId.ToString());
			parsedString.Add("entity", "album");
			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_lookupUrl, parsedString.ToString());
			return await this.CreateConnection<AlbumResponse>(url);
		}

		/// <summary>
		/// AMG ID に紐付くアーティストが属するアルバムを取得します。
		/// </summary>
		/// <param name="amgArtistId">AMGに紐付くアーティストID</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<AlbumResponse> GetAlbumsByAMGArtistIdAsync(long amgArtistId, int limit = 100, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("amgArtistId", amgArtistId.ToString());
			parsedString.Add("entity", "album");
			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_lookupUrl, parsedString.ToString());
			return await this.CreateConnection<AlbumResponse>(url);
		}

		/// <summary>
		/// 検索対象のアーティスト一覧を取得します。
		/// </summary>
		/// <param name="artist">アーティスト名</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<SongArtistResponse> GetSongArtistsAsync(string artist, int limit = 100, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("term", artist);
			parsedString.Add("media", "music");
			parsedString.Add("entity", "musicArtist");
			parsedString.Add("attribute", "artistTerm");
			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_searchUrl, parsedString.ToString());
			return await this.CreateConnection<SongArtistResponse>(url);
		}

		/// <summary>
		/// 検索対象の楽曲リストを取得します。
		/// </summary>
		/// <param name="song">曲名</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<SongResponse> GetSongsAsync(string song, int limit = 100, string attribute = null, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("term", song);
			parsedString.Add("media", "music");
			parsedString.Add("entity", "musicTrack");

			if (attribute != null)
			{
				parsedString.Add("attribute", attribute);
			}

			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_searchUrl, parsedString.ToString());
			return await this.CreateConnection<SongResponse>(url);
		}

		/// <summary>
		/// 検索対象のアルバム一覧を取得します。
		/// </summary>
		/// <param name="album">アルバム名</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<AlbumResponse> GetAlbumsAsync(string album, int limit = 100, string attribute = null, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("term", album);
			parsedString.Add("media", "music");
			parsedString.Add("entity", "album");

			if (attribute != null)
			{
				parsedString.Add("attribute", attribute);
			}

			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_searchUrl, parsedString.ToString());
			return await this.CreateConnection<AlbumResponse>(url);
		}

		/// <summary>
		/// 検索対象の曲に紐付くアルバム一覧を取得します。
		/// </summary>
		/// <param name="song">曲名</param>
		/// <param name="limit">取得上限値</param>
		/// <param name="countryCode">国別コード(2文字)
		/// <returns></returns>
		public async Task<AlbumResponse> GetAlbumsFromSongAsync(string song, int limit = 100, string attribute = null, string countryCode = "jp")
		{
			var parsedString = HttpHelper.ParseQuery(string.Empty);

			parsedString.Add("term", song);
			parsedString.Add("media", "music");
			parsedString.Add("entity", "album");

			if (attribute != null)
			{
				parsedString.Add("attribute", attribute);
			}

			parsedString.Add("limit", limit.ToString());
			parsedString.Add("country", countryCode);

			string url = string.Format(_searchUrl, parsedString.ToString());
			return await this.CreateConnection<AlbumResponse>(url);
		}

		/// <summary>
		/// iTunes Saerch API への接続を行い、レスポンス内容のデシリアライズまで実施します。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="api"></param>
		/// <returns></returns>
		private async Task<T> CreateConnection<T>(string api)
		{
			var result = await new HttpClient().GetStringAsync(api).ConfigureAwait(false);

			// 取得アートワークサイズをここで変換している。
			return JsonHelper.DeserializeObject<T>(result.Replace("100x100bb", "512x512bb"));
		}

		#endregion Search Methods
	}
}
