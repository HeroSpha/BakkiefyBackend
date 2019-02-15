using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BakkiefyBackend.MyHub
{
    public class MyHub : Hub
    {
        public void Subscribe(string CustomerId)
        {
            Groups.Add(Context.ConnectionId, CustomerId);
        }

        public void UnSubscribe(string CustomerId)
        {
            Groups.Remove(Context.ConnectionId, CustomerId);
        }
    }
}