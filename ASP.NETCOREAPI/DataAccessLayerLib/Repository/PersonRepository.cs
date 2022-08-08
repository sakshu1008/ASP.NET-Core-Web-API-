using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerLib.Data;
using DataAccessLayerLib.Interfaces;
using DataAccessLayerLib.Models;

namespace DataAccessLayerLib.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        //prepare for DI
        private ApplicationDbContext context;
        public PersonRepository (ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
        public async Task<Person> Create(Person entity)
        {
            var obj = await context.Persons.AddAsync(entity);
            context.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Person entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return context.Persons.Where(x => x.IsDeleted == false).ToList();
            }
            catch(Exception ee)
            {
                throw;
            }
        }

        public Person GetById(int id)
        {
            return context.Persons.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }

        public void Update(Person entity)
        {
            context.Persons.Update(entity);
            context.SaveChanges();
        }
    }
}
