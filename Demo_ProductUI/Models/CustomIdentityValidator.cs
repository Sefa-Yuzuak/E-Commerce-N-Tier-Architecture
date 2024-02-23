using Microsoft.AspNetCore.Identity;

namespace Demo_ProductUI.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Parola 6 karakter olmalıdır"
            };

        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola En az 1 büyük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola En az 1 küçük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNumeric",
                Description = "Parola En az 1 alfanumeric harf içermelidir."
            };
        }
    }
}
