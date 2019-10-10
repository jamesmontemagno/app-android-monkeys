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

        }
    }
}
