using Exam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exam.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        //Bunların gövdelerini Service katmanında dolduracağız. Şu an sadece bir temel belirtiyor.
        bool Add(T item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);//Verilecek sorguya göre verileri çekecek.
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        bool Active(Guid id); //Belirtilen id'deki kayıt active mi.
        bool Any(Expression<Func<T, bool>> exp); //Verilecek sorguya uyan bir kayıt var mı ona bakacak.
        IQueryable<T> GetAllQueryable();
        int Save();

    }
}
