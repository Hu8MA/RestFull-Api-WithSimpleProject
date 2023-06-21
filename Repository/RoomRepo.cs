using HomeBiuld.Data;
using HomeBiuld.Dto;
using HomeBiuld.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeBiuld.Repository
{
    public interface RoomRepo  
    {
        public List<Room> GetList();
        public Room GetById(int id);
        public bool Create(Room room , int idTv , int idBed);
        public bool Update(Room rooM);
        public bool Delete(int id);
    }

    public class implemetRoomRepo : RoomRepo
    {
        private readonly AppDbContext _context;

        public implemetRoomRepo(AppDbContext context)
        {
           _context=context;
        }

        

        public List<Room> GetList ()
        {   
            var rooms=_context.Rooms.ToList();
            return rooms;
        }
 
        public bool Create(Room room, int idTv, int idBed)
        {
            var Bed = _context.Bads.Find(idBed);
            var Tv = _context.Tvs.Find(idTv);
             if(Bed != null && Tv != null)
            {
               
                room.Tv=Tv;
                room.Bad = Bed;

                try
                {
                    _context.Rooms.Add(room);
                    _context.SaveChanges();
                 }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public Room GetById(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
                return null;

            return room;
        }

        public bool Update(Room room)
        {
             if (room == null)
                  return false;

            _context.Rooms.Update(room);
            _context.SaveChanges();
            return true;
        }

       

        public bool Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
                return false;

            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return true;
        }
    
    
    
    
    }
}
