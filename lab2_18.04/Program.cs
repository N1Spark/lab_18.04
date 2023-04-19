using System.IO;
using System.Threading;

namespace lab2_18._04
{
    class Bank
    {
        private string FileName = "file.txt";
        private readonly object fileLock = new object();
        private int money;
        private string name;
        private int percent;
        private Thread Thread_name;
        private Thread Thread_money;
        private Thread Thread_per;
        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                if (Thread_money == null || !Thread_money.IsAlive)
                {
                    Thread_money = new Thread(() => Record("Money", money));
                    Thread_money.Start();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (Thread_name == null || !Thread_name.IsAlive)
                {
                    Thread_name = new Thread(() => Record("Name", name));
                    Thread_name.Start();
                }
            }
        }
        public int Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                if (Thread_per == null || !Thread_per.IsAlive)
                {
                    Thread_per = new Thread(() => Record("Percent", percent));
                    Thread_per.Start();
                }
            }
        }

        private void Record(string propertyName, object value)
        {
            lock (fileLock)
                using (StreamWriter writer = new StreamWriter(FileName, true))
                    writer.WriteLine($"{propertyName} -> {value}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Money = 2500;
            bank.Name = "Monobank";
            bank.Percent = 2;
            bank.Money = 25000;
        }
    }
}
