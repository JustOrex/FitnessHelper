
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using Client;


namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {


            ConsoleKey num; //1

            string name; // 2

            string email; // 3

            string password; // 4

            string gender; // 5

            string typeOfDiet; // 6

            string typeOfTraining; // 7

            double height; // 8

            double weight; // 9

            double activityRate; // a

            double basicCalories;

            int age; // b

            string codeOfRegANDAuth;






            using TcpClient tcpClient = new TcpClient("192.168.0.102", 8080);
            using Connection connection = new Connection(tcpClient);



            Console.WriteLine("Здравствуйте! Вас прветствует FitnessHelper.");


            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Выберите действие, написав номер действия:");
                    Console.WriteLine("1.Регистрация");
                    Console.WriteLine("2.Вход");

                    num = Console.ReadKey().Key;

                    string typeOfTask;


                    if (num == ConsoleKey.D1)
                    {
                        typeOfTask = "registration";
                        await connection.SendMessageAsync(typeOfTask + '1');

                        break;

                    }
                    if (num == ConsoleKey.D2)
                    {
                        typeOfTask = "authorization";

                        await connection.SendMessageAsync(typeOfTask + '1');

                        break;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Некооректные данные! Попробуйте снова.");
                        Thread.Sleep(1000);
                        Console.Clear();

                        continue;
                    }
                }
                   
                   
                
                while (true)
                {
                     
                    if (num == ConsoleKey.D1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Введите ваше имя");

                                name = Console.ReadLine();

                                if (String.IsNullOrWhiteSpace(name))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    await connection.SendMessageAsync(name + '2');
                                    while (connection.answer == null) { }
                                    string ckeck = connection.answer;
                                    if(ckeck == "false")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Аккаунт с таким именем уже существует! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                    }
                                    
                                    break;
                                }
                            }
                            Console.Clear();


                            while (true)
                            {
                                Console.WriteLine("Введите вашу почту");

                                email = Console.ReadLine();

                                if (String.IsNullOrWhiteSpace(email))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                     
                                    await connection.SendMessageAsync(email + '3');
                                    while (connection.answer == null) { }
                                    string check = connection.answer;
                                    if (check == "false")
                                    {

                                        
                                        Console.Clear();
                                        Console.WriteLine("Неверно введена почта или аккаунт с такой почтой уже существует! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                    }
                                    
                                    
                                }
                                
                                Console.Clear();
                                
                                while (true)
                                {
                                    Console.WriteLine("Для продолжения введите код регистрации, отправленый вам на почту.");
                                    Console.WriteLine("1. Изменить введённую почту.");

                                    codeOfRegANDAuth = Console.ReadLine();

                                    if (String.IsNullOrWhiteSpace(codeOfRegANDAuth))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                    }
                                    else if (codeOfRegANDAuth == "1")
                                    {
                                        Console.Clear();
                                        break;
                                       
                                    }
                                    else
                                    {

                                         
                                        await connection.SendMessageAsync(codeOfRegANDAuth + 'c');
                                        while (connection.answer == null) { }
                                        string check = connection.answer;
                                        
                                        if (check == "false")
                                        {
                                            
                                            Console.Clear();
                                            Console.WriteLine("Неверный код! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }

                                        goto Flag;
                                    }

                                    
                                    
                                }
                                
                            }
                            

                            Flag:
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Придумайте пароль");

                                password = Console.ReadLine();

                                if (String.IsNullOrWhiteSpace(password))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                     
                                    await connection.SendMessageAsync(password + '4');
                                    break;
                                }
                            }
                            Console.Clear();



                            while (true)
                            {
                                Console.WriteLine("Укажите ваш рост");

                                var h = Console.ReadLine();

                                if (double.TryParse(h, out height))
                                {

                                     
                                    await connection.SendMessageAsync(height.ToString() + '8');
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                            }

                            Console.Clear();


                            while (true)
                            {
                                Console.WriteLine("Укажите ваш вес");

                                var w = Console.ReadLine();

                                if (double.TryParse(w, out weight))
                                {
                                     
                                    await connection.SendMessageAsync(weight.ToString() + '9');
                                    
                                     
                                    await connection.SendMessageAsync(DateTime.Now.ToShortDateString()+'0');
                                   
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                            }
                            Console.Clear();



                            while (true)
                            {
                                Console.WriteLine("Выбирете тип вашей активности");
                                Console.WriteLine("1. Минимальный уровень нагрузки  (сидячая работа, отсутствие спорта) \n 2. Сегкий уровень активности (легкие упражнения, зарядка, пешие прогулки) \n 3. Cредняя активность (спорт до 5 раз за неделю) \n 4. Активность высокого уровня (активный образ жизни вкупе с ежедневными интенсивными тренировками) \n 5. Экстремально высокая активность (спортивный образ жизни, тяжелый физический труд, длительные тяжелые тренировки каждый день).");

                                var ar = Console.ReadKey().Key;


                                if (ar == ConsoleKey.D1)
                                {
                                    activityRate = 1.1;
                                }
                                else if (ar == ConsoleKey.D2)
                                {
                                    activityRate = 1.2;
                                }
                                else if (ar == ConsoleKey.D3)
                                {
                                    activityRate = 1.4;
                                }
                                else if (ar == ConsoleKey.D4)
                                {
                                    activityRate = 1.7;
                                }
                                else if (ar == ConsoleKey.D5)
                                {
                                    activityRate = 1.9;
                                }
                                else
                                {
                          
                                    Console.Clear();
                                    continue;
                                }
                                 
                                await connection.SendMessageAsync(activityRate.ToString() + 'a');
                                break;
                                
                            }
                            Console.Clear();


                            while (true)
                            {
                                Console.WriteLine("Введите ваш возраст");

                                var answ = Console.ReadLine();

                                if (int.TryParse(answ, out age))
                                {
                                     
                                    await connection.SendMessageAsync(age.ToString() + 'b');
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                            }
                            Console.Clear();


                            while (true)
                            {
                                Console.WriteLine("Укажите ваш пол");
                                Console.WriteLine("1. Мужской \n 2. Женский");

                                var answ = Console.ReadKey().Key;


                                if (answ == ConsoleKey.D1)
                                {
                                    gender = "man";
                          
                                }

                                else if (answ == ConsoleKey.D2)
                                {
                                    gender = "women";                               
                                }

                                else
                                {
                                    
                                    Console.Clear();
                                    continue;
                                }
                                await connection.SendMessageAsync(gender + "5");                              
                                break;

                            }
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Что вы хотите?");
                                Console.WriteLine("1. Набрать вес \n 2. Похудеть \n 3. Поддерживать вес");

                                var answ = Console.ReadKey().Key;

                                if (answ == ConsoleKey.D1)
                                {
                                    typeOfDiet = "Bulk";

                                     
                                    await connection.SendMessageAsync(typeOfDiet + "6");
                                    Console.Clear();
                                    break;
                                }

                                else if (answ == ConsoleKey.D2)
                                {
                                    typeOfDiet = "Cut";

                                     
                                    await connection.SendMessageAsync(typeOfDiet + "6");
                                    Console.Clear();
                                    break;
                                }

                                else if (answ == ConsoleKey.D3)
                                {
                                    typeOfDiet = "KeepBodyWheight";

                                     
                                    await connection.SendMessageAsync(typeOfDiet + "6");
                                    Console.Clear();
                                    break;
                                }

                                else
                                {
                                    Console.Clear();
                                    continue;
                                }
                            }
                            Console.Clear();

                            while (true)
                            {
                                Console.WriteLine("Какой тип тренировки вы хотите выбрать?");
                                Console.WriteLine("1. Сплит (Тренировки разбиты по группам мыщц, минимум 3 тренировки в неделю) \n 2. Фулбади (На каждой тренировке работают все группы мышцю. Подходит для тех у кого мало времени. Минимум 1 тренировка в неделю)");

                                var answ = Console.ReadKey().Key;

                                if (answ == ConsoleKey.D1)
                                {
                                    typeOfTraining = "split";
                                }
                                else if (answ == ConsoleKey.D2)
                                {
                                    typeOfTraining = "fullbody";                             
                                }
                                else
                                {
                                    Console.Clear();
                                    continue;
                                }

                                 
                                await connection.SendMessageAsync(typeOfTraining + "7");
                                break;
                            }
                            Console.Clear();

                             
                            await connection.SendMessageAsync("createAccount#");

                            Console.WriteLine("Вы зарегистрированы!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto flag2;
                        }


                        
                    }
                    else
                    {
                        Console.Clear();
                        
                            while (true)
                            {
                                
                                while (true)
                                {
                                    Console.WriteLine("Введите имя");
                                    var answ = Console.ReadLine();

                                    if (String.IsNullOrWhiteSpace(answ))
                                    {
                                        
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                    }
                                    else
                                    {
                                        name = answ;

                                         
                                        await connection.SendMessageAsync(name + '2');

                                        while(connection.answer == null) { }
                                        
                                        string check = connection.answer;
                                        if (check == "false")
                                        {
                                            
                                        Console.Clear();
                                        Console.WriteLine("Аккаунта с таким именем не существует! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                        }
                                        break;
                                    }

                                }
                                Console.Clear();


                                while (true)
                                {
                                    Console.WriteLine("Введите почту");
                                    var answ = Console.ReadLine();

                                    if (String.IsNullOrWhiteSpace(answ))
                                    {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                    }
                                    else
                                    {
                                        email = answ;
                                         
                                        await connection.SendMessageAsync(email + '3');

                                        while (connection.answer == null) { }
                                        string check = connection.answer;

                                        if (check == "false")
                                        {
                                            
                                        Console.Clear();
                                        Console.WriteLine("Неверно введена почта! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                        }
                                        break;
                                    }
                                }
                                Console.Clear();


                                while (true)
                                {
                                    Console.WriteLine("Введите пароль");
                                    var answ = Console.ReadLine();

                                    if (String.IsNullOrWhiteSpace(answ))
                                    {
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                    }
                                    else
                                    {
                                        password = answ;
                                         
                                        await connection.SendMessageAsync(password + '4');

                                        while (connection.answer == null) { }
                                        string check = connection.answer;

                                        if (check == "false")
                                        {
                                           
                                        Console.Clear();
                                        Console.WriteLine("Неверно введён пароль! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                        }
                                        break;
                                    }
                                }
                                Console.Clear();

                                while (true)
                                {
                                    Console.WriteLine("Для завершения введите код авторизации, отправленый вам на почту");
                                    Console.WriteLine("1.Ввести данныые повторно");

                                    codeOfRegANDAuth = Console.ReadLine();

                                    if (String.IsNullOrWhiteSpace(codeOfRegANDAuth))
                                    {
                                        
                                    Console.Clear();
                                    Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                    }
                                    else if (codeOfRegANDAuth == "1")
                                    {
                                        break;
                                    }
                                    else
                                    {

                                         
                                        await connection.SendMessageAsync(codeOfRegANDAuth + 'c');

                                        while (connection.answer == null) { }

                                        string check = connection.answer;

                                        if (check == "false")
                                        {
                                           
                                        Console.Clear();
                                        Console.WriteLine("Неверный код! Попробуйте снова.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        continue;
                                        }
                                        goto flag2;
                                    }


                                }
                                Console.Clear();

                                


                            }     
                        
                    }

                    flag2:
                    
                    Console.Clear();
                    Console.WriteLine($"Добро пожаловать {name}");

                    await connection.RequestForData();

                   

                    while(connection.user == null) { }
                    User user = connection.user;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(name);




                        Console.WriteLine("\n"+ "1.Мои данные");
                        Console.WriteLine("2.Программа тренировок");
                        Console.WriteLine("3.Мои изменения");
                        Console.WriteLine("\n" + "4.Выход");

                        var click = Console.ReadKey().Key;

                        if (click == ConsoleKey.D1)
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("1." + user.Name + " -имя профиля");
                                Console.WriteLine("2." + user.Email + " -почта");
                                Console.WriteLine("3. Пароль");
                                Console.WriteLine("4." + user.height + " -рост");

                                string sex;

                                if (user.gender == "man")
                                {
                                    sex = "мужчина";
                                }
                                else
                                {
                                    sex = "женщина";
                                }

                                Console.WriteLine("5." + sex);
                                Console.WriteLine("6." + user.age + "лет -возраст");

                                string aR;

                                if (user.activityRate == 1.1)
                                {
                                    aR = "Минимальный уровень нагрузки  (сидячая работа, отсутствие спорта)";
                                }
                                else if (user.activityRate == 1.2)
                                {
                                    aR = "Сегкий уровень активности (легкие упражнения, зарядка, пешие прогулки)";
                                }
                                else if (user.activityRate == 1.4)
                                {
                                    aR = "Cредняя активность (спорт до 5 раз за неделю)";
                                }
                                else if (user.activityRate == 1.7)
                                {
                                    aR = "Активность высокого уровня (активный образ жизни вкупе с ежедневными интенсивными тренировками)";
                                }
                                else
                                {
                                    aR = "Экстремально высокая активность (спортивный образ жизни, тяжелый физический труд, длительные тяжелые тренировки каждый день)";
                                }
                                Console.WriteLine("7." + aR);

                                string tod;

                                if (user.typeOfDiet == "Cut")
                                {
                                    tod = "похудение";
                                }
                                else if (user.typeOfDiet == "Bulk")
                                {
                                    tod = "набор веса";
                                }
                                else
                                {
                                    tod = "удержание веса";
                                }
                                Console.WriteLine("8." + tod);

                                double Kc;

                                if (user.typeOfDiet == "Cut")
                                {
                                    Kc = user.basicCalories / 100 * 65;
                                }
                                else if (user.typeOfDiet == "Bulk")
                                {
                                    Kc = user.basicCalories + 300;
                                }
                                else
                                {
                                    Kc = user.basicCalories;
                                }
                                Console.WriteLine(Kc + " -дневная норма каллорий");
                                Console.WriteLine("\n" + "9.Назад");

                                var click1 = Console.ReadKey().Key;

                                if (click1 == ConsoleKey.D9)
                                {
                                    Console.Clear();
                                    break;
                                }

                                if (click1 == ConsoleKey.D1)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Введите новое имя"); 

                                        name = Console.ReadLine();

                                        if (String.IsNullOrWhiteSpace(name))
                                        {
                                            
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                        else
                                        {

                                            await connection.SendMessageAsync(name + "2!");
                                            while (connection.answer == null) { }
                                            string check = connection.answer;
                                            if (check == "false")
                                            {
                                                
                                                Console.Clear();
                                                Console.WriteLine("Аккаунт с таким именем уже существует! Попробуйте снова.");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                continue;
                                            }
                                            Console.Clear();

                                            await connection.RequestForData();
                                            while(connection.user == null) { }
                                            user = connection.user;

                                            break;
                                        }
                                    }



                                }
                                if (click1 == ConsoleKey.D2)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Для того чтобы отвязать почту введите пароль");

                                        password = Console.ReadLine();

                                        if (String.IsNullOrWhiteSpace(password))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                        else
                                        {

                                            if (password != user.Password)
                                            {
                                                
                                                Console.Clear();
                                                Console.WriteLine("Неверный пароль! Попробуйте снова.");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                continue;
                                            }

                                            Console.Clear();


                                        }


                                        while (true)
                                        {
                                            Console.WriteLine("Введите новую почту");

                                            email = Console.ReadLine();

                                            if (String.IsNullOrWhiteSpace(email))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                continue;
                                            }
                                            else
                                            {

                                                await connection.SendMessageAsync(email + "3!");
                                                while (connection.answer == null) { }
                                                string check = connection.answer;
                                                if (check == "false")
                                                {
                                                    
                                                    Console.Clear();
                                                    Console.WriteLine("Неверно введена почта или аккаунт с такой почтой уже существует! Попробуйте снова.");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                    continue;
                                                }
                                                Console.Clear();


                                                while (true)
                                                {
                                                    Console.WriteLine("Введите код, отправленный на новую почту!");
                                                    Console.WriteLine("1.Повторно ввести почту");

                                                    codeOfRegANDAuth = Console.ReadLine();

                                                    if (String.IsNullOrWhiteSpace(codeOfRegANDAuth))
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        continue;
                                                    }
                                                    else if (codeOfRegANDAuth == "1")
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                    else
                                                    {


                                                        await connection.SendMessageAsync(codeOfRegANDAuth + "c!");
                                                        while (connection.answer == null) { }
                                                        check = connection.answer;

                                                        if (check == "false")
                                                        {
                                                            
                                                            Console.Clear();
                                                            Console.WriteLine("Неверный код! Попробуйте снова.");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            continue;
                                                        }

                                                        Console.Clear();

                                                        await connection.RequestForData();
                                                        while(connection.user == null) { }
                                                        user = connection.user;

                                                        goto flag3;

                                                    }


                                                }
                                               

                                               

                                            }


                                        }
                                    flag3: break;
                                    }

                                    
                                }
                                if (click1 == ConsoleKey.D3)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Сначала введите старый пароль");

                                        var answ = Console.ReadLine();

                                        if (String.IsNullOrWhiteSpace(answ))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                        else
                                        {

                                            if (answ != password)
                                            {
                                                
                                                Console.Clear();
                                                Console.WriteLine("Неверно введён пароль! Попробуйте снова.");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                continue;
                                            }
                                            Console.Clear();

                                        }

                                        Console.WriteLine("Введите новый пароль");

                                        password = Console.ReadLine();

                                        if (String.IsNullOrWhiteSpace(password))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                        else
                                        {
                                            await connection.SendMessageAsync(password + "4!");

                                            Console.WriteLine("Пароль успешно сохранён!");
                                            Thread.Sleep(1000);
                                            Console.Clear();

                                            await connection.RequestForData();
                                            while(connection.user == null) { }
                                            user = connection.user;
                                            break;
                                        }
                                    }

                                }
                                if (click1 == ConsoleKey.D4)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Введите новый рост");

                                        var h = Console.ReadLine();

                                        if (double.TryParse(h, out height))
                                        {

                                            await connection.SendMessageAsync(height.ToString() + "8!");
                                            Console.Clear();

                                            await connection.RequestForData();
                                            while(connection.user == null) { }
                                            user = connection.user;
                                           
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                    }

                                }
                                if (click1 == ConsoleKey.D5)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Укажите пол");
                                        Console.WriteLine("1. Мужской \n 2. Женский");

                                        var answ = Console.ReadKey().Key;


                                        if (answ == ConsoleKey.D1)
                                        {
                                            gender = "man";
                                        }

                                        else if (answ == ConsoleKey.D2)
                                        {
                                            gender = "women";
                                        }

                                        else
                                        {
                                            Console.Clear();
                                            continue;
                                        }

                                        await connection.SendMessageAsync(gender + "5!");
                                        Console.Clear();

                                        await connection.RequestForData();
                                        while(connection.user == null) { }
                                        user = connection.user;

                                        break;
                                    }

                                }
                                if (click1 == ConsoleKey.D6)
                                {
                                    Console.Clear();
                                    while (true)
                                    {

                                        Console.WriteLine("Укажите возраст");

                                        var answ = Console.ReadLine();

                                        if (int.TryParse(answ, out age))
                                        {

                                            await connection.SendMessageAsync(age.ToString() + "b!");
                                            Console.Clear();

                                            await connection.RequestForData();
                                            while(connection.user == null) { }
                                            user = connection.user;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                    }

                                }
                                if (click1 == ConsoleKey.D7)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.WriteLine("Выбирете новый тип активности");
                                        Console.WriteLine("1. Минимальный уровень нагрузки  (сидячая работа, отсутствие спорта) \n 2. Сегкий уровень активности (легкие упражнения, зарядка, пешие прогулки) \n 3. Cредняя активность (спорт до 5 раз за неделю) \n 4. Активность высокого уровня (активный образ жизни вкупе с ежедневными интенсивными тренировками) \n 5. Экстремально высокая активность (спортивный образ жизни, тяжелый физический труд, длительные тяжелые тренировки каждый день).");

                                        var ar = Console.ReadKey().Key;


                                        if (ar == ConsoleKey.D1)
                                        {
                                            activityRate = 1.1;
                                        }
                                        else if (ar == ConsoleKey.D2)
                                        {
                                            activityRate = 1.2;
                                        }
                                        else if (ar == ConsoleKey.D3)
                                        {
                                            activityRate = 1.4;
                                        }
                                        else if (ar == ConsoleKey.D4)
                                        {
                                            activityRate = 1.7;
                                        }
                                        else if (ar == ConsoleKey.D5)
                                        {
                                            activityRate = 1.9;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            continue;
                                        }

                                        await connection.SendMessageAsync(activityRate.ToString() + "a!");
                                        Console.Clear();

                                        await connection.RequestForData();
                                        while(connection.user == null) { }
                                        user = connection.user;
                                        break;


                                    }

                                }
                                if (click1 == ConsoleKey.D8)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.WriteLine("Что вы хотите?");
                                        Console.WriteLine("1. Набрать вес \n 2. Похудеть \n 3. Поддерживать вес");

                                        var answ = Console.ReadKey().Key;


                                        if (answ == ConsoleKey.D1)
                                        {
                                            typeOfDiet = "Bulk";
                                        }

                                        else if (answ == ConsoleKey.D2)
                                        {
                                            typeOfDiet = "Cut";
                                        }

                                        else if (answ == ConsoleKey.D3)
                                        {
                                            typeOfDiet = "KeepBodyWheight";
                                        }

                                        else
                                        { 
                                            Console.Clear();
                                            continue;
                                        }

                                        await connection.SendMessageAsync(typeOfDiet + "6!");
                                        Console.Clear();

                                        await connection.RequestForData();
                                        while(connection.user == null) { }
                                        user = connection.user;
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    continue;
                                }
                            }

                        }
                        else if(click == ConsoleKey.D2)
                        {
                            while (true)
                            {
                                Console.Clear();
                                string tp = Encoding.Unicode.GetString(user.FileWithTrainingProgrammData);
                                Console.WriteLine(tp);
                                Console.WriteLine("\n" + "1.Изменить");
                                Console.WriteLine("\n" + "2.Назад");

                                var click1 = Console.ReadKey().Key;
                                if (click1 == ConsoleKey.D1)
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Какой тип тренировки вы хотите выбрать?");
                                        Console.WriteLine("1. Сплит (Тренировки разбиты по группам мыщц, минимум 3 тренировки в неделю) \n 2. Фулбади (На каждой тренировке работают все группы мышцю. Подходит для тех у кого мало времени. Минимум 1 тренировка в неделю)");

                                        var click2 = Console.ReadKey().Key;

                                        if (click2 == ConsoleKey.D1)
                                        {
                                            typeOfTraining = "split";

                                        }
                                        else if (click2 == ConsoleKey.D2)
                                        {
                                            typeOfTraining = "fullbody";

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            continue;
                                        }

                                        await connection.SendMessageAsync(typeOfTraining + "7!");

                                        await connection.RequestForData();

                                        while(connection.user == null) { }

                                        user = connection.user;
                                        break;
                                    }

                                }
                                else if (click1 == ConsoleKey.D2)
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            continue;
                        }
                        else if (click == ConsoleKey.D3)
                        {
                            while (true)
                            {
                                Console.Clear();


                                Console.WriteLine("1.Добавить изменение веса");
                                Console.WriteLine("\n" + "2.Выход");

                                Console.WriteLine("\n" + Encoding.Unicode.GetString(user.WheightChanges));
                                var click2 = Console.ReadKey().Key;

                                if (click2 == ConsoleKey.D1)
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Укажите ваш новый вес");

                                        var w = Console.ReadLine();

                                        if (double.TryParse(w, out weight))
                                        {

                                            await connection.SendMessageAsync(weight.ToString() + "9!");


                                            await connection.SendMessageAsync(DateTime.Now.ToShortDateString() + "0!");


                                            await connection.RequestForData();

                                            while(connection.user == null) { }

                                            user = connection.user;


                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Некооректные данные! Попробуйте снова.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            continue;
                                        }
                                    }
                                    Console.Clear();
                                }
                                else if (click2 == ConsoleKey.D2)
                                {
                                    Console.Clear();
                                    break;
                                }
                            }

                            continue;


                        }
                        else if (click == ConsoleKey.D4)
                        {
                            await connection.SendMessageAsync("END");
                            Console.Clear();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                    }


                    Console.ReadLine();
                }


            }




        }
        
    } 
}