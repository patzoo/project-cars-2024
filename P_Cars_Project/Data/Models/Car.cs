using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_Cars_Project.Data.Models
{
    public class Car
    {
     /// <summary>
        /// car id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// car brand 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Brand { get; set; } = null!;

        /// <summary>
        /// car model 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;

        /// <summary>
        /// photo of the car 
        /// </summary>
        [Required]
        public string CarPhoto { get; set; } = null!;

        public int Year { get; set; }

        /// <summary>
        /// if the car is booked
        /// </summary>
        public bool IsBooked { get; set; } = false;

        /// <summary>
        /// foreign key 
        /// </summary>  
        public int CategoryId { get; set; }

        /// <summary>
        /// foreign key
        /// </summary> 
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        /// foreign key 
        /// </summary>  
        public string IdentityUserId { get; set; }

        /// <summary>
        /// foreign key
        /// </summary> 
        public IdentityUser? IdentityUser { get; set; }
    }
}
