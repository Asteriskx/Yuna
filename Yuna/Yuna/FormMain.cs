using Legato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yuna.Exceptions;
using Yuna.Models;

namespace Yuna
{
	/// <summary>
	/// メインフォーム
	/// </summary>
	public partial class FormMain : Form
	{
		#region Property

		/// <summary>
		/// 
		/// </summary>
		private AimpProperties _AimpProperties { get; set; } = new AimpProperties();

		/// <summary>
		/// 
		/// </summary>
		private AimpObserver _AimpObserver { get; set; } = new AimpObserver();

		/// <summary>
		/// 
		/// </summary>
		private SearchManager _Yuna { get; set; } = new SearchManager();

		/// <summary>
		/// 
		/// </summary>
		private List<Song> _ItemList { get; set; } = new List<Song>();

		#endregion Property

		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FormMain() => InitializeComponent();

		#endregion Constructor

		#region Event Method

		/// <summary>
		/// フォームロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void FormMain_Load(object sender, EventArgs e)
		{
			try
			{
				this._InitializeResultView();

				this._AimpObserver.CurrentTrackChanged += async (track) =>
				{
					this.SearchBox.Text = track.Title;
					this.ResultView.Items?.Clear();
					this._ItemList?.Clear();
					await this._ApiAccessor();
				};

				if (this._AimpProperties.IsRunning)
				{
					this.SearchBox.Text = this._AimpProperties.CurrentTrack.Title;
					this.ResultView.Items?.Clear();
					this._ItemList?.Clear();
					await this._ApiAccessor();
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// 楽曲一覧の選択行が変更された際に発生します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ResultView_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (ResultView.SelectedItems.Count > 0)
				{
					var item = this._ItemList[this.ResultView.SelectedItems[0].Index];
					this.Artwork.ImageLocation = item.ArtworkUrl100;
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// アートワークを外部ビューワにて表示します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Artwork_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.Artwork != null)
				{
					this.Artwork.Image.Save("artwork.png", ImageFormat.Png);
					Process.Start("artwork.png");
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// 楽曲の検索を行います。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void SearchButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.ResultView.Items?.Clear();

				var isException = await this._ApiAccessor();
				if (!isException)
				{
					throw new YunaException();
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// 楽曲の検索を行います。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void SearchBox_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.ResultView.Items?.Clear();

				if (e.KeyCode == Keys.Enter)
				{
					var isException = await this._ApiAccessor();
					if (!isException)
					{
						throw new YunaException();
					}
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// 試聴を実施します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrialButton_Click(object sender, EventArgs e)
		{
			try
			{
				var data = this._ItemList[this.ResultView.SelectedItems[0].Index];
				var url = data.PreviewUrl;
				var saveName = $"{data.TrackName}.m4a";

				using (var client = new WebClient())
				{
					client.DownloadFileAsync(new Uri(url), saveName);
				}
				Process.Start(saveName);
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		#endregion Event Method

		#region Private Method

		/// <summary>
		/// 楽曲一覧リストビューの初期設定を行います。
		/// </summary>
		private void _InitializeResultView()
		{
			try
			{
				this.ResultView.FullRowSelect = true;
				this.ResultView.GridLines = true;
				this.ResultView.Sorting = SortOrder.Ascending;
				this.ResultView.View = View.Details;

				var columnSong = new ColumnHeader();
				var columnArtist = new ColumnHeader();
				var columnAlbum = new ColumnHeader();

				columnSong.Text = "曲名";
				columnArtist.Text = "アーティスト";
				columnAlbum.Text = "アルバム";

				columnSong.Width = 200;
				columnArtist.Width = 200;
				columnAlbum.Width = 220;

				this.ResultView.Columns.AddRange(new[] { columnSong, columnArtist, columnAlbum });
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// iTunes Search API へ接続し、対象楽曲のデータを取得します。
		/// </summary>
		/// <returns></returns>
		private async Task<bool> _ApiAccessor()
		{
			try
			{
				if (this._AimpProperties.IsRunning)
				{
					this.SearchBox.Text = _AimpProperties.CurrentTrack.Title;
				}

				var searchWord = this.SearchBox.Text;
				var hitNum = default(int);

				var data = await Task.Run(async () =>
				{
					return await this._Yuna.GetSongsAsync(searchWord, (int)SearchNum.Value);
				});

				foreach (var song in data.Songs.Select((v, i) => new { v, i }))
				{
					if (this._AimpProperties.IsRunning)
					{
						var isContainTitle = Regex.IsMatch(song.v.TrackName, this._AimpProperties.CurrentTrack.Title, RegexOptions.Singleline);
						var isContainArtist = Regex.IsMatch(song.v.ArtistName, this._AimpProperties.CurrentTrack.Artist, RegexOptions.Singleline);
						if (isContainArtist || isContainTitle)
						{
							this._ItemList.Add(song.v);
							var mainItem = this.ResultView.Items.Add(song.v.TrackName);
							mainItem.SubItems.Add(song.v.ArtistName);
							mainItem.SubItems.Add(song.v.CollectionName);
						}
						hitNum++;
					}
					else
					{
						this._ItemList.Add(song.v);
						var mainItem = this.ResultView.Items.Add(song.v.TrackName);
						mainItem.SubItems.Add(song.v.ArtistName);
						mainItem.SubItems.Add(song.v.CollectionName);
						hitNum++;
					}
				}

				this.SearchResult.Text = $"{hitNum} 件が該当しました。";
				return true;
			}
			catch (Exception ex)
			{
				this.SearchResult.Text = "検索エラーが発生した為、検索できませんでした。";
				throw new YunaException(ex.Message);
			}
			finally
			{
			}
		}

		#endregion Private Method
	}
}
