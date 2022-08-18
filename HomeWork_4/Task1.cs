using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork; //добавление библиотеки (пространства HomeWork) из второй домашней работы
using ArrayLibrary; //добавление библиотеки, содержащей класс для работы с массивом

namespace HomeWork_4
{
    // 1.а) Дописать класс для работы с одномерным массивом. Реализовать конструктор,
    // создающий массив определенного размера и заполняющий массив числами от начального
    // значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива,
    // метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива
    // (старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число,
    // свойство MaxCount, возвращающее количество максимальных элементов.
    // б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки

    // решение предоставил Юрченко Н.А.
    
    class Task1
    {
        
        /// <summary>
        /// Преобразование строки в число
        /// </summary>
        /// <param name="value">Введенное значение</param>
        /// <returns></returns>
        static int Parsing(string value)
        {
            int number;
            bool result=int.TryParse(value, out number);

            if (value == "")
                value = null;
                   
            while (value == null && result == false)
            {
                Console.Write("Повторите ввод:  ");
                value = Console.ReadLine();
                result = int.TryParse(value, out number);

                if (value == "")
                    value = null;
            }

            return number;
        }


            static void Main(string[] args)
        {
            var screen = new Screen();
            screen.ScreenPrint(4, 1);
            // Вызов метода ScreenPrint cо второй домашней работы, для вывода номера задания 
            // и домашней работы, а также вывода ФИО выполнившего студента

            Console.WriteLine();
            Console.Write("Введите размерность (длину) массива: ");
            int size;
            string value = Console.ReadLine();
            size=Parsing(value);            

            Console.WriteLine();
            Console.Write("Введите начальное число массива: ");
            int startNumber;
            value = Console.ReadLine();
            startNumber = Parsing(value);

            Console.WriteLine();
            Console.Write("Введите шаг между элементами массива: ");
            int step;
            value = Console.ReadLine();
            step = Parsing(value);

            var myArray = new MyArray(size, startNumber, step);
            Console.WriteLine();

            for (int i = 0; i < myArray.Length; i++)
                Console.Write($"{myArray[i]}   ");

            Console.WriteLine("\n");
            Console.WriteLine($"Сумма элементов массива равна: {myArray.Sum}\n");
            
           var inverseArray = myArray.Inverse();

            for (int i = 0; i < inverseArray.Length; i++)                
                Console.Write($"{inverseArray[i]}   ");

            Console.WriteLine("\n");
            Console.Write("Введите число для умножения каждого элемента массива: ");
            int multiNumber;
            value = Console.ReadLine();
            multiNumber = Parsing(value);
            
            myArray.Multi(multiNumber);

            Console.WriteLine();

            for (int i = 0; i < myArray.Length; i++)
                Console.Write($"{myArray[i]}   ");

            Console.WriteLine("\n");

            Console.WriteLine($"Количество максимальных элементов в массиве: {myArray.MaxCount}\n");

            var myArrayCheck = new int [] { 1, 4, 2, 3, 4, 6, 6 };
            myArray = new MyArray(myArrayCheck);
            Console.WriteLine("Проверим работу метода MaxCount массива\n");

            for (int i = 0; i < myArray.Length; i++)
                Console.Write($"{myArray[i]}   ");

            Console.WriteLine("\n");
            Console.WriteLine($"Количество максимальных элементов в массиве для проверки: {myArray.MaxCount}");

            Console.ReadLine();
        }
    }
}
