using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BakkiefyBackend.Model;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BakkiefyBackend.Repositories.Core
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(BakkieDbContext bakkieDbContext)
            :base(bakkieDbContext)
        {

        }
        public async Task<TicketModel> AddTicket(TicketModel ticketModel)
        {
            try
            {
                var _ticket = new Ticket
                {
                    TicketId = 0,
                    TecketNumber = ticketModel.TecketNumber,
                    BakkieRequestId = ticketModel.BakkieRequestId,
                    CostId = ticketModel.CostId,
                    IsPayed = ticketModel.IsPayed,
                    Notes = ticketModel.Notes
                };
                var ticket = await _bakkieDbContext.Tickets.AddAsync(_ticket);
                return ticketModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       

        public async Task<TicketModel> UpdateTicket(TicketModel ticketModel)
        {
            try
            {
                var _item = await _bakkieDbContext.Tickets.FirstOrDefaultAsync(p => p.TicketId == ticketModel.TicketId);
                if(_item != null)
                {
                    _item.TicketId = 0;
                    _item.TecketNumber = ticketModel.TecketNumber;
                    _item.BakkieRequestId = ticketModel.BakkieRequestId;
                    _item.CostId = ticketModel.CostId;
                    _item.IsPayed = ticketModel.IsPayed;
                    _item.Notes = ticketModel.Notes;

                    _bakkieDbContext.Tickets.Update(_item);
                    await _bakkieDbContext.SaveChangesAsync();
                    return ticketModel;
                }
                else
                {
                    return null;
                }
               
           
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}