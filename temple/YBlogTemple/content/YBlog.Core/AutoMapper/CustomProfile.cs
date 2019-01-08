﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YBlog.Core.Models.Models;
using YBlog.Core.Models.ViewModels;

namespace YBlog.Core.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<BlogArticle, BlogViewModel>();
        }
    }
}
