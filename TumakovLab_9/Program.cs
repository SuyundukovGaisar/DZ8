using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнения 9.1 - 9.3(Удалить методы заполнения полей. Вместо этих методов создать конструкторы.Создать новый класс BankTransaction.В классе банковский счет создать метод Dispose.)");
            Account BankAccount = new Account(15000, AccountType.Saving);
            BankAccount.Print();
            Account BankAccount1 = new Account();
            BankAccount1.PrintNewBalance();
            Account account1 = new Account(10000, AccountType.Current);
            Account account2 = new Account(5000, AccountType.Saving);
            decimal amountToTransfer = 1000;
            account1.TransferMoney(account2, amountToTransfer);

            Console.WriteLine("Домашнее задание 9.1(В класс Song добавить конструкторы c 2 параметрами и 3 параметрами. Также исправить ошибку)");
            List<Song> songs = new List<Song>();
            Song song1 = new Song();
            song1.SetName("Save Your Tears");
            song1.SetAuthor("The Weeknd");
            songs.Add(song1);

            Song song2 = new Song();
            song2.SetName("Blinding Lights");
            song2.SetAuthor("The Weeknd");
            song2.SetPrev(song1);
            songs.Add(song2);

            Song song3 = new Song();
            song3.SetName("Режиссер");
            song3.SetAuthor("Градусы");
            song3.SetPrev(song2);
            songs.Add(song3);

            Song song4 = new Song();
            song4.SetName("До скорой встречи");
            song4.SetAuthor("Звери");
            song4.SetPrev(song3);
            songs.Add(song4);

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
                Console.WriteLine();
            }

            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песня совпадают");
            }
            else
            {
                Console.WriteLine("Первая и вторая песня разные");
            }
            Song mySong = new Song("Группа Крови", "Кино");
        }
    }
}
