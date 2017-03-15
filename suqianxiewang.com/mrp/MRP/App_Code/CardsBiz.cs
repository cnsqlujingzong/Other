using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CardsBiz 的摘要说明
/// </summary>
public class CardsBiz
{
	public CardsBiz()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}    
		#region Model
		private int _id;
		private string _cardnum;
		private string _cardpwd;
		private int? _usestate=0;
		private int? _cardtype;
		private string _moblie;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 卡号
		/// </summary>
		public string CardNum
		{
			set{ _cardnum=value;}
			get{return _cardnum;}
		}
		/// <summary>
		/// 卡密码
		/// </summary>
		public string CardPwd
		{
			set{ _cardpwd=value;}
			get{return _cardpwd;}
		}
		/// <summary>
		/// 使用状态0未使用1已经使用
		/// </summary>
		public int? UseState
		{
			set{ _usestate=value;}
			get{return _usestate;}
		}
		/// <summary>
		/// 卡类型
		/// </summary>
		public int? CardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Moblie
		{
			set{ _moblie=value;}
			get{return _moblie;}
		}
		#endregion Model


		#region  Method
    		
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public void GetModel(string cardnum,string cardpwd)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from [Cards]");
            strSql.Append(" where CardNum=@CardNum and CardPwd=@CardPwd ");

			SqlParameter[] parameters = {
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
                    	new SqlParameter("@CardPwd", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = cardnum;
            parameters[1].Value = cardpwd;
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardNum"] != null)
                {
                    this.CardNum = ds.Tables[0].Rows[0]["CardNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardPwd"] != null)
                {
                    this.CardPwd = ds.Tables[0].Rows[0]["CardPwd"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UseState"] != null && ds.Tables[0].Rows[0]["UseState"].ToString() != "")
                {
                    this.UseState = int.Parse(ds.Tables[0].Rows[0]["UseState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardType"] != null && ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    this.CardType = int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Moblie"] != null)
                {
                    this.Moblie = ds.Tables[0].Rows[0]["Moblie"].ToString();
                }
            }
    }
    
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Cards] set ");
			strSql.Append("CardNum=@CardNum,");
			strSql.Append("CardPwd=@CardPwd,");
			strSql.Append("UseState=@UseState,");
			strSql.Append("CardType=@CardType,");
			strSql.Append("Moblie=@Moblie");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardNum", SqlDbType.NVarChar,50),
					new SqlParameter("@CardPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@UseState", SqlDbType.Int,4),
					new SqlParameter("@CardType", SqlDbType.Int,4),
					new SqlParameter("@Moblie", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = CardNum;
			parameters[1].Value = CardPwd;
			parameters[2].Value = UseState;
			parameters[3].Value = CardType;
			parameters[4].Value = Moblie;
			parameters[5].Value = ID;

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
			strSql.Append("select ID,CardNum,CardPwd,UseState,CardType,Moblie ");
			strSql.Append(" FROM [Cards] ");
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
				if(ds.Tables[0].Rows[0]["CardNum"]!=null )
				{
					this.CardNum=ds.Tables[0].Rows[0]["CardNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardPwd"]!=null )
				{
					this.CardPwd=ds.Tables[0].Rows[0]["CardPwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UseState"]!=null && ds.Tables[0].Rows[0]["UseState"].ToString()!="")
				{
					this.UseState=int.Parse(ds.Tables[0].Rows[0]["UseState"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardType"]!=null && ds.Tables[0].Rows[0]["CardType"].ToString()!="")
				{
					this.CardType=int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Moblie"]!=null )
				{
					this.Moblie=ds.Tables[0].Rows[0]["Moblie"].ToString();
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
			strSql.Append(" FROM [Cards] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
}