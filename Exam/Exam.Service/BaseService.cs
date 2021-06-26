using Exam.Core.Entity;
using Exam.Core.Entity.Enums;
using Exam.Core.Service;
using Exam.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Readonly belirtilen field'lar değiştirilemez.
        private readonly ExamContext _context;

        //Dependency Injection
        public BaseService(ExamContext context)
        {
            _context = context;
        }

        public bool Active(Guid id)
        {
            //Önce aktif edilecek olanı çektik. Active yaptık ve buradaki Update'e gönderdik.
            T activated = GetById(id);
            activated.Status = Status.Active;
            return Update(activated);
        }

        public bool Add(T item)
        {
            try
            {
                //Context gelen tipten bağımsız nesneyi set edip itemi add yaptık. Ardından SaveChanges yaptık.
                _context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        //Status'u deleted olmayanları getirecek. Sadece aktifleri değil.
        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();

        public List<T> GetAll() => _context.Set<T>().ToList();

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().FirstOrDefault(exp);

        public T GetById(Guid id) => _context.Set<T>().Find(id);

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid id)
        {
            try
            {
                //Sileceğimiz item ı buluyoruz.
                T item = GetById(id);
                //Deleted hale getirdik.
                item.Status = Status.Deleted;
                return Update(item);
            }
            catch
            {

                return false;
            }
        }

        public int Save() => _context.SaveChanges();

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
