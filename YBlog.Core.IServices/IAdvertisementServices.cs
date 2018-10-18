using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YBlog.Core.Models.Models;

namespace YBlog.Core.IServices
{
    public interface IAdvertisementServices
    {
        int Sum(int i, int j);
        int Add(Advertisement model);
        bool Delete(Advertisement model);
        bool Update(Advertisement model);
        List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
    }
}
