using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace SHUniversity.KPI.DAL
{
	/// <summary>
	/// 数据访问类:PorjectMember
	/// </summary>
	public partial class PorjectMember
	{
        public PorjectMember()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "PorjectMember");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PorjectMember");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.PorjectMember model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PorjectMember(");
            strSql.Append("PItemID,PID,PName,PType,PType2,PScore,Att1,Att2,Att3,Att4,float1,float2)");
            strSql.Append(" values (");
            strSql.Append("@PItemID,@PID,@PName,@PType,@PType2,@PScore,@Att1,@Att2,@Att3,@Att4,@float1,@float2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PItemID", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.NVarChar,50),
					new SqlParameter("@PName", SqlDbType.NVarChar,50),
					new SqlParameter("@PType", SqlDbType.NVarChar,50),
					new SqlParameter("@PType2", SqlDbType.NVarChar,50),
					new SqlParameter("@PScore", SqlDbType.Decimal,5),
					new SqlParameter("@Att1", SqlDbType.NVarChar,50),
					new SqlParameter("@Att2", SqlDbType.NVarChar,50),
					new SqlParameter("@Att3", SqlDbType.NVarChar,50),
					new SqlParameter("@Att4", SqlDbType.NVarChar,50),
					new SqlParameter("@float1", SqlDbType.Decimal,9),
					new SqlParameter("@float2", SqlDbType.Decimal,9)};
            parameters[0].Value = model.PItemID;
            parameters[1].Value = model.PID;
            parameters[2].Value = model.PName;
            parameters[3].Value = model.PType;
            parameters[4].Value = model.PType2;
            parameters[5].Value = model.PScore;
            parameters[6].Value = model.Att1;
            parameters[7].Value = model.Att2;
            parameters[8].Value = model.Att3;
            parameters[9].Value = model.Att4;
            parameters[10].Value = model.float1;
            parameters[11].Value = model.float2;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.PorjectMember model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PorjectMember set ");
            strSql.Append("PItemID=@PItemID,");
            strSql.Append("PID=@PID,");
            strSql.Append("PName=@PName,");
            strSql.Append("PType=@PType,");
            strSql.Append("PType2=@PType2,");
            strSql.Append("PScore=@PScore,");
            strSql.Append("Att1=@Att1,");
            strSql.Append("Att2=@Att2,");
            strSql.Append("Att3=@Att3,");
            strSql.Append("Att4=@Att4,");
            strSql.Append("float1=@float1,");
            strSql.Append("float2=@float2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PItemID", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.NVarChar,50),
					new SqlParameter("@PName", SqlDbType.NVarChar,50),
					new SqlParameter("@PType", SqlDbType.NVarChar,50),
					new SqlParameter("@PType2", SqlDbType.NVarChar,50),
					new SqlParameter("@PScore", SqlDbType.Decimal,5),
					new SqlParameter("@Att1", SqlDbType.NVarChar,50),
					new SqlParameter("@Att2", SqlDbType.NVarChar,50),
					new SqlParameter("@Att3", SqlDbType.NVarChar,50),
					new SqlParameter("@Att4", SqlDbType.NVarChar,50),
					new SqlParameter("@float1", SqlDbType.Decimal,9),
					new SqlParameter("@float2", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PItemID;
            parameters[1].Value = model.PID;
            parameters[2].Value = model.PName;
            parameters[3].Value = model.PType;
            parameters[4].Value = model.PType2;
            parameters[5].Value = model.PScore;
            parameters[6].Value = model.Att1;
            parameters[7].Value = model.Att2;
            parameters[8].Value = model.Att3;
            parameters[9].Value = model.Att4;
            parameters[10].Value = model.float1;
            parameters[11].Value = model.float2;
            parameters[12].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PorjectMember ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PorjectMember ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.PorjectMember GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PItemID,PID,PName,PType,PType2,PScore,Att1,Att2,Att3,Att4,float1,float2 from PorjectMember ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.PorjectMember model = new Model.PorjectMember();
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
        public Model.PorjectMember DataRowToModel(DataRow row)
        {
            Model.PorjectMember model = new Model.PorjectMember();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PItemID"] != null)
                {
                    model.PItemID = row["PItemID"].ToString();
                }
                if (row["PID"] != null)
                {
                    model.PID = row["PID"].ToString();
                }
                if (row["PName"] != null)
                {
                    model.PName = row["PName"].ToString();
                }
                if (row["PType"] != null)
                {
                    model.PType = row["PType"].ToString();
                }
                if (row["PType2"] != null)
                {
                    model.PType2 = row["PType2"].ToString();
                }
                if (row["PScore"] != null && row["PScore"].ToString() != "")
                {
                    model.PScore = decimal.Parse(row["PScore"].ToString());
                }
                if (row["Att1"] != null)
                {
                    model.Att1 = row["Att1"].ToString();
                }
                if (row["Att2"] != null)
                {
                    model.Att2 = row["Att2"].ToString();
                }
                if (row["Att3"] != null)
                {
                    model.Att3 = row["Att3"].ToString();
                }
                if (row["Att4"] != null)
                {
                    model.Att4 = row["Att4"].ToString();
                }
                if (row["float1"] != null && row["float1"].ToString() != "")
                {
                    model.float1 = decimal.Parse(row["float1"].ToString());
                }
                if (row["float2"] != null && row["float2"].ToString() != "")
                {
                    model.float2 = decimal.Parse(row["float2"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PItemID,PID,PName,PType,PType2,PScore,Att1,Att2,Att3,Att4,float1,float2 ");
            strSql.Append(" FROM PorjectMember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,PItemID,PID,PName,PType,PType2,PScore,Att1,Att2,Att3,Att4,float1,float2 ");
            strSql.Append(" FROM PorjectMember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PorjectMember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from PorjectMember T ");
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
            parameters[0].Value = "PorjectMember";
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

