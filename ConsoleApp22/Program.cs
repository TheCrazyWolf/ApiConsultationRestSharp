using ConsoleApp22.Api;
using ConsoleApp22.Models;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        //a7b25d781e794003b3e4e1e43fa34ded
        Console.WriteLine("Hello, World!");

        Goods goods = new Goods()
        {
            IdGood = Guid.NewGuid(),
            Name = "Стол",
            Price = 4350
        };

        /*Создание написаного собственного контроллера для API 
         и указываем адрес сервера
         */
        Catalog catalog = new Catalog("http://192.168.50.194:8080");

        /* выполняем запрос с помощью нашего контроллера и передаем данные */
        var result = catalog
            .AddGoods("a7b25d781e794003b3e4e1e43fa34ded", goods);

        /* проверяем результат запроса, успешные или нет
         выполняем нужные действия
         */
        if (result.IsSuccessStatusCode)
        {
            Console.WriteLine("Товар добавлен!");
        }

        var listGoods = catalog.GetGoods("a7b25d781e794003b3e4e1e43fa34ded");

        if (listGoods.IsSuccessStatusCode)
        {
            List<Goods> list = JsonConvert
                .DeserializeObject<List<Goods>>(listGoods.Content);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} - {item.Price} рублей");
            }
        }
        else if(listGoods.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("Срок действия истек или неверный");
        }


        var resulDelete = catalog.DeleteGoods("a7b25d781e794003b3e4e1e43fa34ded",
            "3fa85f64-5717-4062-b3fc-2c963f66afa6"
            );

        if (resulDelete.IsSuccessStatusCode)
        {
            Console.WriteLine("Товар удален");
        }
        else if (resulDelete.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("Срок действия истек или неверный");
        }
        else if (resulDelete.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Товар для удаления не найден");
        }

    }
}