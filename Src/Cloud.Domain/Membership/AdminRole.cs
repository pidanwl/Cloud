﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>管理员与角色映射表</summary>
    [Serializable]
    [DataObject]
    [Description("管理员与角色映射表")]
    [BindIndex("PK_AdminRole", true, "ID")]
    [BindIndex("IX_AdminRole_AdminID", false, "AdminID")]
    [BindIndex("IX_AdminRole_RoleID", false, "RoleID")]
    [BindRelation("AdminID", false, "Admin", "ID")]
    [BindRelation("RoleID", false, "Role", "ID")]
    [BindTable("AdminRole", Description = "管理员与角色映射表", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class AdminRole : IAdminRole
    {
        #region 属性
        private Int32 _ID;
        /// <summary>主键ID</summary>
        [DisplayName("主键ID")]
        [Description("主键ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "主键ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Int32 _AdminID;
        /// <summary>管理员</summary>
        [DisplayName("管理员")]
        [Description("管理员")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "AdminID", "管理员", null, "int", 10, 0, false)]
        public virtual Int32 AdminID
        {
            get { return _AdminID; }
            set { if (OnPropertyChanging(__.AdminID, value)) { _AdminID = value; OnPropertyChanged(__.AdminID); } }
        }

        private Int32 _RoleID;
        /// <summary>角色</summary>
        [DisplayName("角色")]
        [Description("角色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "RoleID", "角色", null, "int", 10, 0, false)]
        public virtual Int32 RoleID
        {
            get { return _RoleID; }
            set { if (OnPropertyChanging(__.RoleID, value)) { _RoleID = value; OnPropertyChanged(__.RoleID); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.ID : return _ID;
                    case __.AdminID : return _AdminID;
                    case __.RoleID : return _RoleID;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.AdminID : _AdminID = Convert.ToInt32(value); break;
                    case __.RoleID : _RoleID = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得管理员与角色映射表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>管理员</summary>
            public static readonly Field AdminID = FindByName(__.AdminID);

            ///<summary>角色</summary>
            public static readonly Field RoleID = FindByName(__.RoleID);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得管理员与角色映射表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID</summary>
            public const String ID = "ID";

            ///<summary>管理员</summary>
            public const String AdminID = "AdminID";

            ///<summary>角色</summary>
            public const String RoleID = "RoleID";

        }
        #endregion
    }

    /// <summary>管理员与角色映射表接口</summary>
    public partial interface IAdminRole
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int32 ID { get; set; }

        /// <summary>管理员</summary>
        Int32 AdminID { get; set; }

        /// <summary>角色</summary>
        Int32 RoleID { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}