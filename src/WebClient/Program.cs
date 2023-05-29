using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace WebClient
{
    class Program
    {
         static void Main(string[] args)
        {
            // Принимает с консоли ID "Клиента"

            Console.WriteLine("Введите Id");
            int Id;
            bool parce = int.TryParse(Console.ReadLine(), out Id);

            using (var client = new HttpClient())
            {

                // запрашивает его с сервера

                var response = client.GetAsync("https://localhost:5001/customers/" + Id).Result;

                var result = response.Content.ReadAsStringAsync().Result;


                // и отображает его данные по пользователю;
                Console.WriteLine("Пользователь с запрошенным ID");
                Console.WriteLine(response.StatusCode + "   " + result);

            };

            // Генерирует случайным образом данные для создания нового "Клиента" на сервере;

            Random rand = new Random();

            int IdRandom = rand.Next(1, 100);

            int Namelen = rand.Next(3, 7);
            string FirstNameRandom = "";

            for (int i = 0; i < Namelen; i++)
            {

                // Generating a random number.
                int randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                char letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
               FirstNameRandom = FirstNameRandom + letter;
            }

            int Lastlen = rand.Next(5, 9);
            string LastNameRandom = "";

            for (int i = 0; i < Lastlen; i++)
            {

                // Generating a random number.
                int randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                char letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                LastNameRandom = LastNameRandom + letter;
            }
            Console.WriteLine("Создан случайный Пользователь");
            Console.WriteLine("Random ID   " + IdRandom);
            Console.WriteLine("Random FirstName  " + FirstNameRandom);
            Console.WriteLine("Random LastName  " + LastNameRandom);

            Customer NewRandomCustomer = new Customer { Id = IdRandom, Firstname = FirstNameRandom, Lastname = LastNameRandom };

            using (var client = new HttpClient())
            {

                // Отправляет данные, созданные в пункте 2.2., на сервер;

                var response = client.PostAsJsonAsync("https://localhost:5001/customers/", NewRandomCustomer).Result;

                //var result = response.Content.ReadAsStringAsync().Result;

                // По полученному ID от сервера запросить созданного пользователя с сервера 
                var responseGet = client.GetAsync("https://localhost:5001/customers/" + IdRandom).Result;

                var result = responseGet.Content.ReadAsStringAsync().Result;



                // и вывести на экран.
                Console.WriteLine("Был создан пользователь");
                Console.WriteLine(response.StatusCode + "   " + result);

            };

            Console.ReadKey();

        }

    }

}
