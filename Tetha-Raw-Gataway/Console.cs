using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TethaRawGataway
{
    internal class Console
    {
        
        public void Start()
        {
            try
            {
                System.Console.WriteLine("Pripojeno");
                /*MainMenu();*/
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("Problem with access to DB.");
            }
            System.Console.WriteLine("End");
        }

        public void MainMenu()
        {
            Menu menu = new Menu("Vyberte jednu možnost: ");

        menu.Add(new MenuItem("Vyhledat statistiky jedné rasy.",
                new Action(() => 
                {
                    var m = ;
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat rasu jedné postavy.",
                new Action(() =>
                {
                    var m = ;
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat postavy jedné rasy.",
                new Action(() =>
                {
                    var m = ;
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat zbraň postavy.",
                new Action(() =>
                {
            var m = ;
            var item = m.Execute();
            item.Execute();
        })));
            menu.Add(new MenuItem("Vyhledat brnění postavy.",
                new Action(() =>
                {
                    var m = ;
                    var item = m.Execute();
                    item.Execute();
                })));

            menu.Add(new MenuItem("Ukončit program", new Action(() => { exit = true; })));

            while (!exit)
            {
                var item = menu.Execute();
        item.Execute();
            }
    }
}
