using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Seeders
{
    public abstract class Seeder<j, k> where k : class
    {

        //Database connection
        static PizzeriaContext context = new PizzeriaContext();

        //List of raw data for elements creation
        static private List<j> RawList { get; set; }

        public Seeder(List<j> rawList)
        {
            RawList = rawList;
        }

        //Public method for running the database seeding
        public void Run()
        {
            foreach (j rawData in RawList)
            {
                k newItem = GenerateElementFromRawData(rawData);
                GetDbSet(context).Add(newItem);
            }
            context.SaveChanges();
        }

        //ABSTRACTS
        //Retrieve the DbSet to store elements into
        abstract public DbSet<k> GetDbSet(PizzeriaContext context);
        //Logic to translate raw data into new elements
        abstract public k GenerateElementFromRawData(j rawData);
    }

    //Utility implementation for translationsless seeders
    public abstract class Seeder<k> : Seeder<k, k> where k : class
    {
        protected Seeder(List<k> rawList) : base(rawList)
        { }

        public override k GenerateElementFromRawData(k data)
        {
            return data;
        }
    }
}
