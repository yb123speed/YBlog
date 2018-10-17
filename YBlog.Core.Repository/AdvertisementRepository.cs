using System;
using System.Collections.Generic;
using System.Text;
using YBlog.Core.IRepository;

namespace YBlog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
