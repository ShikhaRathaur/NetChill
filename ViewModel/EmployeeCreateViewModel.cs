using netchill.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netchill.ViewModel
{
    public class EmployeeCreateViewModel
    {  
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]

        public string Year_of_Release  { get; set; }

    
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time)]
        public DateTime Availability_Starts { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]        
        public Boolean IsFeatured {get; set;}

        
        [Required]        
        public Boolean IsUpcoming {get; set;}

 
       [Required]        
        public Boolean IsNewRelease {get; set;}


       [Required]
        public string genre { get; set; }


        public IFormFile Photo { get; set; }

        public IFormFile ContentFile { get; set; }

    }
}
