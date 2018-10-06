using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Miniature
    {
        int MiniId { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        double Price { get; set; }

        [Required]
        string Description { get; set; }

        [Required]
        DateTime Year { get; set; }

        [Required]
        string GameName { get; set; }

        [Required]
        string Faction { get; set; }

        char Size { get; set; }

        int Speed { get; set; }

        int Attack { get; set; }

        int Strength { get; set; }

        int HitPoints { get; set; }

        int Defense { get; set; }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, string faction)
        {
            MiniId = miniId;
            Name = name;
            Price = price;
            Description = description;
            Year = year;
            GameName = gameName;
            Faction = faction;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size) 
            : this(miniId, name, price, description, year, gameName, faction)
        {
            Size = size;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size, int speed) 
            : this(miniId, name, price, description, year, gameName, faction, size)
        {
            Speed = speed;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size, int speed, int attack) 
            : this(miniId, name, price, description, year, gameName, faction, size, speed)
        {
            Attack = attack;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size, int speed, int attack, int strength) 
            : this(miniId, name, price, description, year, gameName, faction, size, speed, attack)
        {
            Strength = strength;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size, int speed, int attack, int strength, int hitPoints) 
            : this(miniId, name, price, description, year, gameName, faction, size, speed, attack, strength)
        {
            HitPoints = hitPoints;
        }

        public Miniature(int miniId, string name, double price, string description, DateTime year, string gameName, 
                        string faction, char size, int speed, int attack, int strength, int hitPoints, int defense) 
            : this(miniId, name, price, description, year, gameName, faction, size, speed, attack, strength, hitPoints)
        {
            Defense = defense;
        }
    }
}