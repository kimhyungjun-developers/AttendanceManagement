using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Policies;

/// <summary>管理者の承認</summary>
public class AdministratorRequirement : IAuthorizationRequirement
{
}