using System;
using Yuna.Exceptions;

namespace Yuna.Interop.Utility
{
	/// <summary>
	/// API接続を行うに際して、接続パラメータ構築などを補助するクラス
	/// </summary>
	public class HttpHelper : HttpValueDictionary
	{
		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HttpHelper() { }

		#endregion Constructor

		#region Public static Method

		/// <summary>
		/// クエリ文字列をパースします。
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static HttpValueDictionary ParseQuery(string query)
		{
			try
			{
				if (query == null)
				{
					throw new YunaException("パース失敗：Yuna.Interop.Utility.HttpHelper -> PerseQuery(string query)");
				}

				if ((query.Length > 0) && (query[0] == '?'))
				{
					query = query.Substring(1);
				}

				return new HttpValueDictionary(query, true);
			}
			catch (Exception ex)
			{
				throw new YunaException(ex.Message);
			}
		}

		#endregion Public static Method
	}
}
