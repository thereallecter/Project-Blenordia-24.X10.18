using System;

namespace Blenordia.Source.Handlers
{
    /// <summary>
    /// Defines the permission levels for user accounts
    /// </summary>
    public enum Rank
    {
        Visitor = 0,
        Player = 1,
        Artist = 10,
        Tester = 15,
        Donator = 20,
        Moderator = 30,
        Admin = 40,
        Developer = 45,
        Owner = 50
    }

    /// <summary>
    /// Represents user account information and credentials
    /// </summary>
    public readonly struct AccountInfo
    {
        private const int MinPasswordLength = 6;

        /// <summary>
        /// Creates a new AccountInfo instance
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when any parameter is invalid</exception>
        public AccountInfo(string name, string email, string password, Rank rank = Rank.Visitor)
        {
            ValidateParameters(name, email, password);

            Name = name;
            Email = email;
            Password = password;
            Rank = rank;
        }

        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public Rank Rank { get; }

        private static void ValidateParameters(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            if (!email.Contains('@'))
                throw new ArgumentException("Invalid email address format", nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            if (password.Length < MinPasswordLength)
                throw new ArgumentException($"Password must be at least {MinPasswordLength} characters long", nameof(password));
        }
    }

    /// <summary>
    /// Manages user account operations and state
    /// </summary>
    public sealed class Account
    {
        public AccountInfo Info { get; }

        private Account(AccountInfo info)
        {
            Info = info;
        }

        /// <summary>
        /// Creates a new account with the specified configuration
        /// </summary>
        /// <param name="info">The account configuration</param>
        /// <returns>A new Account instance</returns>
        public static Account Create(AccountInfo info)
        {
            // Here you might want to add account initialization logic
            // such as saving to a database or validating uniqueness
            return new Account(info);
        }
    }
}
