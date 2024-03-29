﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        bool Add(T item);
        bool Update(T item);
        Task<bool> Remove(int id);
        Task<bool> Remove(T item);
    }
}
