using System.ComponentModel.DataAnnotations;

namespace OmniSuite.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}