using Blenordia.Source.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

using Console = Blenordia.Source.Console;
using File = Blenordia.Source.Handlers.File;
using FileInfo = Blenordia.Source.Handlers.FileInfo;

namespace Blenordia
{
    public class Application
    {
        public static string? ApplicationID { get; private set; }

        private Account? MasterAccount { get; set; }

        public Application(Account account)
        {
            InitializeApplication(account);

            FileInfo KeyFileInfo = new FileInfo("public_key", ".blnky", ".\\");
            File KeyFile = new File(KeyFileInfo);
            KeyFile.WriteAllText($"-public_key:{ApplicationID}");
        }

        private void InitializeApplication(Account account)
        {
            if (string.IsNullOrEmpty(account.Info.Name))
            {
                Console.WriteError("Invalid account name.");
                return;
            }

            MasterAccount = account;
            Console.WriteLog($"Username: {MasterAccount.Info.Name}");

            if (!Setup())
            {
                Console.WriteError("Failed application setup.");
                return;
            }

            // System.Console.Clear();
            Console.WriteInfo($"Welcome {MasterAccount.Info.Name}!");

            // Console.WriteInput("G:\\Blenordia> ", out string? input);
        }

        public bool Setup()
        {
            GenerateApplicationID(out string applicationId);
            ApplicationID = applicationId;

            return true;
        }

        public void Exit()
        {
            MasterAccount = null;
        }

        public double GenerateApplicationID(out string applicationId)
        {
            Random rand = new Random();
            double factor = rand.NextDouble();
            long now = -DateTime.Now.ToBinary();

            Shredder(out string publicKey);

            double finished = CalculateApplicationID(now, factor, double.Parse(publicKey));

            applicationId = finished.ToString();
            return finished;
        }

        private double CalculateApplicationID(long now, double factor, double publicKey)
        {
            double[,] timesTable = new double[16, 2];

            for (int i = 0; i < 16; i++)
            {
                double factoredTime = (int)(now * factor / 0.5);
                double time = factor * (now * factoredTime);

                timesTable[i, 0] = factoredTime;
                timesTable[i, 1] = time;

                double finished = Math.Abs((time * timesTable[i, 0] + time * timesTable[i, 1]) / (publicKey / 1000000));

                if (i == 15) return finished;
            }

            return 0;
        }

        private void Shredder(out string publicKey)
        {
            if (MasterAccount == null)
            {
                throw new InvalidOperationException("MasterAccount is not initialized.");
            }

            string privateKey = GeneratePrivateKey();
            ApplicationID = privateKey;

            publicKey = privateKey.Replace("-", "")
                                  .Replace('0', (((int)MasterAccount.Info.Rank / 10)).ToString()[0])
                                  .Replace('2', '8');

            Console.WriteInfo($"Private key: {privateKey}");
            Console.WriteInfo($"Public key: {publicKey}");
        }

        private string GeneratePrivateKey()
        {
            var dictionary = Enumerable.Range('a', 26).ToDictionary(c => ((char)c).ToString(), c => c - 'a');
            string combinedInfo = MasterAccount!.Info.Name + MasterAccount.Info.Email + MasterAccount.Info.Name;

            int[] infoCrusher = combinedInfo.Select(c => dictionary.TryGetValue(c.ToString().ToLower(), out int value) ? value : -1)
                                            .Where(v => v != -1)
                                            .ToArray();

            string privateKey = string.Join("", infoCrusher);

            return InsertSeparators(privateKey);
        }

        private string InsertSeparators(string key)
        {
            double[] positions = { 0.125, 0.250, 0.375, 0.500, 0.625, 0.750, 0.875 };
            foreach (var pos in positions.Reverse())
            {
                int index = (int)(key.Length * pos) + (pos == 0.375 ? 3 : 2);
                key = key.Insert(index, "-");
            }
            return key;
        }

        // this was a ADHD thang dealing with numerology. actually pretty cool
        private static void Calculate453()
        {
            for (int i = 3; i < 64 * 64; i += 3)
            {
                int product = 453 * i;
                int result = product.ToString().Sum(c => c - '0');
                Console.WriteInfo($"453 * {i} = {product} = {result}");
            }
        }
    }
}
