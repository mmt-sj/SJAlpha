using MT.SJAlpha.EFCoreCodeFirst.Interfaces;
using MT.SJAlpha.EFCoreCodeFirst.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MT.SJAlpha.EFCoreCodeFirst.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        private EFDbContext _dbContext = new EFDbContext();

        public IQueryable<Department> Queryable { get { return _dbContext.Department; } }

        public void Delete(int id)
        {
            var entity = GetFirstOrDefaultById(id);
            if (entity != null)
                _dbContext.Department.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(Department model)
        {
            if (model.Id == 0)
            {
                _dbContext.Department.Add(model);
            }
            else
            {
                var entity = GetFirstOrDefaultById(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                }
            }
            _dbContext.SaveChanges();
        }

        public Department GetFirstOrDefaultById(int id)
        {
            var entity = _dbContext.Department.FirstOrDefault(a => a.Id == id);
            return entity;
        }
        public Dictionary<int, string> GetDepartmentDictionary()
        {
            return _dbContext.Department.ToDictionary(a=>a.Id,a=>a.Name);
        }
    }
}
