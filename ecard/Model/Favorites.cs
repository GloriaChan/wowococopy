using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecard.Model
{
    public class Favorites
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Your Friend's Name")]
        [Display(Prompt = "Your Friend's Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string friendname { get; set; }

        [DisplayName("Your Friend's Email")]
        [Display(Prompt = "Your Friend's Email")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string friendemail { get; set; }

        [DisplayName("Email Subject")]
        [Display(Prompt = "Email Subject")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string subject { get; set; }

        [DisplayName("Your Custom Message")]
        [Display(Prompt = "Your Custom Message")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string message { get; set; }

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
        [Display(Prompt = "Breakfast, Brunch, Lunch, Dinner, Dessert")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string favmeal { get; set; }

        [DisplayName("Favorite Type of Drink")]
        [Display(Prompt = "Water, Juice, Soda, Alcohol")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string favdrink { get; set; }

        [DisplayName("Favorite Type of Dessert")]
        [Display(Prompt = "Pastries, Ice Cream, Cookies")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string favdessert { get; set; }

        [DisplayName("Favorite Type of Alcohol")]
        [Display(Prompt = "Shots, Beer, Wine, Mixed Drinks, On the Rocks")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string favalcohol { get; set; }





        public string created { get; set; }
        public string created_ip { get; set; }

    }
}