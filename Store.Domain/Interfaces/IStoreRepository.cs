﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task Create(Domain.Entities.Store store);

        Task<IEnumerable<Domain.Entities.Store>> GetAll();
    }
}