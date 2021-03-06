﻿using ArticleServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Data.Abstract
{
    public interface IArticleRepository : IMongoRepository<Post>
    {
    }
}
