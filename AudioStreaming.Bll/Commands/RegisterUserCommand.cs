using AudioStreaming.Common.Dtos.Account;
using AudioStreaming.Domain;
using AudioStreaming.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public UserManager<User> UserManager { get; set; }
        public UserForRegisterDto Dto { get;  set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                UserName = request.Dto.UserName
            };
                       
            var userInsertion = await request.UserManager.CreateAsync(user, request.Dto.Password);

            if (userInsertion.Succeeded)
            {
                return IdentityResult.Success;
            }

            return IdentityResult.Failed();
        }
    }
}
