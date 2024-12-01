using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace P_Cars_Project.Data.Models
{
    public class Booking
    {
        /// <summary>
        /// category id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// foreign key 
        /// </summary>  
        public int CarId { get; set; }

        /// <summary>
        /// foreign key
        /// </summary> 
        public Car Car { get; set; }

        /// foreign key 
        /// </summary>  
        public string IdentityUserId { get; set; }

        /// <summary>
        /// foreign key
        /// </summary> 
        public IdentityUser IdentityUser { get; set; }
    }
}