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

        /*
        //První výběr, který uživateli nabídne možnosti vyhledávání
        public void MainMenu()
        {
            Menu menu = new Menu("Vyberte jednu možnost: ");

            menu.Add(new MenuItem("Vyhledat statistiky jedné rasy.",
                new Action(() =>
                {
                    var m = NajitStatistikyPodleRasy();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat rasu jedné postavy.",
                new Action(() =>
                {
                    var m = NajitRasuPostavy();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat postavy jedné rasy.",
                new Action(() =>
                {
                    var m = NajitPostavyStoutoRasou();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat zbraň postavy.",
                new Action(() =>
                {
                    var m = NajitZbranPostavy();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Vyhledat brnění postavy.",
                new Action(() =>
                {
                    var m = NajitBrneniPostavy();
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
        
        
        private bool exit = false;

        private Menu NajitStatistikyPodleRasy()
        {
            Menu m = new Menu("Vyber rasu, podle které chceš najít statistiky: ");
            RasaDAO rasaDAO = new RasaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var rasa in rasaDAO.GetAll())
            {
                m.Add(new MenuItem(rasa.ToString(), new Action(() =>
                {
                    string statsFound = string.Join(", ",
                        hcd.GetStatistikyByRasa(rasa).Select(m => m.ID + " Sila: " + m.Sila + " Obratnost: " + m.Obratnost + " Odolnost: " + m.Odolnost + " Inteligence: " + m.Inteligence + " Postreh: " + m.Postreh + " Charisma: " + m.Charisma));
                    System.Console.WriteLine(statsFound);
                })));
            }
            return m;
        }

        private Menu NajitRasuPostavy()
        {
            Menu m = new Menu("Vyber postavu, u které chceš zjistit rasu: ");
            PostavaDAO postavaDAO = new PostavaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var postava in postavaDAO.GetAll())
            {
                m.Add(new MenuItem(postava.ToString(), new Action(() =>
                {
                    string rasaFound = string.Join(", ",
                        hcd.GetRasaByPostava(postava).Select(m => m.Jmeno + " " + m.Popis ));
                    System.Console.WriteLine(rasaFound);
                })));
            }
            return m;
        }

        private Menu NajitZbranPostavy()
        {
            Menu m = new Menu("Vyber postavu, u které chceš zjistit zbran: ");
            PostavaDAO postavaDAO = new PostavaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var postava in postavaDAO.GetAll())
            {
                m.Add(new MenuItem(postava.ToString(), new Action(() =>
                {

                    try
                    {
                        string mecFound = string.Join(", ",
                        hcd.GetMecByPostava(postava).Select(m => m.Jmeno + " " + m.Pocet_hodu_kostkou + "D" + m.Jaka_kostka));
                        System.Console.WriteLine(mecFound);
                    }catch (Exception ex)
                    {
                        System.Console.WriteLine();
                    }

                    try
                    {
                        string lukFound = string.Join(", ",
                                                hcd.GetLukByPostava(postava).Select(m => m.Jmeno + " se sílou " + m.Sila_luku + "lb"));
                        System.Console.WriteLine(lukFound);
                    }catch(Exception ex)
                    {
                        System.Console.WriteLine();
                    }

                    try
                    {
                        string staffFound = string.Join(", ",
                        hcd.GetStaffByPostava(postava).Select(m => m.Jmeno + " má kamapitu " + m.Kapacita_many + " many a bonus na casteni: " + m.Bonus_na_casteni));
                        System.Console.WriteLine(staffFound);
                    }catch (System.Exception ex)
                    {
                        System.Console.WriteLine();
                    }
                    
                })));
            }
            return m;
        }

        private Menu NajitBrneniPostavy()
        {
            Menu m = new Menu("Vyber postavu, u které chceš zjistit zbran: ");
            PostavaDAO postavaDAO = new PostavaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var postava in postavaDAO.GetAll())
            {
                m.Add(new MenuItem(postava.ToString(), new Action(() =>
                {

                    try
                    {
                        string helmaFound = string.Join(", ",
                        hcd.GetHelmaByPostava(postava).Select(m => m.Jmeno + " z " + m.Material + " s obrannou tridou: " + m.ObranaTrida + ", vahou: " + m.Vaha + " a cenou: " + m.Cena));
                        System.Console.WriteLine(helmaFound);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine();
                    }

                    try
                    {
                        string torzoFound = string.Join(", ",
                          hcd.GetTorzoByPostava(postava).Select(m => m.Jmeno + " z " + m.Material + " s obrannou tridou: " + m.ObranaTrida + ", vahou: " + m.Vaha + " a cenou: " + m.Cena));
                        System.Console.WriteLine(torzoFound);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine();
                    }

                    try
                    {
                        string botyFound = string.Join(", ",
                        hcd.GetBotyByPostava(postava).Select(m => m.Jmeno + " z " + m.Material + " s obrannou tridou: " + m.ObranaTrida + ", vysoké: " + m.Vyska + ", vahou: " + m.Vaha + " a cenou: " + m.Cena));
                        System.Console.WriteLine(botyFound);
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine();
                    }

                })));
            }
            return m;
        }

        private Menu NajitPostavyStoutoRasou()
        {
            Menu m = new Menu("Vyber rasu, od které chceš vyhledat rasy: ");
            RasaDAO rasaDAO = new RasaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var rasa in rasaDAO.GetAll())
            {
                m.Add(new MenuItem(rasa.ToString(), new Action(() =>
                {
                    string statsFound = string.Join(", ",
                        hcd.GetPostavyByRasa(rasa).Select(m => m.Jmeno + " " + m.Prijmeni));
                    System.Console.WriteLine(statsFound);
                })));
            }
            return m;
        }

        /*
        private Menu VsechnyHelmy()
        {
            Menu m = new Menu("Vypis všech helem: ");
            HelmaDAO helmaDAO = new HelmaDAO();

            HrdinaConsoleDAO hcd = new HrdinaConsoleDAO();
            foreach (var helma in helmaDAO.GetAll())
            {
                m.Add(new MenuItem(helma.ToString(), new Action(() =>
                {
                    string listHelem = string.Join(',',
                        hcd.SeraditHelmyPodleViditelnosti().Select(m => m.Jmeno + " z " + m.Material + " s obrannou tridou: " + m.ObranaTrida + ", vahou: " + m.Vaha + " a cenou: " + m.Cena));
                    System.Console.WriteLine(listHelem);
                })));
            }
            return m;
        }
        */
    }
}
