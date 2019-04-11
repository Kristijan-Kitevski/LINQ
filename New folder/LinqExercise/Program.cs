using System.Collections.Generic;
using LinqExercise.Services;
using LinqExercise.Models;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = PersonService.GetAllPeople();

            var dogs = DogService.GetAllDogs();

            #region Exercises

            //==============================
            // TODO LINQ expressions :)
            // Your turn guys...
            //==============================

            //PART 1
            // 1. Take person Cristofer and add Jack, Ellie, Hank and Tilly as his dogs.
            Person cristofer = people.FirstOrDefault(x=>x.FirstName.Equals("Cristofer"));
            if (cristofer!= null)
	          {
                cristofer.Dogs = dogs
                    .Where(x => x.Name.Equals("Jack") 
                    || x.Name.Equals("Ellie") 
                    || x.Name.Equals("Tilly") 
                    || x.Name.Equals("Hank"))
                    .ToList();
              }

            // 2. Take person Freddy and add Oscar, Toby, Chanel, Bo and Scout as his dogs.

             Person freddy = people.FirstOrDefault(x=>x.FirstName.Equals("Freddy"));
            if (freddy!= null)
	          {
                freddy.Dogs = dogs
                    .Where(x => x.Name.Equals("Oscar") 
                    || x.Name.Equals("Toby") 
                    || x.Name.Equals("Bo") 
                    || x.Name.Equals("Scout"))
                    .ToList();
              }

            // 3. Add Trixie, Archie and Max as dogs from Erin.
            Person erin = people.FirstOrDefault(x=>x.FirstName.Equals("Erin"));
            if (erin != null)
	          {
                erin.Dogs = dogs
                    .Where(x => x.Name.Equals("Trixie") 
                    || x.Name.Equals("Archie") 
                    || x.Name.Equals("Max")) 
                    .ToList();
              }
            
            // 4. Give Abby and Shadow to Amelia.

            Person amelia = people.FirstOrDefault(x=>x.FirstName.Equals("Amelia"));
            if (amelia!= null)
	          {
                amelia.Dogs = dogs
                    .Where(x => x.Name.Equals("Abby") 
                    || x.Name.Equals("Shadow"))
                    .ToList();
              }
            // 5. Take person Larry and Zoe, Ollie as his dogs.

            Person Larry = people.FirstOrDefault(x => x.FirstName.Equals("Larry"));
            if (Larry != null)
            {
                Larry.Dogs = dogs
                    .Where(x => x.Name.Equals("Zoe")
                    || x.Name.Equals("Ollie"))
                    .ToList();
            }
            // 6. Add all retrievers to Erika.
            Person erika = people.FirstOrDefault(x=>x.FirstName.Equals("Erika"));
            if (erika!= null)
	          {
                erika.Dogs = dogs
                    .Where(x => x.Race == Race.Retriever) 
                    .ToList();
              }

            // 7. Erin has Chet and Ava and now give Diesel to August thah previously has just Rigby

            //PART 2 - LINQ
            // 1. Find and print all persons firstnames starting with 'R', ordered by age - DESCENDING ORDER.
            List<Person> firstName = people
                .Where(x => x.FirstName.StartsWith("R"))
                .OrderByDescending(x=>x.Age)
                .ToList();

            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by age - ASCENDING ORDER.
            List<Dog> braonDog = dogs
                .Where(x => x.Color == Color.Brown & x.Age >=3)
                .OrderBy(x=>x.Age)
                .ToList();

            // 3. Find and print all persons with more than 2 dogs, ordered by name - DESCENDING ORDER.
            List<Person> hasTwoDogs = people.Where(x =>x.Dogs != null && x.Dogs.Count> 2)
                .OrderBy(x=>x.Dogs.Count)
                .ToList();

            // 4. Find and print all persons names, last names and job positions that have just one race type dogs.
            List<Person> oneRace = people.Where(x => x.Dogs != null 
            && x.Dogs.Select(y => y.Race)
            .Distinct()
            .Count() == 1)
            .ToList();

            // 5. Find and print all Freddy`s dogs names older than 1 year, grouped by dogs race.

            Person fredy = people.FirstOrDefault(x => x.FirstName.Equals("Freddy"));
            var fredysDogs = fredy.Dogs.Where(x => x.Age > 1).GroupBy(x => x.Race).ToList();

            foreach (var item in fredysDogs)
            {
                foreach (var item1 in item)
                {
                    System.Console.WriteLine(item1.Name);
                }
            }

            // 6. Find and print last 10 persons grouped by their age.
            // 7. Find and print all dogs names from Cristofer, Freddy, Erin and Amelia, grouped by color and ordered by name - ASCENDING ORDER.
            // 8. Find and persons that have same dogs races and order them by name length ASCENDING, then by age DESCENDING.
            // 9. Find the last dog of Amelia and print all dogs form other persons older than Amelia, ordered by dogs age DESCENDING.
            // 10. Find all developers older than 20 with more than 1 dog that contains letter 'e' in the name and print their names and job positions.

            #endregion


        }
    }
}