using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeFinder.Api.Models
{
// See a list of colleges in the system
// Add a new college to the system
// Click on a college to see the details
// Edit the details of a college(from the details screen)
// Delete a college from the system
    public class College
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Major> Majors  { get; set; }
    }
}