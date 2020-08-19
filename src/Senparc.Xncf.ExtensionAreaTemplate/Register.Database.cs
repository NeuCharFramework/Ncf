﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Ncf.XncfBase;
using Senparc.Xncf.ExtensionAreaTemplate.Models.DatabaseModel;
using Senparc.Xncf.ExtensionAreaTemplate.Models.DatabaseModel.Dto;
using Senparc.Xncf.ExtensionAreaTemplate.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senparc.Xncf.ExtensionAreaTemplate
{
	public partial class Register: 
        IXncfDatabase,  //注册 XNCF 模块数据库（按需选用）
        IXncfRazorRuntimeCompilation  //需要使用 RazorRuntimeCompilation，在开发环境下实时更新 Razor Page
    {
        #region IXncfDatabase 接口

        /// <summary>
        /// 数据库前缀
        /// </summary>
        public const string DATABASE_PREFIX = "AreaTemplate_";

        /// <summary>
        /// 数据库前缀
        /// </summary>
        public string DatabaseUniquePrefix => DATABASE_PREFIX;
        /// <summary>
        /// 设置 XncfSenparcEntities 类型
        /// </summary>
        public Type XncfDatabaseDbContextType => typeof(MySenparcEntities);


        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            //实现 [XncfAutoConfigurationMapping] 特性之后，可以自动执行，无需手动添加
            //modelBuilder.ApplyConfiguration(new AreaTemplate_ColorConfigurationMapping());
        }

        public void AddXncfDatabaseModule(IServiceCollection services)
        {
            services.AddScoped(typeof(Color));
            services.AddScoped(typeof(ColorDto));
            services.AddScoped(typeof(ColorService));
        }

        #endregion
    }
}