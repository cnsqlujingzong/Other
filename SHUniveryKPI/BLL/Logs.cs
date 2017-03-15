using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using System.Web;
using SHUniversity.KPI.Tools;
namespace SHUniversity.KPI.BLL
{
	/// <summary>
	/// Logs
	/// </summary>
	public partial class Logs
	{
		private readonly DAL.Logs dal=new DAL.Logs();
		public Logs()
		{}
		#region  BasicMethod

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="title"></param>
        /// <param name="con"></param>
        public static void LogWrite(string title,string con)
        {
            DAL.Logs dal2 = new DAL.Logs();
            Model.Users u = (Model.Users)HttpContext.Current.Session["userinfo"];
            Model.Logs l = new Model.Logs();
            l.OUser = u.Name;
            l.OUserID = u.WorkID;
            l.StarDatetime = DateTime.Now;
            l.Title = title;
            l.Common = con;
            dal2.Add(l);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Logs model)
		{
			return dal.Add(model);
		}


		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Logs GetModelByCache(int ID)
		{
			
			string CacheKey = "LogsModel-" + ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.Logs)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Logs> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Logs> DataTableToList(DataTable dt)
		{
			List<Model.Logs> modelList = new List<Model.Logs>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Logs model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

