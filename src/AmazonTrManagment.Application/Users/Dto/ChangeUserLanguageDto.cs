using System.ComponentModel.DataAnnotations;

namespace AmazonTrManagment.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}