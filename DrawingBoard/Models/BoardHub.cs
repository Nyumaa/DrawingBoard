using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingBoard.Data;
using DrawingBoard.Data.Repository;
using Microsoft.AspNetCore.SignalR;

namespace DrawingBoard.Models
{
    public class BoardHub : Hub
    {
        private IRepository _repo;
        public BoardHub(IRepository repo)
        {
            _repo = repo;
        }
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public async Task Draw(string data)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveDraw", data);   
        }

        public async Task Move(string data, string x, string y)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveMove", data, x, y);
        } 
        
        public async Task ChangeText(string data, string text)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveChangeText", data, text);
        }
        public async Task Remove(string data)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveRemove", data);
        }

        public async Task ChangeSize(string data, string width, string height)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveChangeSize", data, width, height);
        }
        public override async Task OnConnectedAsync()
        {
            List<Draw> draws = _repo.GetAllDraws();
            List<string> pathList = new List<string>();
            draws.ForEach(x => pathList.Add(x.value));
            string paths = String.Join("|||", pathList.ToArray()); ;
            await Clients.Caller.SendAsync("ReceiveConnect", paths);
            await base.OnConnectedAsync();  
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
