using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netchill.Model
{
    public class SuperuserEvent
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
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


        [Required]
        public string Movie_Poster_Path { get; set; }

       
        [Required]
        public string Content_Path { get; set; }

       


       


    }
}
