using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;

namespace MyApp.Application.UseCases
{
    public class GetAllUsers
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsers(IUserRepository userRepository) {

            _userRepository= userRepository;
        }

        public async Task<IEnumerable<User>> Execute() {

            return await _userRepository.GetAllUserAsync();
        }
    }
}
