using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Miniature
    {
        [Key]
        public int MiniId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string Faction { get; set; }

        public char? Size { get; set; }

        public int? Speed { get; set; }

        public int? Attack { get; set; }

        public int? Strength { get; set; }

        public int? HitPoints { get; set; }

        public int? Defense { get; set; }

        public Miniature()
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction)
            : this(name, price, description, year, gameName, faction, 'x', 0, 0, 0, 0, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size)
            : this(name, price, description, year, gameName, faction, size, 0, 0, 0, 0, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size, int? speed)
            : this(name, price, description, year, gameName, faction, size, speed, 0, 0, 0, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size, int? speed,
                        int? attack)
            : this(name, price, description, year, gameName, faction, size, speed, attack, 0, 0, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size, int? speed,
                        int? attack, int? strength)
            : this(name, price, description, year, gameName, faction, size, speed, attack, strength, 0, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size, int? speed,
                        int? attack, int? strength, int? hitPoints)
            : this(name, price, description, year, gameName, faction, size, speed, attack, strength, hitPoints, 0)
        {
        }

        public Miniature(string name, double price, string description, int year, string gameName, string faction, char? size, int? speed, 
                        int? attack, int? strength, int? hitPoints, int? defense)
        {
            Name = name;
            Price = price;
            Description = description;
            Year = year;
            GameName = gameName;
            Faction = faction;
            Size = size;
            Speed = speed;
            Attack = attack;
            Strength = strength;
            HitPoints = hitPoints;
            Defense = defense;
        }

    }
}