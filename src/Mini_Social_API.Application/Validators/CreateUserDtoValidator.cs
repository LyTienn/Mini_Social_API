using FluentValidation;
using Mini_Social_API.Application.Dtos;

namespace Mini_Social_API.Application.Validators
{
	public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
	{
		public CreateUserDtoValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Username không được để trống.")
				.MaximumLength(50).WithMessage("Username tối đa 50 ký tự.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email không được để trống.")
				.EmailAddress().WithMessage("Email không hợp lệ.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password không được để trống.")
				.MinimumLength(6).WithMessage("Password phải có ít nhất 6 ký tự.");
		}
	}
}