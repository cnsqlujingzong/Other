using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using SHUniversity.KPI.Model;
using SHUniversity.KPI.Tools;
namespace SHUniversity.KPI.BLL
{
	/// <summary>
	/// UserKPI
	/// </summary>
	public partial class UserKPI
	{
		private readonly SHUniversity.KPI.DAL.UserKPI dal=new SHUniversity.KPI.DAL.UserKPI();
		public UserKPI()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
        public bool Exists(string wid,int year)
        {
            return dal.Exists(wid,year);
        }
        public bool Exists(int ID, string wid)
        {
            return dal.Exists(ID, wid);
        }
        public bool isEdit(int ID)
        {
            return dal.isEdit(ID);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SHUniversity.KPI.Model.UserKPI model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SHUniversity.KPI.Model.UserKPI model)
		{
			return dal.Update(model);
		}
        public bool ChangeStatus(string kid,int s, string user, string wid)
        {
            return dal.ChangeStatus(kid,s,user,wid);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SHUniversity.KPI.Model.UserKPI GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SHUniversity.KPI.Model.UserKPI GetModelByCache(int ID)
		{
			
			string CacheKey = "UserKPIModel-" + ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache =ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SHUniversity.KPI.Model.UserKPI)objModel;
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
		public List<SHUniversity.KPI.Model.UserKPI> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SHUniversity.KPI.Model.UserKPI> DataTableToList(DataTable dt)
		{
			List<SHUniversity.KPI.Model.UserKPI> modelList = new List<SHUniversity.KPI.Model.UserKPI>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SHUniversity.KPI.Model.UserKPI model;
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

