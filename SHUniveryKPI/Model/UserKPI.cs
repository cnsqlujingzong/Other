using System;
namespace SHUniversity.KPI.Model
{
	/// <summary>
	/// UserKPI:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserKPI
	{
		public UserKPI()
		{}
		#region Model
		private int _id;
		private string _kpinumber;
		private int? _kpiyear;
		private string _workid;
		private string _creator;
		private DateTime? _creatdate;
		private int? _scoreyear;
		private int? _status=0;
        public string sujUser { get; set; }
        public string sujWorkID { get; set; }
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
		public string KPINumber
		{
			set{ _kpinumber=value;}
			get{return _kpinumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? KPIYear
		{
			set{ _kpiyear=value;}
			get{return _kpiyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkID
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatDate
		{
			set{ _creatdate=value;}
			get{return _creatdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ScoreYear
		{
			set{ _scoreyear=value;}
			get{return _scoreyear;}
		}
		/// <summary>
		/// 0未审核1正在审核2审核通过3退回
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

