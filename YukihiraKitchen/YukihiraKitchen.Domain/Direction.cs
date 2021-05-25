using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Domain
{
    public class Direction
    {
        public string Id { get; set; }
        public Recipe Recipe { get; set; }
        public string CookingDirection { get; set; }
        public int CookingStepNumber { get; set; }
    }
}
