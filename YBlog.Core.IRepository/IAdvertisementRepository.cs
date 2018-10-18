using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YBlog.Core.Models.Models;

namespace YBlog.Core.IRepository
{
    public interface IAdvertisementRepository
    {
        int Sum(int i, int j);


        int Add(Advertisement model);
        bool Delete(Advertisement model);
        bool Update(Advertisement model);
        List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
    }
}
