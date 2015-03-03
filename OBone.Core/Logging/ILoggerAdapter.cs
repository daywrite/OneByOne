// -----------------------------------------------------------------------
//  <copyright file="ILoggerAdapter.cs" company="OBone开源团队">
//      Copyright (c) 2014 OBone. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-10 22:14</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OBone.Core.Logging
{
    /// <summary>
    /// 定义日志实现适配器的方法
    /// </summary>
    public interface ILoggerAdapter
    {
        /// <summary>
        /// 由指定类型获取<see cref="ILog"/>日志实例
        /// </summary>
        /// <param name="type">指定类型</param>
        /// <returns></returns>
        ILog GetLogger(Type type);

        /// <summary>
        /// 由指定名称获取<see cref="ILog"/>日志实例
        /// </summary>
        /// <param name="name">指定名称</param>
        /// <returns></returns>
        ILog GetLogger(string name);
    }
}