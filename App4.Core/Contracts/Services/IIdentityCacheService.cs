using System.Text;

using Microsoft.Identity.Client;

namespace App4.Core.Contracts.Services;

public interface IIdentityCacheService
{
    void SaveMsalToken(byte[] token);

    byte[] ReadMsalToken();
}
