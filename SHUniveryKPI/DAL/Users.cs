using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace SHUniversity.KPI.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class Users
	{
		public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string wID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
            strSql.Append(" where WorkID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar)
			};
            parameters[0].Value = wID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SHUniversity.KPI.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("WorkID,Password,Name,Sex,BrithDay,Xueli,Xuexiao,Zhiwu,Email,Moblie,Tel,InDate,Ramerk,UserType,CreatDate,Satat)");
			strSql.Append(" values (");
			strSql.Append("@WorkID,@Password,@Name,@Sex,@BrithDay,@Xueli,@Xuexiao,@Zhiwu,@Email,@Moblie,@Tel,@InDate,@Ramerk,@UserType,@CreatDate,@Satat)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@BrithDay", SqlDbType.DateTime),
					new SqlParameter("@Xueli", SqlDbType.NVarChar,50),
					new SqlParameter("@Xuexiao", SqlDbType.NVarChar,50),
					new SqlParameter("@Zhiwu", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Moblie", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Ramerk", SqlDbType.NVarChar,500),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@CreatDate", SqlDbType.DateTime),
					new SqlParameter("@Satat", SqlDbType.Int,4)};
			parameters[0].Value = model.WorkID;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.BrithDay;
			parameters[5].Value = model.Xueli;
			parameters[6].Value = model.Xuexiao;
			parameters[7].Value = model.Zhiwu;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Moblie;
			parameters[10].Value = model.Tel;
			parameters[11].Value = model.InDate;
			parameters[12].Value = model.Ramerk;
			parameters[13].Value = model.UserType;
			parameters[14].Value = model.CreatDate;
			parameters[15].Value = model.Satat;

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
		public bool Update(SHUniversity.KPI.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("WorkID=@WorkID,");
			strSql.Append("Password=@Password,");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("BrithDay=@BrithDay,");
			strSql.Append("Xueli=@Xueli,");
			strSql.Append("Xuexiao=@Xuexiao,");
			strSql.Append("Zhiwu=@Zhiwu,");
			strSql.Append("Email=@Email,");
			strSql.Append("Moblie=@Moblie,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("InDate=@InDate,");
			strSql.Append("Ramerk=@Ramerk,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("CreatDate=@CreatDate,");
			strSql.Append("Satat=@Satat");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@BrithDay", SqlDbType.DateTime),
					new SqlParameter("@Xueli", SqlDbType.NVarChar,50),
					new SqlParameter("@Xuexiao", SqlDbType.NVarChar,50),
					new SqlParameter("@Zhiwu", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Moblie", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Ramerk", SqlDbType.NVarChar,500),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@CreatDate", SqlDbType.DateTime),
					new SqlParameter("@Satat", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.WorkID;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.BrithDay;
			parameters[5].Value = model.Xueli;
			parameters[6].Value = model.Xuexiao;
			parameters[7].Value = model.Zhiwu;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Moblie;
			parameters[10].Value = model.Tel;
			parameters[11].Value = model.InDate;
			parameters[12].Value = model.Ramerk;
			parameters[13].Value = model.UserType;
			parameters[14].Value = model.CreatDate;
			parameters[15].Value = model.Satat;
			parameters[16].Value = model.ID;

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
			strSql.Append("delete from Users ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public SHUniversity.KPI.Model.Users GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,WorkID,Password,Name,Sex,BrithDay,Xueli,Xuexiao,Zhiwu,Email,Moblie,Tel,InDate,Ramerk,UserType,CreatDate,Satat from Users ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SHUniversity.KPI.Model.Users model=new SHUniversity.KPI.Model.Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 登录
        /// </summary>
        public SHUniversity.KPI.Model.Users Login(string loginName ,string pwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,WorkID,Password,Name,Sex,BrithDay,Xueli,Xuexiao,Zhiwu,Email,Moblie,Tel,InDate,Ramerk,UserType,CreatDate,Satat from Users ");
            strSql.Append(" where WorkID=@WorkID and Password=@Password and Satat=1");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkID", SqlDbType.VarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar)
			};
            parameters[0].Value = loginName;
            parameters[1].Value = pwd;
            SHUniversity.KPI.Model.Users model = new SHUniversity.KPI.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SHUniversity.KPI.Model.Users DataRowToModel(DataRow row)
		{
			SHUniversity.KPI.Model.Users model=new SHUniversity.KPI.Model.Users();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["WorkID"]!=null)
				{
					model.WorkID=row["WorkID"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["BrithDay"]!=null && row["BrithDay"].ToString()!="")
				{
					model.BrithDay=DateTime.Parse(row["BrithDay"].ToString());
				}
				if(row["Xueli"]!=null)
				{
					model.Xueli=row["Xueli"].ToString();
				}
				if(row["Xuexiao"]!=null)
				{
					model.Xuexiao=row["Xuexiao"].ToString();
				}
				if(row["Zhiwu"]!=null)
				{
					model.Zhiwu=row["Zhiwu"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Moblie"]!=null)
				{
					model.Moblie=row["Moblie"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["InDate"]!=null && row["InDate"].ToString()!="")
				{
					model.InDate=DateTime.Parse(row["InDate"].ToString());
				}
				if(row["Ramerk"]!=null)
				{
					model.Ramerk=row["Ramerk"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["CreatDate"]!=null && row["CreatDate"].ToString()!="")
				{
					model.CreatDate=DateTime.Parse(row["CreatDate"].ToString());
				}
				if(row["Satat"]!=null && row["Satat"].ToString()!="")
				{
					model.Satat=int.Parse(row["Satat"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,WorkID,Password,Name,Sex,BrithDay,Xueli,Xuexiao,Zhiwu,Email,Moblie,Tel,InDate,Ramerk,UserType,CreatDate,Satat ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,WorkID,Password,Name,Sex,BrithDay,Xueli,Xuexiao,Zhiwu,Email,Moblie,Tel,InDate,Ramerk,UserType,CreatDate,Satat ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Users";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

