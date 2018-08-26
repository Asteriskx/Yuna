using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Yuna.Interop.Utility
{
	/// <summary>
	/// Json.NET 汎用的メソッド 定義クラス
	/// </summary>
	public static class JsonHelper
	{
		#region Public static Method

		/// <summary>
		/// JSON 文字列を指定された型へデシリアライズします。
		/// </summary>
		/// <typeparam name="T">汎用型</typeparam>
		/// <param name="obj">デシリアライズ対象文字列</param>
		/// <returns></returns>
		public static T DeserializeObject<T>(string obj)
		{
			using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(obj)))
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				return (T)serializer.ReadObject(stream);
			}
		}

		#endregion Public static Method
	}
}
