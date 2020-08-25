using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data
{
    /// <summary>
    /// Interface for all Entities DAOs (Data Access Objects)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDao<T>
    {
        /// <summary>
        /// Retrieves all records of table
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Creates an entity
        /// </summary>
        /// <param name="entity"></param>
        T Create(T entity);

        /// <summary>
        /// Gets an record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(int id);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        T Update(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Save changes in the DataBase
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
