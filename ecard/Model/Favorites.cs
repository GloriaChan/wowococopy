using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecard.Model
{
    public class Favorites
    {
        [Key]
        public int ID { get; set; }


        [DisplayName("Your Name")]
        [Display(Prompt = "Your Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string sendername { get; set; }

        [DisplayName("Your Email")]
        [Display(Prompt = "Your Email")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string senderemail { get; set; }


        [DisplayName("Favorite Meal of the Day")]

        [Required(ErrorMessage = "Required")]

        public string favmeal { get; set; }

        [DisplayName("Should I Add More Cheese")]
        [Required(ErrorMessage = "Required")]
        public string favcheese { get; set; }

        [DisplayName("How Spicy")]
        [Required(ErrorMessage = "Required")]
        public string favspicy { get; set; }

        [DisplayName("Favorite Type of Drink")]

        [Required(ErrorMessage = "Required")]

        public string favdrink { get; set; }

        [DisplayName("Favorite Type of Dessert")]

        [Required(ErrorMessage = "Required")]

        public string favdessert { get; set; }

        [DisplayName("Favorite Type of Alcohol")]

        [Required(ErrorMessage = "Required")]

        public string favalcohol { get; set; }





        public string created { get; set; }
        public string created_ip { get; set; }

    }
}