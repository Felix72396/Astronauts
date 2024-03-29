﻿using Astronauts.Core.DTOs;
using FluentValidation;

namespace Astronauts.Infraestructure.Validators;

public class AstronautValidator : AbstractValidator<AstronautDto>
{
    public AstronautValidator()
    {
        RuleFor(astronaut => astronaut.FirstName)
        .MaximumLength(25)
        .WithMessage("The firstname must have max 25 characteres.");

        RuleFor(astronaut => astronaut.FirstName)
        .NotEmpty()
        .WithMessage("The first name mustn't be empty or null.");


        RuleFor(astronaut => astronaut.LastName)
        .MaximumLength(25)
        .WithMessage("The last name must have max 25 characteres.");

        RuleFor(astronaut => astronaut.LastName)
        .NotEmpty()
        .WithMessage("The last name mustn't be empty or null.");


        RuleFor(astronaut => astronaut.Nationality)
        .MaximumLength(20)
        .WithMessage("The nationality must have max 20 characteres.");

        RuleFor(astronaut => astronaut.Nationality)
        .NotEmpty()
        .WithMessage("The nationality mustn't be empty or null.");


        RuleFor(astronaut => astronaut.Description)
        .MaximumLength(200)
        .WithMessage("The description must have max 200 characteres.");


        RuleFor(astronaut => astronaut.BirthDate)
        .NotEmpty()
        .WithMessage("The date mustn't be empty or null.");

        RuleFor(astronaut => astronaut.BirthDate)
       .Must(birthDate => CheckIsOld(birthDate))
       .WithMessage("There's no proffesional astronaut yourger than 18.");
    }

    public bool CheckIsOld(DateTime? birthDate)
    {
        if (!birthDate.HasValue)
            return false;

        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Value.Year;

        if (birthDate.Value.Date > today.AddYears(-age))
            age--;

        return age >= 18;
    }
}
