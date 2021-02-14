using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingBoard.Models
{
    public class Draw
    {
        [Key]
        public int Id { get; set; }
        public string value { get; set; }
    }
}
