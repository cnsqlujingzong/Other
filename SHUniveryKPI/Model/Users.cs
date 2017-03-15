using System;
namespace SHUniversity.KPI.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _id;
		private string _workid;
		private string _password;
		private string _name;
		private int? _sex;
		private DateTime? _brithday;
		private string _xueli;
		private string _xuexiao;
		private string _zhiwu;
		private string _email;
		private string _moblie;
		private string _tel;
		private DateTime? _indate;
		private string _ramerk;
		private int? _usertype=0;
		private DateTime? _creatdate;
		private int? _satat=1;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 工号
		/// </summary>
		public string WorkID
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime? BrithDay
		{
			set{ _brithday=value;}
			get{return _brithday;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string Xueli
		{
			set{ _xueli=value;}
			get{return _xueli;}
		}
		/// <summary>
		/// 学校
		/// </summary>
		public string Xuexiao
		{
			set{ _xuexiao=value;}
			get{return _xuexiao;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string Zhiwu
		{
			set{ _zhiwu=value;}
			get{return _zhiwu;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string Moblie
		{
			set{ _moblie=value;}
			get{return _moblie;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 进校日期
		/// </summary>
		public DateTime? InDate
		{
			set{ _indate=value;}
			get{return _indate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Ramerk
		{
			set{ _ramerk=value;}
			get{return _ramerk;}
		}
		/// <summary>
		/// 用户类型 99：管理员 0员工1管理 
		/// </summary>
		public int? UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
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
		/// 1正常0禁用
		/// </summary>
		public int? Satat
		{
			set{ _satat=value;}
			get{return _satat;}
		}
		#endregion Model

	}
}

