using BCrypt.Net;
using ETMS.Application.DTOs;
using ETMS.Application.Interfaces;
using ETMS.Domain.Entities;

namespace ETMS.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var existing = await _repository.GetByEmailAsync(dto.Email);

            if (existing != null)
                throw new Exception("Email already exists");

            var user = new User
            {
                Username = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
        }
    }

}

