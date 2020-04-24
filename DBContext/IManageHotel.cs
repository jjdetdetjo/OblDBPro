using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public interface IManageHotel
    {
        List<Hotel> GetAllHotel();

        Hotel GetHotelFromId(int HotelId);

        bool CreateHotel(Hotel hotel);

        bool UpdateHotel(int HotelId, Hotel hotel);

        Hotel DeleteHotel(int HotelId);
    }
}
