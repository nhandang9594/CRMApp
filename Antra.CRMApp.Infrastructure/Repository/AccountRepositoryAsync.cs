using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class AccountRepositoryAsync : BaseRepository<SignUpModel>, IAccountRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRepositoryAsync(CrmDbContext _dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(_dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignIn(LoginModel login)
        {
            return await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.EmailId;
            user.UserName = model.EmailId;
            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}
