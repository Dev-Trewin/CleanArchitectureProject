using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;

namespace MyApp.Application.UseCases
{
    public class GetUser
    {
        private readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository) {

            _userRepository=userRepository;
        }
        public async Task<User> Execute(Guid Id) {

            return await _userRepository.GetUserByIdAsync(Id);
        }
    }
}
