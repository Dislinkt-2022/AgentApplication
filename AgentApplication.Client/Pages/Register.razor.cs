using AgentApplication.Client.Model.DTO;
using AgentApplication.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AgentApplication.Client.Pages
{
    partial class Register : ComponentBase
    {
        RegisterDTO RegisterModel = new();

        [Inject]
        private IUserService _usersService { get; set; }

        void Reset()
        {
            RegisterModel.FirstName = null;
            RegisterModel.LastName = null;
            RegisterModel.Email = null;
            RegisterModel.UserName = null;
            RegisterModel.Password = null;
            RegisterModel.ConfirmPassword = null;
        }

        async Task OnSubmit()
        {
            var result = await _usersService.RegisterAsync(RegisterModel);
            Console.WriteLine(string.Format("Register: {0}", result));
        }
    }
}
