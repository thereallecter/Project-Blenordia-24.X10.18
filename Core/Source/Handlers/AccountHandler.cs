namespace Blenordia.Source.Handlers
{
    public enum Rank
    {
        Visitor = 0, Player = 1,
        Artist = 10, Tester = 15, Donator = 20,
        Moderator = 30, Admin = 40, Developer = 45,
        Owner = 50
    }

    // TODO [+] [10/12/2024 11:05] Create class AccountInfo {}
    public struct AccountInfo
    {
        public AccountInfo()
        {
            Name = "HuskyJew";
            Email = "example@gmail.com";
            Password = "!Password2024";
            Rank = Rank.Player;
        }

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

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
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

    // TODO [+] [10/10/2024 22:06] Make class static
    public class Account
    {
        public Account Self;
        public AccountInfo Info;

        public Account(AccountInfo info)
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
