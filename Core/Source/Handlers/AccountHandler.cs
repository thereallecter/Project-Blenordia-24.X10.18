namespace Blenordia.Source.Handlers
{
    public enum Rank
    {
        Visitor = 0, Player = 1,
        Artist = 10, Tester = 15, Donator = 20,
        Moderator = 30, Admin = 40, Developer = 45,
        Owner = 50
    }

    public struct AccountInfo
    {
        public AccountInfo(string name, string email, string password, Rank rank = Rank.Visitor)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            if (!email.Contains("@"))
            {
                throw new ArgumentException($"'{nameof(email)}' is not a proper email address.", nameof(email));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            if (password.Length < 6)
            {
                throw new ArgumentException($"'{nameof(password)}' length should be greater than 8.", nameof(password));
            }

            Name = name;
            Email = email;
            Password = password;
            Rank = rank;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rank Rank { get; set; }
    }

    public class Account
    {
        public Account Self { get; }
        public AccountInfo Info { get; }

        private Account(AccountInfo info)
        {
            Info = info;
            Self = this;
        }

        public static Account Register(AccountInfo info)
        {
            return new Account(info);
        }
    }
}
