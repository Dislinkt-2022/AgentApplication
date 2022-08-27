using AgentApplication.Client.Model.DTO;
using AgentApplication.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AgentApplication.Client.Pages
{
    partial class SignIn : ComponentBase
    {
        SignInDTO SignInModel = new();
        
        [Inject]
        private IUserService _usersService { get; set; }

        void Reset()
        {
            SignInModel.UserName = null;
            SignInModel.Password = null;
        }

        async Task OnSubmit()
        {
            var result = await _usersService.SignInAsync(SignInModel);
            Console.WriteLine(string.Format("SignIn: {0}", result));
        }
    }
}
