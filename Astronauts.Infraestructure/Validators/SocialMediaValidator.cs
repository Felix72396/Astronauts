using Astronauts.Core.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Astronauts.Infraestructure.Validators;

public class SocialMediaValidator : AbstractValidator<SocialMediaDto>
{
    public SocialMediaValidator()
    {
        RuleFor(socialMedia => socialMedia.Description)
        .MaximumLength(40)
        .WithMessage("The description has more than 40 characters.");

        RuleFor(socialMedia => socialMedia.Description)
        .NotEmpty()
        .WithMessage("The description mustn't be empty or null.");

        RuleFor(socialMedia => socialMedia.Link)
        .MaximumLength(100)
        .WithMessage("The description has more than 100 characters.");

        RuleFor(socialMedia => socialMedia.Link)
        .NotEmpty()
        .WithMessage("The link mustn't be empty or null.");

        RuleFor(socialMedia => socialMedia.Link)
        .Must(link => CheckIsLinkValid(link))
        .WithMessage("The link format is not valid.");

    }

    public bool CheckIsLinkValid(string link)
    {
        string pattern = @"^(https?):\/\/[^\s/$.?#].[^\s]*$";

        return Regex.IsMatch(link, pattern);
    }
}
