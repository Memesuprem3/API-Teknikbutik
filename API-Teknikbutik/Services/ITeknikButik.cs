namespace API_Teknikbutik.Services
{
    public interface ITeknikButik<T>
    {
        //crud time
        Task<IEnumerable<T>> GetAll();
        
        //T = valfri model?
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
