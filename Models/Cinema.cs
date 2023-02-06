using onlineTickets.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace onlineTickets.Models
{
    public class Cinema:IEntityBase 
    {
        [Key]
        public int Id  { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required (ErrorMessage = "Logo is required")]
        public string  Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Name is required")]
        public string  Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
