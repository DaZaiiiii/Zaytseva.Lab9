using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

var path = "Collection.csv";

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding encoding = Encoding.GetEncoding(1251);

var lines = File.ReadAllLines(path, encoding);
var informations = new Class[lines.Length - 1];

for (int i = 1; i < lines.Length; i++)
{
    var splits = lines[i].Split(';');
    var information = new Class();
    information.Id = Convert.ToInt32(splits[0]);
    information.Name = splits[1];
    information.Email = splits[2];
    information.Phone = splits[3];
    information.Age = Convert.ToInt32(splits[4]);
    information.City = splits[5];
    information.Street = splits[6];
    information.Tag = splits[7];
    information.Price = Convert.ToInt32(splits[8]);
    information.CustomerId = splits[9];
    information.ProductId = splits[10];

    informations[i - 1] = information;
}

//Задание 1
Console.WriteLine("Задание 1");

int City = 0;

if (City == informations.Length) Console.WriteLine("Записи по свойству City не уникальны");

for (var i = 0; i < informations.Length; i++)
{
    int k = informations.Count(a => a.Phone == informations[i].Phone);
    if (k != City)
    {
        Console.WriteLine("Записи по свойству City уникальны");
        break;
    }
    City++;
}

Console.WriteLine();

//Задание 2
Console.WriteLine("Задание 2");
Console.WriteLine("Средний возраст покупателей: " + informations.Average(x => x.Age));
Console.WriteLine();

//Задание 3
Console.WriteLine("Задание 3");
var sorted = from x in informations
             orderby x.Email descending
             select x;

var result = "resultsortedemail.csv";

using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

    foreach (var a in sorted)
    {
        streamWriter.WriteLine(a.ToExcel());
    }
    foreach (Class person in sorted)
        Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
}
Console.WriteLine();
Console.WriteLine();

//Задание 4
Console.WriteLine("Задание 4");
var selectedcity = from price in informations
                   where price.Price > 2000
                   select price;

var result1 = "resultprice.csv";
using (StreamWriter streamWriter = new StreamWriter(result1, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

    foreach (var gorod in selectedcity)
    {
        streamWriter.WriteLine(gorod.ToExcel());
    }
    foreach (Class person in selectedcity)
        Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
}
Console.WriteLine();
Console.WriteLine();

//Задание 5
char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'e', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'm', 'N', 'O', 'P', 'Q', 'r', 'S', 'T', 'U', 'v', 'W', 'X', 'Y', 'z' };
string[] emails = { "NyuhayBebru@mail.ru", "YaDeadOutsider@gmail.com", "Devil666@mail.ru", "SobakinaKakashka@gmail.com", "YaDiankka!@yandex.ru", "0g0YaUmnaya@gmail.com", "YaLubluLOL@mail.ru", "NenavizhuLOL@gmail.com", "Hesusechek@gmail.com" };
string[] names = { "Прокофья Солнцелюбова", "Доборыня Ильич", "Осип Карлов", "Пётр Первый", "Наталья сидорова", "Оливер Три", "Артём Психолов", "Кирилл Рыготин", "Вероника Вульвова", "Флома Рисова" };
string[] cities = { "Нью-Йорк", "Саранск", "Майями", "Барселона", "Осло", "Амстердам", "Кейптаун", "", "Гуанчжоу", "Дели", "Краснодар","Сингапур" };
string[] phones = { "(741)465-59-91", "(900)797-56-85", "(983)637-71-24", "(954)093-64-44", "(200)576-89-22", "(593)273-01-91", "(814)393-72-48", "(025)851-00-60", "(221)335-45-39", "(699)132-43-83" };
string[] streets = { "Ломбард Стрит", "Орчард-роуд", "Улина Красных", "Невская", "Красная улица", "Дворцовая площадь", "Тверская улица", "Улица Лузана", "Улица Дзержинского" };
string[] tags = { "Монитор", "Мышка", "Коврик", "Процессоры", "Микрофон", "Наушники", "Куллеры", "Клавиатура", "Колонки", "Графический планшет", "Кресло", "Шавбра" };
string[] ages = { "18", "21", "45", "25", "34", "20", "41", "49", "19", "51", "43", "27", "43", "37", "49" };
var customId = new List<string>();
var productID = new List<string>();
Random random = new Random();
 
for (int j = 0; j < 10; j++)
{
    string str = "";
    for (int i = 0; i < 10; i++)
    {
        var newstr = symbols[random.Next(0, symbols.Length)];
        str += newstr;
    }
    customId.Add(str);
}

for (int g = 0; g < 10; g++)
{
    string stri = "";
    for (int o = 0; o < 10; o++)
    {
        var newstri = symbols[random.Next(0, symbols.Length)];
        stri += newstri;
    }
    productID.Add(stri);
}
var result2 = "result.csv";

using (var writer = new StreamWriter(result2, true, encoding))

{

    for (int l = informations.Length + 1; l < informations.Length + 10; l++)
    {
        var NewRecord = new List<Class>()
                    {
                      new Class { Id = l, Name = names[random.Next(0, names.Length)], Email = emails[random.Next(0, emails.Length)], Phone = phones[random.Next(0, phones.Length)], Age = random.Next(0, ages.Length), City = cities[random.Next(0, cities.Length)], Street = streets[random.Next(0, streets.Length)], Tag = tags[random.Next(0, tags.Length)], Price = random.Next(200, 40000), CustomerId = customId[random.Next(0, customId.Count)], ProductId = productID[random.Next(0, productID.Count)] }
                    };
        foreach (var n in NewRecord)
        {
            writer.WriteLine(n.ToExcel());
        }
    }
}




public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\n Имя и фамилия: {Name}\n Электронный адрес : {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Тэг:{Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n ";
    }
    public string ToExcel()
    {
        return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";
    }
}