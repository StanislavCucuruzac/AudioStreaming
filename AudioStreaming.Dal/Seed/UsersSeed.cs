using AudioStreaming.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Seed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "stas",
                    Email = "stanislav.cucuruzac11@gmail.com",
                };

                await userManager.CreateAsync(user, "MyPa$$word1");
            }
        }
    }
}
