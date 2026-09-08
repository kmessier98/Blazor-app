using FluentValidation;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Validators
{
    public class CreateMembreDtoValidator : AbstractValidator<CreateMembreDto>
    {
        public CreateMembreDtoValidator()
        {
            RuleFor(x => x.Nom)
                .NotEmpty().WithMessage("Le nom est requis.")
                .MinimumLength(2)
                    .WithMessage("Le nom doit contenir au moins 2 caractères.")
                .MaximumLength(256)
                    .WithMessage("le nom ne peut pas dépasser 256 caractères.")
                .Matches(@"^[a-zA-ZàâäéèêëïîôöùûüçÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ\s\-']+$")
                    .WithMessage("Le nom ne peut contenir que des lettres, espaces, apostrophes et traits d'union.");
            RuleFor(x => x.Courriel)
                .NotEmpty().WithMessage("Le courriel est requis.")
                .EmailAddress().WithMessage("Le format du courriel est invalide.")
                .MaximumLength(256).WithMessage("Le courriel ne peut pas dépasser 256 caractères.");
        }
    }
}
