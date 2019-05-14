using System.ComponentModel.DataAnnotations;

namespace SimpleStupid.Model 
{
    public class Category
    {
        public int Id {get;set;}
        
        [Required]
        public string Name {get;set;}
    }
}