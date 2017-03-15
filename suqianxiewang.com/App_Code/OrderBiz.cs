using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Order 的摘要说明
/// </summary>
public class OrderBiz
{
    public OrderBiz()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region Model
		private int _id;
		private string _orderid;
		private string _cardnum;
		private int? _ordersate;
		private string _mobile;
		private string _dname;
		private string _sheng;
		private string _shi;
		private string _address;
		private string _sendcory;
		private string _sendnum;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
        /// 兑换券卡号
		/// </summary>
		public string CardNum
		{
			set{ _cardnum=value;}
			get{return _cardnum;}
		}
		/// <summary>
		/// 0未处理1已发货
		/// </summary>
		public int? OrderSate
		{
			set{ _ordersate=value;}
			get{return _ordersate;}
		}
		/// <summary>
        /// 手机号
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
        /// 收货人姓名
		/// </summary>
		public string DName
		{
			set{ _dname=value;}
			get{return _dname;}
		}
		/// <summary>
        /// 省份
		/// </summary>
		public string Sheng
		{
			set{ _sheng=value;}
			get{return _sheng;}
		}
		/// <summary>
        /// 城市
		/// </summary>
		public string Shi
		{
			set{ _shi=value;}
			get{return _shi;}
		}
		/// <summary>
        /// 地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
        /// 物流
		/// </summary>
		public string SendCory
		{
			set{ _sendcory=value;}
			get{return _sendcory;}
		}
		/// <summary>
        /// 物流单
		/// </summary>
		public string SendNum
		{
			set{ _sendnum=value;}
			get{return _sendnum;}
		}
        public DateTime CreatTime { get; set; }
		#endregion Model


		#region  Method
    	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Order]");
			strSql.Append(" where ID=@ID ");

			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Order] (");
            strSql.Append("OrderID,CardNum,OrderSate,Mobile,DName,Sheng,Shi,Address,SendCory,SendNum,CreatTime)");
			strSql.Append(" values (");
            strSql.Append("@OrderID,@CardNum,@OrderSate,@Mobile,@DName,@Sheng,@Shi,@Address,@SendCory,@SendNum,@CreatTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@OrderSate", SqlDbType.Int,4),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@DName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sheng", SqlDbType.NVarChar,20),
					new SqlParameter("@Shi", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@SendCory", SqlDbType.NVarChar,50),
					new SqlParameter("@SendNum", SqlDbType.NVarChar,50),
                   new SqlParameter("@CreatTime", SqlDbType.NVarChar,50)
                                        };
			parameters[0].Value = OrderID;
			parameters[1].Value = CardNum;
			parameters[2].Value = OrderSate;
			parameters[3].Value = Mobile;
			parameters[4].Value = DName;
			parameters[5].Value = Sheng;
			parameters[6].Value = Shi;
			parameters[7].Value = Address;
			parameters[8].Value = SendCory;
			parameters[9].Value = SendNum;
            parameters[10].Value = CreatTime;
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Order] set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("CardNum=@CardNum,");
			strSql.Append("OrderSate=@OrderSate,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("DName=@DName,");
			strSql.Append("Sheng=@Sheng,");
			strSql.Append("Shi=@Shi,");
			strSql.Append("Address=@Address,");
			strSql.Append("SendCory=@SendCory,");
			strSql.Append("SendNum=@SendNum");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@OrderSate", SqlDbType.Int,4),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@DName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sheng", SqlDbType.NVarChar,20),
					new SqlParameter("@Shi", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@SendCory", SqlDbType.NVarChar,50),
					new SqlParameter("@SendNum", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = OrderID;
			parameters[1].Value = CardNum;
			parameters[2].Value = OrderSate;
			parameters[3].Value = Mobile;
			parameters[4].Value = DName;
			parameters[5].Value = Sheng;
			parameters[6].Value = Shi;
			parameters[7].Value = Address;
			parameters[8].Value = SendCory;
			parameters[9].Value = SendNum;
			parameters[10].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Order] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,OrderID,CardNum,OrderSate,Mobile,DName,Sheng,Shi,Address,SendCory,SendNum,CreatTime ");
			strSql.Append(" FROM [Order] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					this.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderID"]!=null )
				{
					this.OrderID=ds.Tables[0].Rows[0]["OrderID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardNum"]!=null )
				{
					this.CardNum=ds.Tables[0].Rows[0]["CardNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrderSate"]!=null && ds.Tables[0].Rows[0]["OrderSate"].ToString()!="")
				{
					this.OrderSate=int.Parse(ds.Tables[0].Rows[0]["OrderSate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mobile"]!=null )
				{
					this.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DName"]!=null )
				{
					this.DName=ds.Tables[0].Rows[0]["DName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Sheng"]!=null )
				{
					this.Sheng=ds.Tables[0].Rows[0]["Sheng"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Shi"]!=null )
				{
					this.Shi=ds.Tables[0].Rows[0]["Shi"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null )
				{
					this.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SendCory"]!=null )
				{
					this.SendCory=ds.Tables[0].Rows[0]["SendCory"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SendNum"]!=null )
				{
					this.SendNum=ds.Tables[0].Rows[0]["SendNum"].ToString();
                } if (ds.Tables[0].Rows[0]["CreatTime"] != null)
				{
                    this.CreatTime =Convert.ToDateTime( ds.Tables[0].Rows[0]["CreatTime"]);
				}
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Order] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
}