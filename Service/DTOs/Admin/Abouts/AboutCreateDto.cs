﻿using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Abouts
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }

    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(s => s.Description)
                .NotEmpty();

            RuleFor(m => m.Image)
                .NotEmpty();

            RuleFor(m => m.Image)
                .Must(m => m.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(item => item.Length / 1024 < 1024)
                .WithMessage("Image size cannot exceed 1MB")
                .When(m => m.Image is not null);
        }
    }
}
