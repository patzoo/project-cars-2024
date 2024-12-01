using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace P_Cars_Project.Data.Models
{
    public class Category
    {
        /// <summary>
        /// category id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// name of the category 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// relation of the tables 
        /// one to many
        /// </summary>
        public IEnumerable<Car>? Cars { get; init; } = new List<Car>();
    }
}