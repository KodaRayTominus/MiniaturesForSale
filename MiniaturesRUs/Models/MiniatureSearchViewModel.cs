using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class MiniatureSearchViewModel

    {    /// <summary>
         /// This is a viewmodel for filtering
         /// Miniatures
         /// </summary>
        public MiniatureSearchViewModel()
        {
            SearchResults = new List<Miniature>();
        }
        
        public string Name { get; set; }
        
        public double? Price { get; set; }
        
        public string Description { get; set; }
        
        public int? Year { get; set; }
        
        public string GameName { get; set; }
        
        public string Faction { get; set; }

        public char? Size { get; set; }

        public int? Speed { get; set; }

        public int? Attack { get; set; }

        public int? Strength { get; set; }

        public int? HitPoints { get; set; }

        public int? Defense { get; set; }

        public List<Miniature> SearchResults { get; set; }
    }
}