using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using Yuna.Exceptions;

namespace Yuna.Interop.Utility
{
	/// <summary>
	/// API 接続に必要なクエリを構築するクラス
	/// </summary>
	public class HttpValueDictionary : Collection<HttpKeyValuePair>
	{
		#region Constructors

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HttpValueDictionary() { }

		/// <summary>
		/// コンストラクタ(クエリ、URLEncode 要否フラグ)
		/// </summary>
		/// <param name="query"></param>
		/// <param name="urlEncode"></param>
		public HttpValueDictionary(string query, bool urlEncode)
		{
			try
			{
				if (!string.IsNullOrEmpty(query))
				{
					this._FillString(query, urlEncode);
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		#endregion Constructors

		#region Parameters

		/// <summary>
		/// Key 設定
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string this[string key]
		{
			get { return this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value; }
			set { this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value = value; }
		}

		#endregion Parameters

		#region Public Methods

		/// <summary>
		/// Key - Value のペア構築を行います。
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Add(string key, string value)
		{
			try
			{
				this.Add(new HttpKeyValuePair(key, value));
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// 対象キーの検索を行います。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(string key)
		{
			try
			{
				return this.Any(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// キーに紐付くデータを取得します。
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string[] GetValues(string key)
		{
			try
			{
				return this.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToArray();
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// キーに紐付くデータを除去します。
		/// </summary>
		/// <param name="key"></param>
		public void Remove(string key)
		{
			try
			{
				var items = this.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).ToList();
				foreach (var item in items)
				{
					this.Remove(item);
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// ToString To Base Extends ver.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			try
			{
				return this.ToString(true);
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// ToString To Base Extends ver.
		/// </summary>
		/// <param name="urlEncoded"></param>
		/// <returns></returns>
		public virtual string ToString(bool urlEncoded)
		{
			try
			{
				return this.ToString(urlEncoded, null);
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		/// <summary>
		/// ToString To Base Extends ver.
		/// </summary>
		/// <param name="urlEncoded"></param>
		/// <param name="excludeKeys"></param>
		/// <returns></returns>
		public virtual string ToString(bool urlEncoded, IDictionary removeKeys)
		{
			try
			{
				var query = new StringBuilder();

				if (this.Count == 0)
				{
					return string.Empty;
				}

				foreach (var item in this)
				{
					string key = item.Key;

					if ((removeKeys == null) || !removeKeys.Contains(key))
					{
						if (urlEncoded)
						{
							key = WebUtility.UrlDecode(key);
						}

						if (query.Length > 0)
						{
							query.Append('&');
						}

						query.Append((key != null) ? (key + "=") : string.Empty);

						string value = item.Value;
						if ((value != null) && (value.Length > 0))
						{
							if (urlEncoded)
							{
								value = Uri.EscapeDataString(value);
							}
							query.Append(value);
						}
					}
				}

				return query.ToString();
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// クエリ構築時に必要に応じてパラメータ文字列を設定します。
		/// </summary>
		/// <param name="query"></param>
		/// <param name="urlEncoded"></param>
		private void _FillString(string query, bool urlEncoded)
		{
			try
			{
				int num = (query != null) ? query.Length : 0;
				for (int i = 0; i < num; i++)
				{
					int index = i;
					int work = -1;
					while (i < work)
					{
						char ch = query[i];
						if (ch == '=')
						{
							if (work < 0)
							{
								work = i;
							}
						}
						else if (ch == '&')
						{
							break;
						}
						i++;
					}

					string str = string.Empty;
					string str2 = string.Empty;
					if (work >= 0)
					{
						str = query.Substring(index, work - index);
						str2 = query.Substring(work + 1, (i - work) - 1);
					}
					else
					{
						str2 = query.Substring(index, i - index);
					}

					if (urlEncoded)
					{
						this.Add(Uri.UnescapeDataString(str), Uri.UnescapeDataString(str2));
					}
					else
					{
						this.Add(str, str2);
					}

					if ((i == (num - 1)) && (query[i] == '&'))
					{
						this.Add(null, string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		#endregion Private Methods
	}
}
