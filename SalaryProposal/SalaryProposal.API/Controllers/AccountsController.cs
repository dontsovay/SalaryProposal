using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Presenters;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [Obsolete]
    public class AccountsController : ControllerBase
    {
        /// <summary>The register user use case</summary>
        private readonly IRegisterUserUseCase _registerUserUseCase;

        /// <summary>The register user presenter</summary>
        private readonly RegisterUserPresenter _registerUserPresenter;

        /// <summary>Initializes a new instance of the <see cref="AccountsController"/> class.</summary>
        /// <param name="registerUserUseCase">The register user use case.</param>
        /// <param name="registerUserPresenter">The register user presenter.</param>
        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/accounts
        /// <summary>Posts the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]  
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}
