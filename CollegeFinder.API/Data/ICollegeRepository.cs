using System.Threading.Tasks;
using CollegeFinder.Api.Models;

namespace CollegeFinder.Api.Data
{
    public interface ICollegeRepository
    {
        Task<College> AddNewCollege(College college);
        Task<College> UpdateCollege(string collegeName);
        Task<College> DeleteCollege(string name);
        Task<bool> CollegeExists(string name);
    }
}