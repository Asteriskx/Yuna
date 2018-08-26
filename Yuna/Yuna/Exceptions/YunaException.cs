using System;
using System.Runtime.Serialization;

namespace Yuna.Exceptions
{
	/// <summary>
	/// Yuna で起きた例外を管理します。
	/// </summary>
	[Serializable()]
	public class YunaException : Exception
	{
		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		public YunaException() : base("") { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		public YunaException(string msg) : base(msg) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="inner"></param>
		public YunaException(string msg, Exception inner) : base(msg, inner) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected YunaException(SerializationInfo info, StreamingContext context) { }

		#endregion Constructors
	}
}
