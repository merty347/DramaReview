using DramaReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DramaReview.DataAccess
{
    public interface IDataConnection
    {
        DramaModel DodajDrame(DramaModel model);
        List<DramaModel> GetDramas();
    }
}
