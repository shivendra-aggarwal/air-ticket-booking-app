using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int Id);

        Task<T> Create(T obj);
    }
}
