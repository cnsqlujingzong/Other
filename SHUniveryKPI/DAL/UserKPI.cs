using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace SHUniversity.KPI.DAL
{
	/// <summary>
	/// 数据访问类:UserKPI
	/// </summary>
	public partial class UserKPI
	{
		public UserKPI()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "UserKPI"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserKPI");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        public bool Exists(int ID,string wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserKPI");
            strSql.Append(" where ID=@ID and WorkID=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@wid", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = ID;
            parameters[1].Value = wid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string wid,int year)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserKPI");
            strSql.Append(" where WorkID=@ID and KPIYear=@year");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar),
                    new SqlParameter("@year",SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            parameters[1].Value = year;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool isEdit(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserKPI");
            strSql.Append(" where ID=@ID and (Status=0 or Status=3)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)               
			};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SHUniversity.KPI.Model.UserKPI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserKPI(");
            strSql.Append("KPINumber,KPIYear,WorkID,Creator,CreatDate,ScoreYear,Status,sujUser,sujWorkID)");
			strSql.Append(" values (");
            strSql.Append("@KPINumber,@KPIYear,@WorkID,@Creator,@CreatDate,@ScoreYear,@Status,@sujUser,@sujWorkID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@KPINumber", SqlDbType.NVarChar,50),
					new SqlParameter("@KPIYear", SqlDbType.Int,4),
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatDate", SqlDbType.DateTime),
					new SqlParameter("@ScoreYear", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@sujUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@sujWorkID", SqlDbType.NVarChar,50)
                                        };
			parameters[0].Value = model.KPINumber;
			parameters[1].Value = model.KPIYear;
			parameters[2].Value = model.WorkID;
			parameters[3].Value = model.Creator;
			parameters[4].Value = model.CreatDate;
			parameters[5].Value = model.ScoreYear;
			parameters[6].Value = model.Status;
            parameters[7].Value = model.sujUser;
            parameters[8].Value = model.sujWorkID;

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
        /// 改状态
        /// </summary>
        /// <param name="s"></param>
        /// <param name="user"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public bool ChangeStatus(string kid,int s,string user,string wid) 
        {
            string strSql = "update UserKPI set Status={0},sujUser='{1}',sujWorkID='{2}'  where id="+kid;
            int rows = DbHelperSQL.ExecuteSql(string.Format(strSql,s,user,wid));
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
		/// 更新一条数据
		/// </summary>
		public bool Update(SHUniversity.KPI.Model.UserKPI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserKPI set ");
			strSql.Append("KPINumber=@KPINumber,");
			strSql.Append("KPIYear=@KPIYear,");
			strSql.Append("WorkID=@WorkID,");
			strSql.Append("Creator=@Creator,");
			strSql.Append("CreatDate=@CreatDate,");
			strSql.Append("ScoreYear=@ScoreYear,");
			strSql.Append("Status=@Status");
            strSql.Append("sujUser=@sujUser");
            strSql.Append("sujWorkID=@sujWorkID");

			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@KPINumber", SqlDbType.NVarChar,50),
					new SqlParameter("@KPIYear", SqlDbType.Int,4),
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatDate", SqlDbType.DateTime),
					new SqlParameter("@ScoreYear", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
                                        	new SqlParameter("@sujUser", SqlDbType.NVarChar,50),
                                            	new SqlParameter("@sujWorkID", SqlDbType.NVarChar,50),
                                        };
			parameters[0].Value = model.KPINumber;
			parameters[1].Value = model.KPIYear;
			parameters[2].Value = model.WorkID;
			parameters[3].Value = model.Creator;
			parameters[4].Value = model.CreatDate;
			parameters[5].Value = model.ScoreYear;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.ID;
            parameters[8].Value = model.sujUser;
            parameters[9].Value = model.sujWorkID;

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
			strSql.Append("delete from UserKPI ");
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
			strSql.Append("delete from UserKPI ");
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
		public SHUniversity.KPI.Model.UserKPI GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from UserKPI ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SHUniversity.KPI.Model.UserKPI model=new SHUniversity.KPI.Model.UserKPI();
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
		/// 得到一个对象实体
		/// </summary>
		public SHUniversity.KPI.Model.UserKPI DataRowToModel(DataRow row)
		{
			SHUniversity.KPI.Model.UserKPI model=new SHUniversity.KPI.Model.UserKPI();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["KPINumber"]!=null)
				{
					model.KPINumber=row["KPINumber"].ToString();
				}
				if(row["KPIYear"]!=null && row["KPIYear"].ToString()!="")
				{
					model.KPIYear=int.Parse(row["KPIYear"].ToString());
				}
				if(row["WorkID"]!=null)
				{
					model.WorkID=row["WorkID"].ToString();
				}
				if(row["Creator"]!=null)
				{
					model.Creator=row["Creator"].ToString();
				}
				if(row["CreatDate"]!=null && row["CreatDate"].ToString()!="")
				{
					model.CreatDate=DateTime.Parse(row["CreatDate"].ToString());
				}
				if(row["ScoreYear"]!=null && row["ScoreYear"].ToString()!="")
				{
					model.ScoreYear=int.Parse(row["ScoreYear"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
		 
                if (row["sujUser"] != null)
                {
                    model.sujUser = row["sujUser"].ToString();
                }
                if (row["sujWorkID"] != null)
                {
                    model.sujWorkID = row["sujWorkID"].ToString();
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
			strSql.Append("select * ");
			strSql.Append(" FROM UserKPI ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM UserKPI ");
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
			strSql.Append("select count(1) FROM UserKPI ");
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
			strSql.Append(")AS Row, T.*  from UserKPI T ");
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
			parameters[0].Value = "UserKPI";
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

