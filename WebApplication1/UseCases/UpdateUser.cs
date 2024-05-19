using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;

namespace MyApp.Application.UseCases
{
    public class UpdateUser
    {
        private readonly IUserRepository _userRepository;

        public UpdateUser(IUserRepository userRepository) {

            _userRepository = userRepository;
        
        }

        public async Task<User> Execute(User user) {


            return await _userRepository.UpdateUserAsyn(user);
        }
    }
}
