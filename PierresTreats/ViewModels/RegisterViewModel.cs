using System.ComponentModel.DataAnnotations;

namespace PierresTreats.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address: ")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password: ")]
    [RegularExpression("^(?=.*[a-z])(?=.*\\d).{6,}$", ErrorMessage = "Your password must contain at least six characters, a lowercase letter, and a number.")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password: ")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}