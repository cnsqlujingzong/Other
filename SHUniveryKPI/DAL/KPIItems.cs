using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;//Please add references
namespace SHUniversity.KPI.DAL
{
	/// <summary>
	/// 数据访问类:KPIItems
	/// </summary>
	public partial class KPIItems
	{
		public KPIItems()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "KPIItems"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KPIItems");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.KPIItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KPIItems(");
            strSql.Append("KPINO,ItemType,ItemDate,ItemCreator,ItemLastUpdateDate,ItemUpdateUser,ItemNO,ProjectType,ProjectNO,ProjectName,Str1,Str2,Str3,Str4,Str5,Str6,Str7,Str8,Str9,Str10,Str11,Str12,float1,float2,float3,float4,float5,float6,float7,float8,float9,float10,Int1,Int2,Int3,Int4,Int5,Int6,Int7,Int8,Int9,Int10,datetime1,datetime2,datetime3,datetime4,datetime5,text1,text2,text3,text4,text5)");
            strSql.Append(" values (");
            strSql.Append("@KPINO,@ItemType,@ItemDate,@ItemCreator,@ItemLastUpdateDate,@ItemUpdateUser,@ItemNO,@ProjectType,@ProjectNO,@ProjectName,@Str1,@Str2,@Str3,@Str4,@Str5,@Str6,@Str7,@Str8,@Str9,@Str10,@Str11,@Str12,@float1,@float2,@float3,@float4,@float5,@float6,@float7,@float8,@float9,@float10,@Int1,@Int2,@Int3,@Int4,@Int5,@Int6,@Int7,@Int8,@Int9,@Int10,@datetime1,@datetime2,@datetime3,@datetime4,@datetime5,@text1,@text2,@text3,@text4,@text5)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@KPINO", SqlDbType.Int,4),
					new SqlParameter("@ItemType", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemDate", SqlDbType.DateTime),
					new SqlParameter("@ItemCreator", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemLastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ItemUpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemNO", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectType", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectNO", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@Str1", SqlDbType.NVarChar,50),
					new SqlParameter("@Str2", SqlDbType.NVarChar,50),
					new SqlParameter("@Str3", SqlDbType.NVarChar,50),
					new SqlParameter("@Str4", SqlDbType.NVarChar,50),
					new SqlParameter("@Str5", SqlDbType.NVarChar,50),
					new SqlParameter("@Str6", SqlDbType.NVarChar,50),
					new SqlParameter("@Str7", SqlDbType.NVarChar,50),
					new SqlParameter("@Str8", SqlDbType.NVarChar,50),
					new SqlParameter("@Str9", SqlDbType.NVarChar,50),
					new SqlParameter("@Str10", SqlDbType.NVarChar,50),
					new SqlParameter("@Str11", SqlDbType.NVarChar,50),
					new SqlParameter("@Str12", SqlDbType.NVarChar,50),
					new SqlParameter("@float1", SqlDbType.Decimal,9),
					new SqlParameter("@float2", SqlDbType.Decimal,9),
					new SqlParameter("@float3", SqlDbType.Decimal,9),
					new SqlParameter("@float4", SqlDbType.Decimal,9),
					new SqlParameter("@float5", SqlDbType.Decimal,9),
					new SqlParameter("@float6", SqlDbType.Decimal,9),
					new SqlParameter("@float7", SqlDbType.Decimal,9),
					new SqlParameter("@float8", SqlDbType.Decimal,9),
					new SqlParameter("@float9", SqlDbType.Decimal,9),
					new SqlParameter("@float10", SqlDbType.Decimal,9),
					new SqlParameter("@Int1", SqlDbType.Int,4),
					new SqlParameter("@Int2", SqlDbType.Int,4),
					new SqlParameter("@Int3", SqlDbType.Int,4),
					new SqlParameter("@Int4", SqlDbType.Int,4),
					new SqlParameter("@Int5", SqlDbType.Int,4),
					new SqlParameter("@Int6", SqlDbType.Int,4),
					new SqlParameter("@Int7", SqlDbType.Int,4),
					new SqlParameter("@Int8", SqlDbType.Int,4),
					new SqlParameter("@Int9", SqlDbType.Int,4),
					new SqlParameter("@Int10", SqlDbType.Int,4),
					new SqlParameter("@datetime1", SqlDbType.DateTime),
					new SqlParameter("@datetime2", SqlDbType.DateTime),
					new SqlParameter("@datetime3", SqlDbType.DateTime),
					new SqlParameter("@datetime4", SqlDbType.DateTime),
					new SqlParameter("@datetime5", SqlDbType.DateTime),
					new SqlParameter("@text1", SqlDbType.Text),
					new SqlParameter("@text2", SqlDbType.Text),
					new SqlParameter("@text3", SqlDbType.Text),
					new SqlParameter("@text4", SqlDbType.Text),
					new SqlParameter("@text5", SqlDbType.Text)};
            parameters[0].Value = model.KPINO;
            parameters[1].Value = model.ItemType;
            parameters[2].Value = model.ItemDate;
            parameters[3].Value = model.ItemCreator;
            parameters[4].Value = model.ItemLastUpdateDate;
            parameters[5].Value = model.ItemUpdateUser;
            parameters[6].Value = model.ItemNO;
            parameters[7].Value = model.ProjectType;
            parameters[8].Value = model.ProjectNO;
            parameters[9].Value = model.ProjectName;
            parameters[10].Value = model.Str1;
            parameters[11].Value = model.Str2;
            parameters[12].Value = model.Str3;
            parameters[13].Value = model.Str4;
            parameters[14].Value = model.Str5;
            parameters[15].Value = model.Str6;
            parameters[16].Value = model.Str7;
            parameters[17].Value = model.Str8;
            parameters[18].Value = model.Str9;
            parameters[19].Value = model.Str10;
            parameters[20].Value = model.Str11;
            parameters[21].Value = model.Str12;
            parameters[22].Value = model.float1;
            parameters[23].Value = model.float2;
            parameters[24].Value = model.float3;
            parameters[25].Value = model.float4;
            parameters[26].Value = model.float5;
            parameters[27].Value = model.float6;
            parameters[28].Value = model.float7;
            parameters[29].Value = model.float8;
            parameters[30].Value = model.float9;
            parameters[31].Value = model.float10;
            parameters[32].Value = model.Int1;
            parameters[33].Value = model.Int2;
            parameters[34].Value = model.Int3;
            parameters[35].Value = model.Int4;
            parameters[36].Value = model.Int5;
            parameters[37].Value = model.Int6;
            parameters[38].Value = model.Int7;
            parameters[39].Value = model.Int8;
            parameters[40].Value = model.Int9;
            parameters[41].Value = model.Int10;
            parameters[42].Value = model.datetime1;
            parameters[43].Value = model.datetime2;
            parameters[44].Value = model.datetime3;
            parameters[45].Value = model.datetime4;
            parameters[46].Value = model.datetime5;
            parameters[47].Value = model.text1;
            parameters[48].Value = model.text2;
            parameters[49].Value = model.text3;
            parameters[50].Value = model.text4;
            parameters[51].Value = model.text5;

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
        public bool Update(Model.KPIItems model,string iteorm)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KPIItems set ");
            strSql.Append("KPINO=@KPINO,");
            strSql.Append("ItemType=@ItemType,");
            strSql.Append("ItemDate=@ItemDate,");
            strSql.Append("ItemCreator=@ItemCreator,");
            strSql.Append("ItemLastUpdateDate=@ItemLastUpdateDate,");
            strSql.Append("ItemUpdateUser=@ItemUpdateUser,");
            strSql.Append("ItemNO=@ItemNO,");
            strSql.Append("ProjectType=@ProjectType,");
            strSql.Append("ProjectNO=@ProjectNO,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("Str1=@Str1,");
            strSql.Append("Str2=@Str2,");
            strSql.Append("Str3=@Str3,");
            strSql.Append("Str4=@Str4,");
            strSql.Append("Str5=@Str5,");
            strSql.Append("Str6=@Str6,");
            strSql.Append("Str7=@Str7,");
            strSql.Append("Str8=@Str8,");
            strSql.Append("Str9=@Str9,");
            strSql.Append("Str10=@Str10,");
            strSql.Append("Str11=@Str11,");
            strSql.Append("Str12=@Str12,");
            strSql.Append("float1=@float1,");
            strSql.Append("float2=@float2,");
            strSql.Append("float3=@float3,");
            strSql.Append("float4=@float4,");
            strSql.Append("float5=@float5,");
            strSql.Append("float6=@float6,");
            strSql.Append("float7=@float7,");
            strSql.Append("float8=@float8,");
            strSql.Append("float9=@float9,");
            strSql.Append("float10=@float10,");
            strSql.Append("Int1=@Int1,");
            strSql.Append("Int2=@Int2,");
            strSql.Append("Int3=@Int3,");
            strSql.Append("Int4=@Int4,");
            strSql.Append("Int5=@Int5,");
            strSql.Append("Int6=@Int6,");
            strSql.Append("Int7=@Int7,");
            strSql.Append("Int8=@Int8,");
            strSql.Append("Int9=@Int9,");
            strSql.Append("Int10=@Int10,");
            strSql.Append("datetime1=@datetime1,");
            strSql.Append("datetime2=@datetime2,");
            strSql.Append("datetime3=@datetime3,");
            strSql.Append("datetime4=@datetime4,");
            strSql.Append("datetime5=@datetime5,");
            strSql.Append("text1=@text1,");
            strSql.Append("text2=@text2,");
            strSql.Append("text3=@text3,");
            strSql.Append("text4=@text4,");
            strSql.Append("text5=@text5");
            strSql.Append(" where ID=@ID and ItemCreator=@ItemCreator2");
            SqlParameter[] parameters = {
					new SqlParameter("@KPINO", SqlDbType.Int,4),
					new SqlParameter("@ItemType", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemDate", SqlDbType.DateTime),
					new SqlParameter("@ItemCreator", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemLastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ItemUpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemNO", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectType", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectNO", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@Str1", SqlDbType.NVarChar,50),
					new SqlParameter("@Str2", SqlDbType.NVarChar,50),
					new SqlParameter("@Str3", SqlDbType.NVarChar,50),
					new SqlParameter("@Str4", SqlDbType.NVarChar,50),
					new SqlParameter("@Str5", SqlDbType.NVarChar,50),
					new SqlParameter("@Str6", SqlDbType.NVarChar,50),
					new SqlParameter("@Str7", SqlDbType.NVarChar,50),
					new SqlParameter("@Str8", SqlDbType.NVarChar,50),
					new SqlParameter("@Str9", SqlDbType.NVarChar,50),
					new SqlParameter("@Str10", SqlDbType.NVarChar,50),
					new SqlParameter("@Str11", SqlDbType.NVarChar,50),
					new SqlParameter("@Str12", SqlDbType.NVarChar,50),
					new SqlParameter("@float1", SqlDbType.Decimal,9),
					new SqlParameter("@float2", SqlDbType.Decimal,9),
					new SqlParameter("@float3", SqlDbType.Decimal,9),
					new SqlParameter("@float4", SqlDbType.Decimal,9),
					new SqlParameter("@float5", SqlDbType.Decimal,9),
					new SqlParameter("@float6", SqlDbType.Decimal,9),
					new SqlParameter("@float7", SqlDbType.Decimal,9),
					new SqlParameter("@float8", SqlDbType.Decimal,9),
					new SqlParameter("@float9", SqlDbType.Decimal,9),
					new SqlParameter("@float10", SqlDbType.Decimal,9),
					new SqlParameter("@Int1", SqlDbType.Int,4),
					new SqlParameter("@Int2", SqlDbType.Int,4),
					new SqlParameter("@Int3", SqlDbType.Int,4),
					new SqlParameter("@Int4", SqlDbType.Int,4),
					new SqlParameter("@Int5", SqlDbType.Int,4),
					new SqlParameter("@Int6", SqlDbType.Int,4),
					new SqlParameter("@Int7", SqlDbType.Int,4),
					new SqlParameter("@Int8", SqlDbType.Int,4),
					new SqlParameter("@Int9", SqlDbType.Int,4),
					new SqlParameter("@Int10", SqlDbType.Int,4),
					new SqlParameter("@datetime1", SqlDbType.DateTime),
					new SqlParameter("@datetime2", SqlDbType.DateTime),
					new SqlParameter("@datetime3", SqlDbType.DateTime),
					new SqlParameter("@datetime4", SqlDbType.DateTime),
					new SqlParameter("@datetime5", SqlDbType.DateTime),
					new SqlParameter("@text1", SqlDbType.Text),
					new SqlParameter("@text2", SqlDbType.Text),
					new SqlParameter("@text3", SqlDbType.Text),
					new SqlParameter("@text4", SqlDbType.Text),
					new SqlParameter("@text5", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@ItemCreator2", SqlDbType.NVarChar,50),                                        
                                        };
            parameters[0].Value = model.KPINO;
            parameters[1].Value = model.ItemType;
            parameters[2].Value = model.ItemDate;
            parameters[3].Value = model.ItemCreator;
            parameters[4].Value = model.ItemLastUpdateDate;
            parameters[5].Value = model.ItemUpdateUser;
            parameters[6].Value = model.ItemNO;
            parameters[7].Value = model.ProjectType;
            parameters[8].Value = model.ProjectNO;
            parameters[9].Value = model.ProjectName;
            parameters[10].Value = model.Str1;
            parameters[11].Value = model.Str2;
            parameters[12].Value = model.Str3;
            parameters[13].Value = model.Str4;
            parameters[14].Value = model.Str5;
            parameters[15].Value = model.Str6;
            parameters[16].Value = model.Str7;
            parameters[17].Value = model.Str8;
            parameters[18].Value = model.Str9;
            parameters[19].Value = model.Str10;
            parameters[20].Value = model.Str11;
            parameters[21].Value = model.Str12;
            parameters[22].Value = model.float1;
            parameters[23].Value = model.float2;
            parameters[24].Value = model.float3;
            parameters[25].Value = model.float4;
            parameters[26].Value = model.float5;
            parameters[27].Value = model.float6;
            parameters[28].Value = model.float7;
            parameters[29].Value = model.float8;
            parameters[30].Value = model.float9;
            parameters[31].Value = model.float10;
            parameters[32].Value = model.Int1;
            parameters[33].Value = model.Int2;
            parameters[34].Value = model.Int3;
            parameters[35].Value = model.Int4;
            parameters[36].Value = model.Int5;
            parameters[37].Value = model.Int6;
            parameters[38].Value = model.Int7;
            parameters[39].Value = model.Int8;
            parameters[40].Value = model.Int9;
            parameters[41].Value = model.Int10;
            parameters[42].Value = model.datetime1;
            parameters[43].Value = model.datetime2;
            parameters[44].Value = model.datetime3;
            parameters[45].Value = model.datetime4;
            parameters[46].Value = model.datetime5;
            parameters[47].Value = model.text1;
            parameters[48].Value = model.text2;
            parameters[49].Value = model.text3;
            parameters[50].Value = model.text4;
            parameters[51].Value = model.text5;
            parameters[52].Value = model.ID;
            parameters[53].Value = iteorm;

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
		public bool Delete(int ID,string wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KPIItems ");
            strSql.Append(" where ID=@ID and ItemCreator=@wid");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@wid",SqlDbType.NVarChar,50)
			};
			parameters[0].Value = ID;
            parameters[1].Value = wid;

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
			strSql.Append("delete from KPIItems ");
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
		public SHUniversity.KPI.Model.KPIItems GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from KPIItems ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			SHUniversity.KPI.Model.KPIItems model=new SHUniversity.KPI.Model.KPIItems();
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
        /// ID 和创建人
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public SHUniversity.KPI.Model.KPIItems GetModel(int ID,string wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KPIItems ");
            strSql.Append(" where ID=@ID and ItemCreator=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@wid", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = ID;
            parameters[1].Value = wid;

            SHUniversity.KPI.Model.KPIItems model = new SHUniversity.KPI.Model.KPIItems();
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
        public SHUniversity.KPI.Model.KPIItems GetModel(string  strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KPIItems ");
            strSql.Append(" where " + strWhere);
           
            SHUniversity.KPI.Model.KPIItems model = new SHUniversity.KPI.Model.KPIItems();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public Model.KPIItems DataRowToModel(DataRow row)
        {
            Model.KPIItems model = new Model.KPIItems();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["KPINO"] != null && row["KPINO"].ToString() != "")
                {
                    model.KPINO = int.Parse(row["KPINO"].ToString());
                }
                if (row["ItemType"] != null)
                {
                    model.ItemType = row["ItemType"].ToString();
                }
                if (row["ItemDate"] != null && row["ItemDate"].ToString() != "")
                {
                    model.ItemDate = DateTime.Parse(row["ItemDate"].ToString());
                }
                if (row["ItemCreator"] != null)
                {
                    model.ItemCreator = row["ItemCreator"].ToString();
                }
                if (row["ItemLastUpdateDate"] != null && row["ItemLastUpdateDate"].ToString() != "")
                {
                    model.ItemLastUpdateDate = DateTime.Parse(row["ItemLastUpdateDate"].ToString());
                }
                if (row["ItemUpdateUser"] != null)
                {
                    model.ItemUpdateUser = row["ItemUpdateUser"].ToString();
                }
                if (row["ItemNO"] != null)
                {
                    model.ItemNO = row["ItemNO"].ToString();
                }
                if (row["ProjectType"] != null)
                {
                    model.ProjectType = row["ProjectType"].ToString();
                }
                if (row["ProjectNO"] != null)
                {
                    model.ProjectNO = row["ProjectNO"].ToString();
                }
                if (row["ProjectName"] != null)
                {
                    model.ProjectName = row["ProjectName"].ToString();
                }
                if (row["Str1"] != null)
                {
                    model.Str1 = row["Str1"].ToString();
                }
                if (row["Str2"] != null)
                {
                    model.Str2 = row["Str2"].ToString();
                }
                if (row["Str3"] != null)
                {
                    model.Str3 = row["Str3"].ToString();
                }
                if (row["Str4"] != null)
                {
                    model.Str4 = row["Str4"].ToString();
                }
                if (row["Str5"] != null)
                {
                    model.Str5 = row["Str5"].ToString();
                }
                if (row["Str6"] != null)
                {
                    model.Str6 = row["Str6"].ToString();
                }
                if (row["Str7"] != null)
                {
                    model.Str7 = row["Str7"].ToString();
                }
                if (row["Str8"] != null)
                {
                    model.Str8 = row["Str8"].ToString();
                }
                if (row["Str9"] != null)
                {
                    model.Str9 = row["Str9"].ToString();
                }
                if (row["Str10"] != null)
                {
                    model.Str10 = row["Str10"].ToString();
                }
                if (row["Str11"] != null)
                {
                    model.Str11 = row["Str11"].ToString();
                }
                if (row["Str12"] != null)
                {
                    model.Str12 = row["Str12"].ToString();
                }
                if (row["float1"] != null && row["float1"].ToString() != "")
                {
                    model.float1 = decimal.Parse(row["float1"].ToString());
                }
                if (row["float2"] != null && row["float2"].ToString() != "")
                {
                    model.float2 = decimal.Parse(row["float2"].ToString());
                }
                if (row["float3"] != null && row["float3"].ToString() != "")
                {
                    model.float3 = decimal.Parse(row["float3"].ToString());
                }
                if (row["float4"] != null && row["float4"].ToString() != "")
                {
                    model.float4 = decimal.Parse(row["float4"].ToString());
                }
                if (row["float5"] != null && row["float5"].ToString() != "")
                {
                    model.float5 = decimal.Parse(row["float5"].ToString());
                }
                if (row["float6"] != null && row["float6"].ToString() != "")
                {
                    model.float6 = decimal.Parse(row["float6"].ToString());
                }
                if (row["float7"] != null && row["float7"].ToString() != "")
                {
                    model.float7 = decimal.Parse(row["float7"].ToString());
                }
                if (row["float8"] != null && row["float8"].ToString() != "")
                {
                    model.float8 = decimal.Parse(row["float8"].ToString());
                }
                if (row["float9"] != null && row["float9"].ToString() != "")
                {
                    model.float9 = decimal.Parse(row["float9"].ToString());
                }
                if (row["float10"] != null && row["float10"].ToString() != "")
                {
                    model.float10 = decimal.Parse(row["float10"].ToString());
                }
                if (row["Int1"] != null && row["Int1"].ToString() != "")
                {
                    model.Int1 = int.Parse(row["Int1"].ToString());
                }
                if (row["Int2"] != null && row["Int2"].ToString() != "")
                {
                    model.Int2 = int.Parse(row["Int2"].ToString());
                }
                if (row["Int3"] != null && row["Int3"].ToString() != "")
                {
                    model.Int3 = int.Parse(row["Int3"].ToString());
                }
                if (row["Int4"] != null && row["Int4"].ToString() != "")
                {
                    model.Int4 = int.Parse(row["Int4"].ToString());
                }
                if (row["Int5"] != null && row["Int5"].ToString() != "")
                {
                    model.Int5 = int.Parse(row["Int5"].ToString());
                }
                if (row["Int6"] != null && row["Int6"].ToString() != "")
                {
                    model.Int6 = int.Parse(row["Int6"].ToString());
                }
                if (row["Int7"] != null && row["Int7"].ToString() != "")
                {
                    model.Int7 = int.Parse(row["Int7"].ToString());
                }
                if (row["Int8"] != null && row["Int8"].ToString() != "")
                {
                    model.Int8 = int.Parse(row["Int8"].ToString());
                }
                if (row["Int9"] != null && row["Int9"].ToString() != "")
                {
                    model.Int9 = int.Parse(row["Int9"].ToString());
                }
                if (row["Int10"] != null && row["Int10"].ToString() != "")
                {
                    model.Int10 = int.Parse(row["Int10"].ToString());
                }
                if (row["datetime1"] != null && row["datetime1"].ToString() != "")
                {
                    model.datetime1 = DateTime.Parse(row["datetime1"].ToString());
                }
                if (row["datetime2"] != null && row["datetime2"].ToString() != "")
                {
                    model.datetime2 = DateTime.Parse(row["datetime2"].ToString());
                }
                if (row["datetime3"] != null && row["datetime3"].ToString() != "")
                {
                    model.datetime3 = DateTime.Parse(row["datetime3"].ToString());
                }
                if (row["datetime4"] != null && row["datetime4"].ToString() != "")
                {
                    model.datetime4 = DateTime.Parse(row["datetime4"].ToString());
                }
                if (row["datetime5"] != null && row["datetime5"].ToString() != "")
                {
                    model.datetime5 = DateTime.Parse(row["datetime5"].ToString());
                }
                if (row["text1"] != null)
                {
                    model.text1 = row["text1"].ToString();
                }
                if (row["text2"] != null)
                {
                    model.text2 = row["text2"].ToString();
                }
                if (row["text3"] != null)
                {
                    model.text3 = row["text3"].ToString();
                }
                if (row["text4"] != null)
                {
                    model.text4 = row["text4"].ToString();
                }
                if (row["text5"] != null)
                {
                    model.text5 = row["text5"].ToString();
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
			strSql.Append(" FROM KPIItems ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SHUniversity.KPI.Model.KPIItems> GetListModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KPIItems ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable ds= DbHelperSQL.Query(strSql.ToString()).Tables[0];
            List<SHUniversity.KPI.Model.KPIItems> list = new List<Model.KPIItems>();
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow item in ds.Rows)
                {
                    SHUniversity.KPI.Model.KPIItems m = DataRowToModel(item);
                    list.Add(m);
                }
            }
            return list;

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
			strSql.Append(" FROM KPIItems ");
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
			strSql.Append("select count(1) FROM KPIItems ");
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
			strSql.Append(")AS Row, T.*  from KPIItems T ");
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
			parameters[0].Value = "KPIItems";
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

