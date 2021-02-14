using DrawingBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingBoard.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddDraw(Draw draw)
        {
            _ctx.Draws.Add(draw);
        }

        public void RemoveDraw(string value)
        {
            _ctx.Draws.Remove(GetDraw(value));
        }

        public void UpdateDraw(Draw draw)
        {
            _ctx.Draws.Update(draw);
        }
       

        public List<Draw> GetAllDraws()
        {
            return _ctx.Draws.ToList();
        }

        public Draw GetDraw(string id)
        {
            return _ctx.Draws
                .FirstOrDefault(d => d.value == id);
        }

        public async Task SaveChangesAsync()
        {
           await _ctx.SaveChangesAsync();
        }
    }
}
