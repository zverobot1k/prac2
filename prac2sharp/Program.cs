using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выбери задачу для запуска:");
            Console.WriteLine("1 — Ряд Маклорена (cos x)");
            Console.WriteLine("2 - Счастливый билет");
            Console.WriteLine("3 — Сокращение дроби");
            Console.WriteLine("4 — Угадай число (бинарный поиск)");
            Console.WriteLine("5 — Кофе и латтэ");
            Console.WriteLine("6 — Бактерии и антибиотик");
            Console.WriteLine("7 — Колонизация Марса");
            Console.WriteLine("0 — Выход");

            Console.Write("\nВаш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Console.WriteLine(Task2());
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Console.WriteLine("Task5 пока не реализован.");
                    break;
                case "6":
                    Task6();
                    break;
                case "7":
                    Task7();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуй снова!");
                    break;
            }

            Console.WriteLine("\nНажми любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }

    //Задача1
    static void Task1()
    {
        Console.WriteLine("Выберите режим:");
        Console.WriteLine("1 — Вычислить cos(x) с заданной точностью e");
        Console.WriteLine("2 — Найти n-й член ряда");
        int mode = int.Parse(Console.ReadLine());

        if (mode == 1)
        {
            // ------------------ ВЫЧИСЛЕНИЕ COS(X) С ТОЧНОСТЬЮ E ------------------
            Console.Write("Введите x (в радианах): ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите точность e (<0.01): ");
            double e = double.Parse(Console.ReadLine());

            double term = 1; // первый член ряда (n = 0)
            double sum = term;
            int n = 1;

            // продолжаем, пока модуль члена больше e
            while (Math.Abs(term) > e)
            {
                term *= -x * x / ((2 * n - 1) * (2 * n)); // рекуррентная формула
                sum += term;
                n++;
            }

            Console.WriteLine($"\ncos({x}) ≈ {sum}");
            Console.WriteLine($"Количество членов ряда: {n}");
            Console.WriteLine($"Проверка через Math.Cos: {Math.Cos(x)}");
        }
        else if (mode == 2)
        {
            // ------------------ ВЫЧИСЛЕНИЕ n-го ЧЛЕНА РЯДА ------------------
            Console.Write("Введите x (в радианах): ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите номер n: ");
            int n = int.Parse(Console.ReadLine());

            double term = Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 * n);

            Console.WriteLine($"n-й член ряда для cos({x}) при n = {n} равен {term}");
        }
        else
        {
            Console.WriteLine("Ошибка: выберите 1 или 2.");
        }
    }
    // Вспомогательная функция
    static double Factorial(int n)
    {
        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }



    //Задача 2
    static bool Task2()
    {
        System.Console.WriteLine("Введите номер счастливого билета");
        int a = int.Parse(Console.ReadLine());
        //Получаем каждую цифру и сравнием суммы
        if ((a / 1000 % 10 + a / 10000 % 10 + a / 100000) == (a % 10 + a % 1000 / 100 + a % 100 / 10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Задача 3
    static void Task3()
    {
        int nod;
        System.Console.WriteLine("Введите числитель");
        int m = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Введите знаменатель");
        int n = int.Parse(Console.ReadLine());
        int m1 = m;
        int n1 = n;
        //Алгоритм Евкилда нахождения
        while (m != n)
        {
            if (m > n)
            {
                m = m - n;
            }
            else
            {
                n = n - m;
            }
        }
        nod = n;
        System.Console.WriteLine($"{m1 / nod} / {n1 / nod}");
    }

    //Задача 4
    static void Task4()
    {
        Console.WriteLine("Загадай число!");
        int num = int.Parse(Console.ReadLine());
        int low = 0;
        int high = 63;

        while (low != num)
        {

            int mid = (low + high) / 2;

            System.Console.WriteLine($"Ваше число больше {mid}?\n1 - да\n0 - нет");
            char operation = char.Parse(Console.ReadLine());

            switch (operation)
            {
                case ('1'):
                    low = mid + 1;
                    System.Console.WriteLine(low);
                    break;
                case ('0'):
                    high = mid;
                    System.Console.WriteLine(high);
                    break;
                default:
                    System.Console.WriteLine($"Ваше число больше {mid}?\n1 - да\n0 - нет");
                    break;

            }
            if (low == high)
            {
                Console.WriteLine($"Ваше число: {low}!");
                if (low == num)
                {
                    Console.WriteLine("Угадал точно!");
                }
                else
                {
                    Console.WriteLine($"Ошибка! Было загадано {num}.");

                }
            }
        }
        System.Console.WriteLine($"Ваше число: {low}");
    }

    //Задача 5 
    static void Task5()
    {
        // Инициализация констант напитков
        const int americanoWater = 300;
        const int latteWater = 30;
        const int latteMilk = 270;
        const int americanoPrice = 150;
        const int lattePrice = 170;

        // Статистика
        int americanoCount = 0;
        int latteCount = 0;
        int totalMoney = 0;

        // Запрос у пользователя начальных ресурсов
        Console.Write("Введите количество воды (мл): ");
        int water = int.Parse(Console.ReadLine());

        Console.Write("Введите количество молока (мл): ");
        int milk = int.Parse(Console.ReadLine());

        // Основной цикл работы аппарата
        while (true)
        {
            // Проверяем, хватает ли ингредиентов хотя бы на один напиток
            bool canMakeAmericano = water >= americanoWater;
            bool canMakeLatte = (water >= latteWater) && (milk >= latteMilk);

            if (!canMakeAmericano && !canMakeLatte)
            {
                // Если ни на один напиток не хватает — завершаем работу
                Console.WriteLine("\n*Отчёт*");
                Console.WriteLine("Ингредиенты подошли к концу.");
                Console.WriteLine($"Остаток воды: {water} мл");
                Console.WriteLine($"Остаток молока: {milk} мл");
                Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
                Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
                Console.WriteLine($"Итого заработано: {totalMoney} рублей.");
                Console.WriteLine("***********************************************");
                break;
            }

            // Запрос выбора напитка
            Console.WriteLine("\nВыберите напиток (1 — американо, 2 — латте): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (water >= americanoWater)
                    {
                        water -= americanoWater;
                        americanoCount++;
                        totalMoney += americanoPrice;
                        Console.WriteLine("Ваш напиток готов!");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает воды!");
                    }
                    break;

                case 2:
                    if (water >= latteWater && milk >= latteMilk)
                    {
                        water -= latteWater;
                        milk -= latteMilk;
                        latteCount++;
                        totalMoney += lattePrice;
                        Console.WriteLine("Ваш напиток готов!");
                    }
                    else if (water < latteWater)
                    {
                        Console.WriteLine("Не хватает воды!");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает молока!");
                    }
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Введите 1 или 2.");
                    break;
            }
        }
    }

    //Задача 6
    static void Task6()
    {
        Console.WriteLine("Введите количество бактерий:");
        int bacteria = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество капель антибиотика:");
        int drops = int.Parse(Console.ReadLine());

        int hour = 1; // счётчик часов
        int killPower = 10; // первая капля убивает 10 бактерий в первый час

        // Цикл продолжается, пока есть бактерии и антибиотик ещё действует
        while (bacteria > 0 && killPower > 0 && drops > 0)
        {
            // Бактерии сначала размножаются
            bacteria *= 2;

            // Затем антибиотик убивает часть бактерий
            int killed = drops * killPower; // каждая капля убивает killPower бактерий
            bacteria -= killed;

            // сли бактерий стало меньше нуля — обнуляем
            if (bacteria < 0)
                bacteria = 0;

            Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");

            // Подготовка к следующему часу
            hour++;
            killPower--; // сила антибиотика уменьшается на 1 каждый час
        }

        Console.WriteLine("*********************************************************");
        Console.WriteLine("Процесс завершён:");
        Console.WriteLine($"Итоговое количество бактерий: {bacteria}");
        Console.WriteLine($"Антибиотик больше не действует (или бактерии уничтожены).");
    }
    
    //Задача 7
    static void Task7()
    {
        // Ввод исходных данных
        Console.Write("Введите количество модулей (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите длину модуля (a): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите ширину модуля (b): ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Введите ширину поля (w): ");
        int w = int.Parse(Console.ReadLine());

        Console.Write("Введите высоту поля (h): ");
        int h = int.Parse(Console.ReadLine());

        // Ищем максимальную толщину защиты d
        int left = 0;   // минимально возможная толщина
        int right = Math.Min(w, h); // максимально возможная (с запасом)
        int answer = 0; // результат

        // Используем бинарный поиск по толщине d
        while (left <= right)
        {
            int mid = (left + right) / 2; // пробуем толщину mid

            // Рассчитываем размеры модуля с учётом защиты
            long newA = a + 2 * mid;
            long newB = b + 2 * mid;

            // Сколько модулей помещается по ширине и высоте
            long countW = w / newA;
            long countH = h / newB;

            // Проверяем, помещается ли нужное количество модулей
            if (countW * countH >= n)
            {
                // d подходит — пробуем увеличить
                answer = mid;
                left = mid + 1;
            }
            else
            {
                // d слишком велик — уменьшаем
                right = mid - 1;
            }
        }

        Console.WriteLine($"Ответ: d = {answer}");
    }
}



