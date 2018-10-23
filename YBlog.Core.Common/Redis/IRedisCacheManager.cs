﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YBlog.Core
{
    public interface IRedisCacheManager
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get<TEntity>(string key);
        //设置
        void Set(string key, object value, TimeSpan cacheTime);
        //判断是否存在
        bool Get(string key);
        //移除
        void Remove(string key);
        //清除
        void Clear();
    }
}
