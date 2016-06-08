﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysRole
    /// </summary>
    public partial class SysRole : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public SysRole()
        { }

        #region Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysRole model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_SysRole_ADD");
            db.AddInParameter(dbCommand, "SysRoleID", DbType.Int64, model.SysRoleID);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, model.ParentID);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, model.RoleName);
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, model.Code);
            db.AddInParameter(dbCommand, "Sort", DbType.Int32, model.Sort);
            db.AddInParameter(dbCommand, "Weight", DbType.Int32, model.Weight);
            db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            db.AddInParameter(dbCommand, "FK_MerchantID", DbType.Int64, model.FK_MerchantID);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            db.AddOutParameter(dbCommand, "ResultCode", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "ResultMessage", DbType.String, 1000);
            db.ExecuteNonQuery(dbCommand);

            var result = XCLCMS.Data.DAL.Common.Common.GetProcedureResult(dbCommand.Parameters);
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                throw new Exception(result.ResultMessage);
            }
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysRole model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_SysRole_Update");
            db.AddInParameter(dbCommand, "SysRoleID", DbType.Int64, model.SysRoleID);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, model.ParentID);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, model.RoleName);
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, model.Code);
            db.AddInParameter(dbCommand, "Sort", DbType.Int32, model.Sort);
            db.AddInParameter(dbCommand, "Weight", DbType.Int32, model.Weight);
            db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            db.AddInParameter(dbCommand, "FK_MerchantID", DbType.Int64, model.FK_MerchantID);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            db.AddOutParameter(dbCommand, "ResultCode", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "ResultMessage", DbType.String, 1000);
            db.ExecuteNonQuery(dbCommand);

            var result = XCLCMS.Data.DAL.Common.Common.GetProcedureResult(dbCommand.Parameters);
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                throw new Exception(result.ResultMessage);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysRole GetModel(long SysRoleID)
        {
            XCLCMS.Data.Model.SysRole model = new XCLCMS.Data.Model.SysRole();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from SysRole where SysRoleID=@SysRoleID");
            db.AddInParameter(dbCommand, "SysRoleID", DbType.Int64, SysRoleID);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            var lst = XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysRole>(ds.Tables[0]);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysRole> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM SysRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            var ds = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.SysRole>(ds) as List<XCLCMS.Data.Model.SysRole>;
        }

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 获取指定userid的角色
        /// </summary>
        public List<XCLCMS.Data.Model.SysRole> GetListByUserID(long userId)
        {
            string strSql = @"SELECT
                                        a.*
                                        FROM dbo.SysRole AS a
                                        INNER JOIN dbo.SysUserRole AS b ON b.FK_UserInfoID=@FK_UserInfoID AND b.RecordState='N' AND a.RecordState='N' and a.SysRoleID=b.FK_SysRoleID";
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "FK_UserInfoID", DbType.Int64, userId);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.SysRole>(ds) as List<XCLCMS.Data.Model.SysRole>;
        }

        /// <summary>
        /// 判断角色标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select top 1 1 from SysRole where Code=@Code");
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, code);
            return db.ExecuteScalar(dbCommand) != null;
        }

        /// <summary>
        /// 获取指定SysRoleID所属的层级list
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysRoleSimple> GetLayerListBySysRoleID(long sysRoleID)
        {
            string str = string.Format("select * from fun_SysRole_GetLayerListByID({0})", sysRoleID);
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(str.ToString());
            DataSet ds = db.ExecuteDataSet(dbCommand);
            var lst = XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.Custom.SysRoleSimple>(ds) as List<XCLCMS.Data.Model.Custom.SysRoleSimple>;
            if (null != lst)
            {
                lst.Reverse();
            }
            return lst;
        }

        /// <summary>
        /// 删除指定SysRoleID下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysRole model)
        {
            string strSql = string.Format("update SysRole set RecordState='{0}',UpdateTime=@UpdateTime,UpdaterID=@UpdaterID,UpdaterName=@UpdaterName where ParentID=@SysRoleID and RecordState='{1}' and ParentID>0",
                                    XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString(), XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString());

            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SysRoleID", DbType.Int64, model.SysRoleID);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);
            return db.ExecuteNonQuery(dbCommand) > 0;
        }

        /// <summary>
        /// 根据SysRoleID查询其子项
        /// </summary>
        public List<XCLCMS.Data.Model.SysRole> GetChildListByID(long sysRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
                                        a.*
                                        FROM dbo.SysRole AS a
                                        where ParentID=@ParentID and RecordState='N'
                                        ");
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, sysRoleID);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.SysRole>(ds) as List<XCLCMS.Data.Model.SysRole>;
        }

        /// <summary>
        /// 根据code查询model
        /// </summary>
        public XCLCMS.Data.Model.SysRole GetModelByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
                                        top 1
                                        a.*
                                        FROM dbo.SysRole AS a
                                        where a.RecordState='N' and a.Code=@Code
                                        ");

            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, code);
            DataSet ds = db.ExecuteDataSet(dbCommand);

            var lst = XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysRole>(ds.Tables[0]);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        #endregion MethodEx
    }
}