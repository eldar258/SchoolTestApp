using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    // TODO 4: unauthorized users should receive 401 status code
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize] 
        [HttpGet]
        public ValueTask<Account> Get()
        {
            return _accountService.LoadOrCreateAsync(Request.Cookies["ExternalId"] /* TODO 3: Get user id from cookie */);
            //Resolved
        }

        //TODO 5: Endpoint should works only for users with "Admin" Role
        [Authorize]
        [HttpGet("{id}")]
        public Account GetByInternalId([FromRoute] int id)
        {
            var curAccount = _accountService.LoadOrCreateAsync(Request.Cookies["ExternalId"]).Result;
            if (curAccount.Role == "Admin")
            {
                return _accountService.GetFromCache(id);
            }
            else return null;
            //Resolved
        }

        [Authorize]
        [HttpPost("counter")]
        public async Task UpdateAccount()
        {
            //Update account in cache, don't bother saving to DB, this is not an objective of this task.
            var account = await Get();
            account.Counter++;
        }
    }
}