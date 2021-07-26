using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Ticket
    {
        #region Properties
        public string TicketCode { get; set; }
        public decimal Price { get; set; }
        public string TicketName { get; set; }
        public int Duration { get; set; }
        #endregion

        #region Constructors
        public Ticket(SQLiteDataReader reader)
        {
            TicketCode = reader["kod_karnetu"].ToString();
            Price = decimal.Parse(reader["cena"].ToString());
            TicketName = reader["nazwa"].ToString();
            Duration = int.Parse(reader["ile_dni"].ToString());
        }

        public Ticket(string ticketCode, decimal price, string ticketName, int duration)
        {
            TicketCode = ticketCode; Price = price; TicketName = ticketName; Duration = duration;
        }
        #endregion

        #region Methods
        #endregion
    }
}
