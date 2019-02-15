using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakkiefyBackend.Model;

namespace BakkiefyBackend.Repositories.Interface
{
    public interface ITicketRepository
    {
        Task<TicketModel> AddTicket(TicketModel ticketModel);
        Task<TicketModel> UpdateTicket(TicketModel ticketModel);
    }
}
