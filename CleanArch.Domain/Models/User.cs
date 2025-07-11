using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Exceptions;

namespace CleanArch.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreateAt { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(string phoneNumber, string name)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ActioException("empty_user_phoneNumber",
                    "User phoneNumber can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_user_name",
                    "User name can not be empty.");
            }

            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            CreateAt = DateTime.Now;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ActioException("empty_password",
                    "Password can not be empty.");
            }

            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
        => password.Equals(encrypter.GetHash(password, Salt));
    }
}
