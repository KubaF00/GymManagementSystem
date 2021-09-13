using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class User
    {
        private long user_id;
        private string pass_code ="pocz";
        private string localization_id;
        private string user_type;
        private DateTime creation_date;
        private DateTime pass_expire_date;
        public User(long id_użytkownika, string kod_karnetu, string id_lokalizacji, string typ_użytkownika, DateTime data_utworzenia, DateTime data_wyg_karnetu)
        {
            user_id = id_użytkownika;
            pass_code = kod_karnetu;
            localization_id = id_lokalizacji;
            user_type = typ_użytkownika;
            creation_date = data_utworzenia;
            pass_expire_date = data_wyg_karnetu;
        }
        
//$exception	{"A parameterless default constructor or one matching signature
   //         "(System.Int64 id_użytkownika, System.String kod_karnetu, System.String id_lokalizacji, System.String typ_użytkownika, System.DateTime data_utworzenia, System.DateTime data_wyg_karnetu)

}
}
