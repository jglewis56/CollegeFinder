using System;
using System.Threading.Tasks;
using CollegeFinder.Api.Data;
using CollegeFinder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeFinder.Api.Data
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly DataContext _context;

        public CollegeRepository(DataContext context)
        {
           _context = context;
        }
        public async Task<College> AddNewCollege(College college)
        { 
            await _context.Colleges.AddAsync(college);
            await _context.SaveChangesAsync();
            return college;
        }

        public async Task<bool> CollegeExists(string name)
        {
            if (await _context.Colleges.AnyAsync(x => x.Name == name))
                return true;
            return false;
        }

        public  async Task<College> DeleteCollege(string name)
        {
            var entity = await _context.Colleges.FirstOrDefaultAsync(x => x.Name == name);
            if (entity != null)
            {
                //make changes
                _context.Colleges.Remove(entity);
                await _context.SaveChangesAsync();
                return (entity);
            }
            return null;
        }

        public async Task<College> UpdateCollege(string collegeName)
        {
            var entity = await _context.Colleges.FirstOrDefaultAsync(x => x.Name == collegeName);
            if(entity != null)
            {
                //make changes
                _context.Colleges.Update(entity);
                await _context.SaveChangesAsync();
                return(entity);
            }
            return null;
        }
    }
}