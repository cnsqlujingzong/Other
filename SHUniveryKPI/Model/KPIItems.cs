using System;
namespace SHUniversity.KPI.Model
{
	/// <summary>
	/// KPIItems:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KPIItems
	{
		public KPIItems()
		{}
		#region Model
		private int _id;
		private int _kpino;
		private string _itemtype;
		private DateTime? _itemdate;
		private string _itemcreator;
		private DateTime? _itemlastupdatedate;
		private string _itemupdateuser;
		private string _itemno;
		private string _projecttype;
		private string _projectno;
		private string _projectname;
		private string _str1;
		private string _str2;
		private string _str3;
		private string _str4;
		private string _str5;
		private string _str6;
		private string _str7;
		private string _str8;
		private string _str9;
		private string _str10;
		private string _str11;
		private string _str12;
		private decimal? _float1;
		private decimal? _float2;
		private decimal? _float3;
		private decimal? _float4;
		private decimal? _float5;
        private decimal? _float6;
        private decimal? _float7;
        private decimal? _float8;
        private decimal? _float9;
        private decimal? _float10;
    	private int? _int1;
		private int? _int2;
		private int? _int3;
		private int? _int4;
		private int? _int5;
        private int? _int6;
        private int? _int7;
        private int? _int8;
        private int? _int9;
        private int? _int10;
        private DateTime? _datetime1;
		private DateTime? _datetime2;
		private DateTime? _datetime3;
		private DateTime? _datetime4;
		private DateTime? _datetime5;
		private string _text1;
		private string _text2;
		private string _text3;
		private string _text4;
		private string _text5;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 所属考核表
		/// </summary>
		public int KPINO
		{
			set{ _kpino=value;}
			get{return _kpino;}
		}
		/// <summary>
		/// 考核表类型
		/// </summary>
		public string ItemType
		{
			set{ _itemtype=value;}
			get{return _itemtype;}
		}
		/// <summary>
		/// 建立日期
		/// </summary>
		public DateTime? ItemDate
		{
			set{ _itemdate=value;}
			get{return _itemdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemCreator
		{
			set{ _itemcreator=value;}
			get{return _itemcreator;}
		}
		/// <summary>
		/// 最后更新日期
		/// </summary>
		public DateTime? ItemLastUpdateDate
		{
			set{ _itemlastupdatedate=value;}
			get{return _itemlastupdatedate;}
		}
		/// <summary>
		/// 最后更新人
		/// </summary>
		public string ItemUpdateUser
		{
			set{ _itemupdateuser=value;}
			get{return _itemupdateuser;}
		}
		/// <summary>
		/// 项目编号
		/// </summary>
		public string ItemNO
		{
			set{ _itemno=value;}
			get{return _itemno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectType
		{
			set{ _projecttype=value;}
			get{return _projecttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectNO
		{
			set{ _projectno=value;}
			get{return _projectno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str1
		{
			set{ _str1=value;}
			get{return _str1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str2
		{
			set{ _str2=value;}
			get{return _str2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str3
		{
			set{ _str3=value;}
			get{return _str3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str4
		{
			set{ _str4=value;}
			get{return _str4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str5
		{
			set{ _str5=value;}
			get{return _str5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str6
		{
			set{ _str6=value;}
			get{return _str6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str7
		{
			set{ _str7=value;}
			get{return _str7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str8
		{
			set{ _str8=value;}
			get{return _str8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str9
		{
			set{ _str9=value;}
			get{return _str9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str10
		{
			set{ _str10=value;}
			get{return _str10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str11
		{
			set{ _str11=value;}
			get{return _str11;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str12
		{
			set{ _str12=value;}
			get{return _str12;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? float1
		{
			set{ _float1=value;}
			get{return _float1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? float2
		{
			set{ _float2=value;}
			get{return _float2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? float3
		{
			set{ _float3=value;}
			get{return _float3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? float4
		{
			set{ _float4=value;}
			get{return _float4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? float5
		{
			set{ _float5=value;}
			get{return _float5;}
		}
        public decimal? float6
        {
            set { _float6 = value; }
            get { return _float6; }
        }
        public decimal? float7
        {
            set { _float7 = value; }
            get { return _float7; }
        }
        public decimal? float8
        {
            set { _float8 = value; }
            get { return _float8; }
        }
        public decimal? float9
        {
            set { _float9 = value; }
            get { return _float9; }
        }
        public decimal? float10
        {
            set { _float10 = value; }
            get { return _float10; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? Int1
		{
			set{ _int1=value;}
			get{return _int1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Int2
		{
			set{ _int2=value;}
			get{return _int2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Int3
		{
			set{ _int3=value;}
			get{return _int3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Int4
		{
			set{ _int4=value;}
			get{return _int4;}
		}
        public int? Int5
        {
            set { _int5 = value; }
            get { return _int5; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? Int6
		{
			set{ _int6=value;}
			get{return _int6;}
		}
        public int? Int7
        {
            set { _int7 = value; }
            get { return _int7; }
        }
        public int? Int8
        {
            set { _int8 = value; }
            get { return _int8; }
        }
        
        public int? Int9
        {
            set { _int9 = value; }
            get { return _int9; }
        }
        public int? Int10
        {
            set { _int10 = value; }
            get { return _int10; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? datetime1
		{
			set{ _datetime1=value;}
			get{return _datetime1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? datetime2
		{
			set{ _datetime2=value;}
			get{return _datetime2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? datetime3
		{
			set{ _datetime3=value;}
			get{return _datetime3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? datetime4
		{
			set{ _datetime4=value;}
			get{return _datetime4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? datetime5
		{
			set{ _datetime5=value;}
			get{return _datetime5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text1
		{
			set{ _text1=value;}
			get{return _text1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text2
		{
			set{ _text2=value;}
			get{return _text2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text3
		{
			set{ _text3=value;}
			get{return _text3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text4
		{
			set{ _text4=value;}
			get{return _text4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text5
		{
			set{ _text5=value;}
			get{return _text5;}
		}
		#endregion Model

	}
}

