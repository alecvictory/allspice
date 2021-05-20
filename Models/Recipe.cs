using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string Description { get; set; } = "No Description";

        [Required]

        public int CookTime { get; set; }

        public string Picture { get; set; } = "https://placehold.it/200x200";
    }
}