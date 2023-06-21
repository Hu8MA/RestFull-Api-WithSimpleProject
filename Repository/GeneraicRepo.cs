using HomeBiuld.Data;
using HomeBiuld.Dto;
using HomeBiuld.Model;
using Microsoft.EntityFrameworkCore;
 
namespace HomeBiuld.Repository
{
    public interface GeneraicRepo<T> where T : class
    {
        public T Get(int id);
        public T Add(T obj);
        public bool Remove(int id);
        public T updata(T obj);
        public IEnumerable<T> list();

    }

    public class implementGeneraicRepo<T> : GeneraicRepo<T> where T : class
    {

        public readonly AppDbContext _context;
        public readonly DbSet<T> _dbset;
        public implementGeneraicRepo(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public T Add(T obj)
        { 
            try
            {
                _dbset.Add(obj);
                _context.SaveChanges();
                return obj;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            
        }

        public T Get(int id)
        {
            if (id >= 0)
            {
                return _dbset.Find(id);
            }
            return null;
        }

        public IEnumerable<T> list()
        {
            return _dbset.ToList();
        }

        public bool Remove(int id)
        {

            var x = Get(id);
            if (x != null)
            {
                _dbset.Remove(x);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public T updata(T obj)
        {
            if (obj != null)
            {
                _dbset.Update(obj);
                _context.SaveChanges();
                return obj;
            }
            return null;
        }
   
    
    
    }
}
