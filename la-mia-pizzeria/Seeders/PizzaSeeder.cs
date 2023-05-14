﻿using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Seeders
{
    public class PizzaSeeder : Seeder<Pizza>
    {

        public PizzaSeeder() : base(new()
        {
            new ("Margherita", "La classica margherita", 8, true),
            new ("Capricciosa", "Il nostro cavallo di battaglia", 9.5),
            new ("Diavola", "La mia preferita :p", 9, true),
            new ("Vienna", null, 9, false),
            new ("Quattro Formaggi", "Gorgonzola, bufala, ricotta e cacio", 9.5),
        })
        { }

        public override DbSet<Pizza> GetDbSet(PizzeriaContext context)
        {
            return context.Pizzas;
        }
    }
}