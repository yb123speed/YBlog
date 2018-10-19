using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YBlog.Core.IRepository;
using YBlog.Core.IServices;
using YBlog.Core.Models.Models;
using YBlog.Core.Repository;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
{
    public class AdvertisementServices:BaseServices<Advertisement>, IAdvertisementServices
    {
        //IAdvertisementRepository dal = new AdvertisementRepository();

        //public int Add(Advertisement model)
        //{
        //    return dal.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    return dal.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return dal.Query(whereExpression);
        //}

        //public int Sum(int i, int j)
        //{
        //    return dal.Sum(i, j);
        //}

        //public bool Update(Advertisement model)
        //{
        //    return dal.Update(model);
        //}
    }
}
