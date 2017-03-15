using System;
namespace SHUniversity.KPI.Model
{
	/// <summary>
	/// Logs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Logs
	{
		public Logs()
		{}
		#region Model
		private int _id;
		private string _ouser;
		private string _ouserid;
		private string _title;
		private string _common;
		private DateTime? _stardatetime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OUser
		{
			set{ _ouser=value;}
			get{return _ouser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OUserID
		{
			set{ _ouserid=value;}
			get{return _ouserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Common
		{
			set{ _common=value;}
			get{return _common;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StarDatetime
		{
			set{ _stardatetime=value;}
			get{return _stardatetime;}
		}
		#endregion Model

	}
}

