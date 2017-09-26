using MT.SJAlpha.EFCoreCodeFirst.Interfaces;
using MT.SJAlpha.EFCoreCodeFirst.Entitis;
using System;
using System.Linq;

namespace MT.SJAlpha.EFCoreCodeFirst.Repository
{
    public class UserRepository : IRepository<User>
    {
        private EFDbContext _dbContext = new EFDbContext();

        public IQueryable<User> Queryable { get { return _dbContext.User; } }

        public void Delete(int id)
        {
            var entity = GetFirstOrDefaultById(id);
            if (entity != null)
                _dbContext.User.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(User model)
        {
            if (model.Id == 0)
            {
                _dbContext.User.Add(model);
            }
            else
            {
                var entity = GetFirstOrDefaultById(model.Id);
                if (entity != null)
                {
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.Password = model.Password;
                    entity.Sex = model.Sex;
                    entity.Name = model.Name;
                    entity.Type = model.Type;
                    entity.DepartmentId = model.DepartmentId;
                    entity.Remark = model.Remark;
                }
            }
            _dbContext.SaveChanges();
        }

        public User GetFirstOrDefaultById(int id)
        {
            var entity = _dbContext.User.FirstOrDefault(a => a.Id == id);
            return entity;
        }

        public User GetFirstOrDefaultByAccount(string account)
        {

            return _dbContext.User.FirstOrDefault(a => a.Account == account);
        }
        /// <summary>
        /// 获得申请加入的列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetApplyAccount()
        {
            return _dbContext.User.Where(a => a.Type.Equals("new"));
        }
        public IQueryable<User> GetAccountForType(string type)
        {
            return _dbContext.User.Where(a => a.Type == type);
        }
    }
}
