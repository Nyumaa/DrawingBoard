using DrawingBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingBoard.Data.Repository
{
    public interface IRepository
    {
        Draw GetDraw(string id);
        List<Draw> GetAllDraws();
        void AddDraw(Draw draw);
        void RemoveDraw(string value);
        void UpdateDraw(Draw draw);
        Task SaveChangesAsync();
    }
}
