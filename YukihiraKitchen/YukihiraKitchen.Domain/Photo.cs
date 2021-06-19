using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YukihiraKitchen.Domain
{
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }
    }
}
