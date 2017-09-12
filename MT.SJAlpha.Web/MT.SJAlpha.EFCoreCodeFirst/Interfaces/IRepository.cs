using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MT.SJAlpha.EFCoreCodeFirst.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Queryable { get; }
        void Edit(T model);
        void Delete(int id);
        T GetFirstOrDefaultById(int id);
    }
}
