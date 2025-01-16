using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetha_Row_Gataway;
using System.Reflection.PortableExecutable;

namespace Tetha_Row_Gataway
{
    internal class Console
    {

        public void Start()
        {
            try
            {
                System.Console.WriteLine("Pripojeno");
                MainMenu();
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("Problem with access to DB.");
            }
            System.Console.WriteLine("End");
        }

        public void MainMenu()
        {
            Menu menu = new Menu("Vyberte jednu možnost k práci: ");

            menu.Add(new MenuItem("Banka",
                    new Action(() =>
                    {
                        var m = BankAccountMenu();
                        var item = m.Execute();
                        item.Execute();
                    })));
            menu.Add(new MenuItem("Klient",
                new Action(() =>
                {
                    var m = ClientMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Transakce",
                new Action(() =>
                {
                    var m = TransactionMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Typy učtu",
                new Action(() =>
                {
                    var m = ACTypeMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Účty",
                new Action(() =>
                {
                    var m = bankMenu();
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

        
        private Menu ClientMenu()
        {
            Menu cm = new Menu("Vyberte možnost: ");
            ClientDAO clientDAO = new ClientDAO();


            cm.Add(new MenuItem("Vypsat vše ",
                new Action(() =>
                {
                    foreach (Client client in clientDAO.GetAll())
                    {
                        System.Console.WriteLine($"{client.ToString()}");
                    }
                })));

            cm.Add(new MenuItem("Vyhledat podle Id ",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište Id položky, kterou si přejete vidět.");
                    int id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        Client wantedClient = clientDAO.GetByID(id);
                        System.Console.WriteLine(wantedClient.ToString());
                    }catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    
                })));

            cm.Add(new MenuItem("Uprava nebo nový",
                new Action(() => 
                {
                    System.Console.WriteLine("Napište vlastnosti klienta v pořadí id, jméno, přijmení,telefonní číslo, email, rodné číslo a datum narození \n přesně v tomto pořadí, pokud se jedná o přidání nového klienta zadejte záporné id.");
                    try
                    {
                        Client client = new Client(Convert.ToInt32(System.Console.ReadLine()), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine());
                        clientDAO.Save(client);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch(Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    
                })));

            cm.Add(new MenuItem("Smazání záznamu", 
                new Action(() => 
                {
                    System.Console.WriteLine("Zadejte údaje klienta, kterého si přejete samzat.");
                    System.Console.WriteLine("Napište vlastnosti klienta v pořadí id, jméno, přijmení,telefonní číslo, email, rodné číslo a datum narození.");
                    try
                    {
                        Client client = new Client(Convert.ToInt32(System.Console.ReadLine()), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine());
                        clientDAO.Delete(client);
                    }catch(Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    
                })));
            cm.Add(new MenuItem("Ukončit program", new Action(() => { exitcm = true; })));

            while (!exitcm)
            {
                var item = cm.Execute();
                item.Execute();
            }

            return cm;
        }
        private bool exitcm = false;



        private bool exitbam = false;
        private Menu BankAccountMenu()
        {
            Menu bam = new Menu("Vyberte možnost: ");
            BankAccountDAO bankAccountDAO = new BankAccountDAO();

            bam.Add(new MenuItem("Vypsat všechny účty ",
                new Action(() =>
                {
                    foreach (BankAccount bankAccount in bankAccountDAO.GetAll())
                    {
                        System.Console.WriteLine($"{bankAccount.ToString()}");
                    }
                })));

            bam.Add(new MenuItem("Vyhledat účet podle Id ",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište Id položky, kterou si přejete vidět.");
                    int id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        BankAccount wantedBankAccount = bankAccountDAO.GetByID(id);
                        System.Console.WriteLine(wantedBankAccount.ToString());
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            bam.Add(new MenuItem("Uprava nebo nový účet",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište vlastnosti bankovniho uctu v pořadí id, cislo uctu, nový zůstatek, id klienta, id typu účtu a id banky \n přesně v tomto pořadí, pokud se jedná o přidání nového bankovního účtu zadejte záporné id.");
                    try
                    {
                        BankAccount bankAccount = new BankAccount(Convert.ToInt32(System.Console.ReadLine()), Convert.ToInt32(System.Console.ReadLine())
                            , Convert.ToSingle(System.Console.ReadLine()), Convert.ToBoolean(1), Convert.ToInt32(System.Console.ReadLine()),
                            Convert.ToInt32(System.Console.ReadLine()), Convert.ToInt32(System.Console.ReadLine()));
                        bankAccountDAO.Save(bankAccount);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            bam.Add(new MenuItem("Smazání účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Zadejte údaje bankovního účtu, který si přejete samzat.");
                    System.Console.WriteLine("Napište údaje o ůčtu v tomto pořadí: id, číslo účtu.");
                    try
                    {
                        BankAccount bankAccount = new BankAccount(Convert.ToInt32(System.Console.ReadLine()), Convert.ToInt32(System.Console.ReadLine()), Convert.ToSingle(0), Convert.ToBoolean(1), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0));
                        bankAccountDAO.Delete(bankAccount);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));
            bam.Add(new MenuItem("Vrátit se zpět", new Action(() => { exitbam = true; })));

            while (!exitbam)
            {
                var item = bam.Execute();
                item.Execute();
            }

            return bam;
        }

        


        private bool exittm = false;
        private Menu TransactionMenu()
        {
            Menu tm = new Menu("Vyberte možnost: ");
            TransactionDAO transactionDAO = new TransactionDAO();

            tm.Add(new MenuItem("Vypsat všechny trancakce ",
                new Action(() =>
                {
                    foreach (Transaction transaction in transactionDAO.GetAll())
                    {
                        System.Console.WriteLine($"{transaction.ToString()}");
                    }
                })));


            tm.Add(new MenuItem("Vyhledat transakci podle Id ",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište Id transakce, kterou si přejete vidět.");
                    int id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        Transaction wantedTransaction = transactionDAO.GetByID(id);
                        System.Console.WriteLine(wantedTransaction.ToString());
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            tm.Add(new MenuItem("Uprava nebo nová transakce",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište informace o transakci v pořadí id, výši obnosu, id_uctu, který peníze odeslal, id uctu, který peníze obdržel \n přesně v tomto pořadí, pokud se jedná o přidání nové transakce zadejte záporné id.");
                    try
                    {
                        Transaction transaction = new Transaction(Convert.ToInt32(System.Console.ReadLine()), Convert.ToSingle(System.Console.ReadLine()), Convert.ToInt32(System.Console.ReadLine()),
                            Convert.ToInt32(System.Console.ReadLine()));
                        transactionDAO.Save(transaction);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));




            tm.Add(new MenuItem("Smazání transakce",
                new Action(() =>
                {
                    System.Console.WriteLine("Zadejte údaje bankovního účtu, který si přejete samzat.");
                    System.Console.WriteLine("Napište údaje o ůčtu v tomto pořadí: id, číslo účtu.");
                    try
                    {
                        Transaction transaction = new Transaction(Convert.ToInt32(System.Console.ReadLine()), Convert.ToSingle(System.Console.ReadLine()), Convert.ToInt32(System.Console.ReadLine()),
                            Convert.ToInt32(System.Console.ReadLine()));
                        transactionDAO.Delete(transaction);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));
            tm.Add(new MenuItem("Vrátit se zpět", new Action(() => { exittm = true; })));

            while (!exittm)
            {
                var item = tm.Execute();
                item.Execute();
            }

            return tm;
        }
        


        private bool exitam = false;
        private Menu ACTypeMenu()
        {
            Menu am = new Menu("Vyberte možnost: ");
            AccountTypeRowGateway acTypeRG = new AccountTypeRowGateway();

            am.Add(new MenuItem("Vyhledat typ účtu podle Id ",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište Id typu účtu, který si přejete vidět.");
                    int id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        AccountType wantedType = acTypeRG.GetByID(id);
                        System.Console.WriteLine(wantedType.ToString());
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            // Vytvořeno pro ukázku, jinak nemůže fungovat, protože v databázi je vytvořen Check, který nedovolý přidat nový druh účtu,
            // pokud se nepoužije jméno existujícího druhu účtu
            am.Add(new MenuItem("Nový typ účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište informace o novém typu účtu v pořadí id, jméno typu účtu (použijte existující jméno účtu) \n a úrok u typu ůčtu přesně v tomto pořadí.");
                    try
                    {
                        AccountType acType = new AccountType(Convert.ToInt32(System.Console.ReadLine()), (Type)Enum.Parse(typeof(Type), System.Console.ReadLine(), true), Convert.ToDouble(System.Console.ReadLine()));
                        acTypeRG.InsertInto(acType);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            am.Add(new MenuItem("Upravení typu účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište  id, jméno typu účtu a nový úrok, který s k typu účtu přejete přiřadit.");
                    try
                    {
                        AccountType acType = new AccountType(Convert.ToInt32(System.Console.ReadLine()), (Type)Enum.Parse(typeof(Type), System.Console.ReadLine(), true), Convert.ToDouble(System.Console.ReadLine()));
                        acTypeRG.UpdateByID(acType);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                })));
            

            am.Add(new MenuItem("Smazání typu účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište údaje o účtu v tomto pořadí: id, číslo účtu.");
                    try
                    {
                        AccountType acType = new AccountType(Convert.ToInt32(System.Console.ReadLine()), (Type)Enum.Parse(typeof(Type), System.Console.ReadLine(), true), Convert.ToDouble(System.Console.ReadLine()));
                        acTypeRG.InsertInto(acType);
                        System.Console.WriteLine("Typ účtu smazán");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));
            am.Add(new MenuItem("Ukončit program", new Action(() => { exitam = true; })));

            while (!exitam)
            {
                var item = am.Execute();
                item.Execute();
            }
            return am;
            
        }
        


        private bool exitbm = false;
        private Menu bankMenu()
        {

            Menu bm = new Menu("Vyberte možnost: ");
            BankRowGateway bank = new BankRowGateway();

            bm.Add(new MenuItem("Vyhledat banku podle Id ",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište Id banky, kterou si přejete vidět.");
                    int id = Convert.ToInt32(System.Console.ReadLine());
                    try
                    {
                        Bank wantedBank = bank.GetByID(id);
                        System.Console.WriteLine(wantedBank.ToString());
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));


            bm.Add(new MenuItem("Nová banka",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište informace o nové bance v pořadí id, jméno banky, kod banky a IČO \n přesně v tomto pořadí.");
                    try
                    {
                        Bank newBank = new Bank(Convert.ToInt32(System.Console.ReadLine()), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine());
                        bank.InsertInto(newBank);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));

            bm.Add(new MenuItem("Upravení typu účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište  id, jméno typu účtu a nový úrok, který s k typu účtu přejete přiřadit.");
                    try
                    {
                        Bank upBank = new Bank(Convert.ToInt32(System.Console.ReadLine()), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine());
                        bank.UpdateByID(upBank);
                        System.Console.WriteLine("Data uložena.");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                })));


            bm.Add(new MenuItem("Smazání typu účtu",
                new Action(() =>
                {
                    System.Console.WriteLine("Napište údaje o účtu v tomto pořadí: id, číslo účtu.");
                    try
                    {
                        Bank delBank = new Bank(Convert.ToInt32(System.Console.ReadLine()), System.Console.ReadLine(), System.Console.ReadLine(), System.Console.ReadLine());
                        bank.InsertInto(delBank);
                        System.Console.WriteLine("Typ účtu smazán");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                })));
            bm.Add(new MenuItem("Ukončit program", new Action(() => { exitbm = true; })));

            while (!exitbm)
            {
                var item = bm.Execute();
                item.Execute();
            }

            return bm;
        }
        

    }
}
