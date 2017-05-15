using Shop.Models;
using Shop.Models.DBModel;

namespace Shop.Validator.Core
{
    public interface IUserValidator
    {
        bool ValidateUser(User user, out ErrorResponse errorResponse);
    }
}
