using MyApp.Domain.Repositories;

namespace MyApp.Application.UseCases
{
    public class DeleteUser
    {
        private readonly IUserRepository _userRepository;

        public DeleteUser(IUserRepository userRepository) {

            _userRepository = userRepository;
        }

        public async Task Excute(int Id) {
            await _userRepository.DeleteUserAsync(Id);
        
        }
    }
}
