using Microsoft.AspNetCore.Mvc;
using MyApp.Application.UseCases;
using MyApp.Domain.Entities;


namespace MyApp.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly CreateUser _createUser;
        private readonly DeleteUser _deleteUser;
        private readonly UpdateUser _updateUser;
        private readonly GetAllUsers _getAllUsers;
        private readonly GetUser _getUserByID;

        public UsersController(CreateUser createUser, DeleteUser deleteUser, UpdateUser updateUser, GetUser getUser, GetAllUsers getallUsers) {

            _createUser = createUser;
            _deleteUser = deleteUser;
            _updateUser = updateUser;
            _getAllUsers = getallUsers;
            _getUserByID = getUser;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _getAllUsers.Execute();
            return users;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user) {

            if (ModelState.IsValid) {
                await _createUser.Execute(user);
                return new JsonResult(new { success = true });
            }

            return new JsonResult(new { success = false });

        }

    }
}
