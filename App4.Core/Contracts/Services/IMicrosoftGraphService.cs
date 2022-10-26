using App4.Core.Models;

namespace App4.Core.Contracts.Services;

public interface IMicrosoftGraphService
{
    Task<User> GetUserInfoAsync(string accessToken);

    Task<string> GetUserPhoto(string accessToken);
}
