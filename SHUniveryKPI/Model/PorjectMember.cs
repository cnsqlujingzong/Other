using System;
namespace SHUniversity.KPI.Model
{
	/// <summary>
	/// PorjectMember:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PorjectMember
	{
        public PorjectMember()
        { }
        #region Model
        private int _id;
        private string _pitemid;
        private string _pid;
        private string _pname;
        private string _ptype;
        private string _ptype2;
        private decimal? _pscore;
        private string _att1;
        private string _att2;
        private string _att3;
        private string _att4;
        private decimal? _float1;
        private decimal? _float2;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PItemID
        {
            set { _pitemid = value; }
            get { return _pitemid; }
        }
        /// <summary>
        /// 学生学号 或者老师工号
        /// </summary>
        public string PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 0学生1老师
        /// </summary>
        public string PType
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PType2
        {
            set { _ptype2 = value; }
            get { return _ptype2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PScore
        {
            set { _pscore = value; }
            get { return _pscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att1
        {
            set { _att1 = value; }
            get { return _att1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att2
        {
            set { _att2 = value; }
            get { return _att2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att3
        {
            set { _att3 = value; }
            get { return _att3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Att4
        {
            set { _att4 = value; }
            get { return _att4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? float1
        {
            set { _float1 = value; }
            get { return _float1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? float2
        {
            set { _float2 = value; }
            get { return _float2; }
        }
        #endregion Model

	}
}

