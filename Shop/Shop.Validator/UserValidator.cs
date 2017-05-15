using Shop.Models;
using Shop.Models.DBModel;
using Shop.Validator.Core;

namespace Shop.Validator
{

    public class UserValidator : IUserValidator
    {
        public UserValidator()
        {

        }
        public bool ValidateUser(User user, out ErrorResponse errorResponse)
        {
            if (user==null)
            {
                errorResponse = new InvalidNullUser();
                return false;
            }
            if (user.email == null)
            {
                errorResponse = new InvalidEmailUser();
                return false;
            }
            errorResponse = null;
            return true;
        }
    }
}