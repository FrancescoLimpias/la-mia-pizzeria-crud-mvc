﻿using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static
{
    public class LongDescriptionValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            //Description is null
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string description = (string)value;

            // Description is not long enough
            if (description.Split(" ").Count() < 5)
                return new ValidationResult("La descrizione, se inserita, deve avere almeno 5 parole");

            return ValidationResult.Success;
        }
    }
}