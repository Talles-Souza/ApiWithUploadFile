﻿

using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<Person> Create(Person person)
        {
            try
            {
                _context.Add(person);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Person people = await _context.People.Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
                if (people == null) return false;
                _context.People.Remove(people);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ICollection<Person>> FindAll()
        {
            List<Person> people = await _context.People.ToListAsync();
            return people;
        }

        public async Task<Person> FindById(int id)
        {
            Person person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<Person> Update(Person person)
        {
           // Person person2 = new Person();
            //_context.Entry(person).CurrentValues.SetValues(person2);
            _context.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
