using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Shared
{
    public class MonkeyViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public MonkeyViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();
        }

        public async Task GetMonkeys()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("https://montemagno.com/monkeys.json");

                var monkeys = Monkey.FromJson(json);
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                //write a cool unit test NEVER
                Console.WriteLine(ex);
            }
        }
    }
}
