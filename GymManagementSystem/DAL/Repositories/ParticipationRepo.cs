using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace GymManagementSystem.DAL.Repositories
{
    using GymManagementSystem.DAL.Entities;
    using GymManagementSystem.DAL;
    class ParticipationRepo
    {
        #region QUERIES
        private const string ALL_PART = "select * from UCZESTNICZY";
        #endregion

        #region CRUD
        public static List<Participation> LoadParticipation()
        {
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var output = cnn.Query<Participation>(ALL_PART);
                return output.ToList();
            }
        }
        #endregion
    }
}
