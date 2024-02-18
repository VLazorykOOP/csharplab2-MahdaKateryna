namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Виберіть завдання:");
            Console.WriteLine("1. Підрахунок середнього арифметичного від'ємних елементів.");
            Console.WriteLine("2. Знаходження номера першого мінімального елемента.");
            Console.WriteLine("3. Обмін місцями рядків у двовимірному масиві.");
            Console.WriteLine("4. Знаходження першого додатнього елемента у кожному стовпці.");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }



        static void Task1()
        {
            Console.WriteLine("Оберіть вимірність масиву.");
            int a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("Введіть розмірність масиву (n):");
                int n = int.Parse(Console.ReadLine());

                int[] arr = new int[n];
                double sum = 0;
                int count = 0;

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Введіть {i + 1}-й елемент масиву:");
                    arr[i] = int.Parse(Console.ReadLine());
                    if (arr[i] < 0)
                    {
                        sum += arr[i];
                        count++;
                    }
                }

                double average = count > 0 ? sum / count : 0;
                if (average == 0)
                    Console.WriteLine("Немає від'ємних елементів");
                else
                    Console.WriteLine($"Середнє арифметичне від'ємних елементів: {average}");
            }
            else if (a == 2)
            {
                
                Console.WriteLine("Введіть розмірність масиву (n):");
                int n = int.Parse(Console.ReadLine());

                int[,] array2D = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine($"Введіть елемент [{i+1},{j+1}]:");
                        array2D[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                double sum = 0;
                int count = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (array2D[i, j] < 0)
                        {
                            sum += array2D[i, j];
                            count++;
                        }
                    }
                }

                double average = count > 0 ? sum / count : 0;
                if (average == 0)
                    Console.WriteLine("Немає від'ємних елементів");
                else
                    Console.WriteLine($"Середнє арифметичне від'ємних елементів: {average}");
            }
            else
            {
                Console.WriteLine("Помилка!");
            }
        }

        static void Task2()
        {
            Console.WriteLine("Введіть розмірність масиву (n):");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть {i + 1}-й елемент масиву:");
                arr[i] = int.Parse(Console.ReadLine());
            }

            double min = 0;
            int minIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                    break;
                }
            }
        
            if (min == 0)
            {
                Console.WriteLine("Немає мінімального елемента");
            }
            else
                Console.WriteLine($"Номер першого мінімального елемента: {minIndex}");
        }

        static void Task3()
        {
            Console.WriteLine("Введіть розмірність масиву (n):");
            int n = int.Parse(Console.ReadLine());

            int[,] array2D = new int[n, n];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array2D[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int middleRow = n / 2;
            int[,] tempRow = new int[1, n];

            if (n % 2 == 0)
            {
                // Обмін середніх двох рядків
                Array.Copy(array2D, middleRow * n, tempRow, 0, n);
                Array.Copy(array2D, (middleRow - 1) * n, array2D, middleRow * n, n);
                Array.Copy(tempRow, 0, array2D, (middleRow - 1) * n, n);
            }
            else
            {
                // Обмін першого і середнього рядка
                Array.Copy(array2D, 0, tempRow, 0, n);
                Array.Copy(array2D, middleRow * n, array2D, 0, n);
                Array.Copy(tempRow, 0, array2D, middleRow * n, n);
            }

            Console.WriteLine("Результат:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array2D[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Task4()
        {
            Console.WriteLine("Введіть розмірність масиву (n):");
            int n = int.Parse(Console.ReadLine());

            int[,] array2D = new int[n, n];
            int[] resultArray = new int[n];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array2D[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (array2D[i, j] > 0)
                    {
                        resultArray[j] = array2D[i, j];
                        break;
                    }
                }
            }

            Console.WriteLine("Перші додатні елементи у кожному стовпці:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Стовпець {i + 1}: {resultArray[i]}");
            }
        }

    }
}
