using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;

namespace MyApp.Application.UseCases
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository) {

            _userRepository = userRepository;
        }
        public async Task<User> Execute(User user) {

            return await _userRepository.CreateUserAsync (user);
        }

       
    }
}
