using AudioStreaming.Bll.Commands;
using AudioStreaming.Common.Dtos.Account;
using AudioStreaming.Domain.Auth;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
	public class UserController : AppBaseController
	{
		private readonly UserManager<User> _userManager;

		public UserController(UserManager<User> manager){
			_userManager=manager;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterUser(UserForRegisterDto dto)
		{
			var command = new RegisterUserCommand() { Dto = dto, UserManager = _userManager };
			var registerResult = await Mediator.Send(command);

			if (registerResult.Succeeded)
			{
				return Ok(registerResult);
			}

			return BadRequest();
		}
	}
}
