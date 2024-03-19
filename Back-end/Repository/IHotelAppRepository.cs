using System.Linq.Expressions;

namespace HotelManagementApplication.Repository
{
    public interface IHotelAppRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false);
        Task<T> CreateAsync(T dbReord);
        Task<T> UpdateAsync(T dbRecord);
        Task<bool> DeleteAsync(T dbRecord);
    }
}
