using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netchill.Model
{
    public class DCandidate
    {
         [Key]
          public int id { get; set; }   

          [Column(TypeName = "nvarchar(100)")]
          public string username { get; set; }

        
       
         public int movieid { get; set; }   

    }
}
