using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DramaReview.Models;

namespace DramaReview.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        public DramaModel DodajDrame(DramaModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Dramas")))
            {
                var d = new DynamicParameters();
                d.Add("@Tytul", model.Tytul);
                //d.Add("@RokObejrzenia", model.RokObejrzenia);
                d.Add("@OcenaAktorstwo", model.OcenaAktorstwo);
                d.Add("@OcenaFabula", model.OcenaFabula);
                d.Add("@OcenaOST", model.OcenaOST);
                d.Add("@OcenaZakonczenie", model.OcenaZakonczenie);
                d.Add("@OcenaWizualna", model.OcenaWizualna);
                d.Add("@OcenaSrednia", model.OcenaSrednia);
                d.Add("@Zdjecie", model.Zdjecie);
                d.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spDrama_Insert", d, commandType: CommandType.StoredProcedure);

                model.ID = d.Get<int>("@ID");

                return model;
            }

        }

        public List<DramaModel> GetDramas()
        {
            List<DramaModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Dramas")))
            {
                output = connection.Query<DramaModel>("dbo.spDramas_GetAll").ToList();
            }
            return output;
        }
    }
}
