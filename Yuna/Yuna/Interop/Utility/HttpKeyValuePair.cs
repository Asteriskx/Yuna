namespace Yuna.Interop.Utility
{
	/// <summary>
	/// クエリ構築時に必要なパラメータの管理クラス
	/// </summary>
	public class HttpKeyValuePair
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Value { get; set; }

		#endregion Properties

		#region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HttpKeyValuePair(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		#endregion Constructor
	}
}
