using App4.ViewModels;

namespace App4.Contracts.Services;

public interface IUserDataService
{
    event EventHandler<UserViewModel> UserDataUpdated;

    void Initialize();

    UserViewModel GetUser();
}
