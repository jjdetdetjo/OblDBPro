using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public interface IManageFaciliteter
    {
        List<Faciliteter> GetAllFaciliteter();

        Faciliteter GetFaciliteterFromId(int FacilitetId);

        bool CreateFacilitet(Faciliteter facilitet);

        bool UpdateFacilitet(int FacilitetId, Faciliteter facilitet);

        Faciliteter DeleteFacilitet(int FacilitetId);
    }
}
