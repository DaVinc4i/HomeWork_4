using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HomeWork; //добавление библиотеки (пространства HomeWork) из второй домашней работы

namespace HomeWork_4
{
    // 2. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
    // Создайте структуру Account, содержащую Login и Password.

    // решение предоставил Юрченко Н.А.

    class Task2
    {
        struct Account
        {
            private string login;
            private string password;

            private static List<Account> accounts;

            public Account(string login, string password)
            {
                this.login = login;
                this.password = password;
            }
            private static bool LoadAccountsFromFile()
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "UsersData.txt";

                accounts = new List<Account>();

                if (File.Exists(fileName))
                {
                    StreamReader reader = new StreamReader(fileName);

                    while (!reader.EndOfStream)
                    {
                        string login = reader.ReadLine();
                        if (reader.EndOfStream)
                        {
                            Console.WriteLine("В файле не содержиться пароля к единственному логину...");
                            break;
                        }
                        string password = reader.ReadLine();
                        accounts.Add(new Account(login, password));
                    }
                    if (accounts.Count == 0)
                    {
                        Console.WriteLine("В файле нет данных аккаунта или пароля...\n");
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    Console.WriteLine("Файла с данными пользователей не существует в данной директории");
                    return false;
                }
            }
            private static bool IsCorrectData(string login, string password)
            {
                foreach (Account account in accounts)
                {
                    if (account.login == login && account.password == password)
                    {
                        Console.WriteLine("Вам удалось авторизоваться!\n");
                        return true;
                    }
                }
                return false;
            }
            public static bool Authorization()
            {
                if (accounts == null || accounts?.Count == 0)
                {
                    if (!LoadAccountsFromFile())
                        return false;
                }

                Console.WriteLine("Введите логин и пароль для входа в аккаунт...");
                int attempts = 3;
                do
                {
                    Console.Write("Введите логин:\t");
                    string login = Console.ReadLine();
                    Console.Write("Введите пароль:\t");
                    string password = Console.ReadLine();

                    if (IsCorrectData(login, password))                  
                        return true;                    
                    else
                    {
                        Console.WriteLine("Вы ввели неверный логин или пароль!");
                        Console.WriteLine("У Вас осталось {0} попыток.\n", --attempts);
                    }
                } 
                while (attempts > 0);

                Console.WriteLine("Попытки исчерпаны. Вам не удалось авторизоваться!\n");
                return false;
            }
        }

        static void Main(string[] args)
        {
            var screen = new Screen();
            screen.ScreenPrint(4, 2);
            // Вызов метода ScreenPrint cо второй домашней работы, для вывода номера задания 
            // и домашней работы, а также вывода ФИО выполнившего студента

            if (Account.Authorization())           
                Console.WriteLine("Поздравляем Вы вошли в приложение!\n");                
           
            Console.WriteLine("Для завершения нажмите любую клавишу");

            Console.ReadLine();
        }
    }
}
