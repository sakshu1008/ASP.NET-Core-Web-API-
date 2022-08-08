using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerLib.Interfaces;
using DataAccessLayerLib.Models;


namespace BusinessAccessLayerLib.Services
{
    public class PersonService
    {
        //prepare for DI
        private readonly IRepository<Person> repository;
        public PersonService(IRepository<Person> repo)
        {
            this.repository = repo;
        }

        //get person details by Id
        public IEnumerable<Person> GetPersonById(string emailid)
        {
            return repository.GetAll().Where(x => x.Email == emailid).ToList();
        }

        //Get all Persons
        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

        //Get by person's name
        public Person GetByName(string emailid)
        {
            return repository.GetAll().Where(x => x.Email == emailid).FirstOrDefault();
        }

        //Add New Person
        public async Task<Person> AddPerson(Person person)
        {
            return await repository.Create(person);
        }

        //Delete person (soft deletion)
        public bool DeletePerson(string emailid)
        {
            try
            {
                var dataList = repository.GetAll().Where(x => x.Email == emailid).ToList();
                foreach(var item in dataList)
                {
                    repository.Delete(item);
                }
                return true;
            }
            catch(Exception)
            {
                return true;
            }
        }

        //Update person
        public bool UpdatePerson(Person person)
        {
            try
            {
                var dataList = repository.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach(var item in dataList)
                {
                    repository.Update(person);
                }
                return true;
            }
            catch(Exception)
            {
                return true;
            }
        }
    }
}
