using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Application.DTOs
{
    public class DirectionDto
    {
        public Guid DirectionId { get; set; }
        public string CookingDirection { get; set; }
        public int CookingStepNumber { get; set; }
    }
}
