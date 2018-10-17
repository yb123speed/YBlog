using System;
using YBlog.Core.IRepository;
using YBlog.Core.IServices;
using YBlog.Core.Repository;

namespace YBlog.Core.Services
{
    public class AdvertisementServices: IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }
    }
}
