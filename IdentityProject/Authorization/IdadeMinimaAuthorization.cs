using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace IdentityProject.Authorization
{
    public class IdadeMinimaAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNascimentoClaim = context
                                        .User
                                        .Claims
                                        .FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth);

            if (dataNascimentoClaim is null)
                return Task.CompletedTask;

            var dataNascimento = Convert.ToDateTime(dataNascimentoClaim.Value);

            var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario))
                idadeUsuario--;

            if (idadeUsuario >= requirement.Idade)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}