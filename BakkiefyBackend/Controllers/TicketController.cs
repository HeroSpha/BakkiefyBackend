using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BakkiefyBackend.Repositories.Interface;

namespace BakkiefyBackend.Controllers
{
    public class TicketController : BaseController<MyHub.MyHub>
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
    }
}
