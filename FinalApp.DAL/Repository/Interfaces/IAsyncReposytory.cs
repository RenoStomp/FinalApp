using FinalApp.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.DAL.Repository.Interfaces
{
    public interface IAsyncReposytory<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Creates one object and adds it to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Create(T entity);           // C - Create
        public IQueryable<T> Get();             // R - Read all
        public Task<IQueryable<T>> GetAsync();  // R - Read all async
        public T GetById(int id);               // R - Read one
        public Task<T> GetByIdAsync(int id);    // R - Read one async
        public Task Update(T Item);             // U - Update
        public Task Delete(T item);             // D - Delete by model
        public Task DeleteById(int id);         // D - Delete by id
    }
}
