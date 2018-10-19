using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YBlog.Core.IRepository.Base;
using YBlog.Core.Models.Models;

namespace YBlog.Core.IRepository
{
    public partial interface IAdvertisementRepository: IBaseRepository<Advertisement>
    {
        //int Sum(int i, int j);


        //int Add(Advertisement model);
        //bool Delete(Advertisement model);
        //bool Update(Advertisement model);
        //List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
    }
}
