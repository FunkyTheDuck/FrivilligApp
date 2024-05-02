using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Event
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public User Owner { get; set; }
        public int Voluntary_id { get; set; }
        public List<User> Volunteers { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image_url { get; set; }
        public int Wanted_volunteers { get; set; }
    }
}
