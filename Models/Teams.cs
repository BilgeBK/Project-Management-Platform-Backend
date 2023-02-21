using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerPlatformDb.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public string TeamTitle { get; set; }
        public List<User> TeamList { get; set; }
    }
}
