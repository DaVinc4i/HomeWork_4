using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class MyArray
    {
        private int[] array;

        /// <summary>
        /// Инициализация массива через параметр
        /// </summary>
        /// <param name="arr">Внешний массив</param>
        public MyArray(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }


        /// <summary>
        /// Конструктор класса, создающий массив заданной размерности 
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="startNumber">Начальный элемент массива</param>
        /// <param name="step">Шаг между элементами массива</param>
        public MyArray(int size, int startNumber, int step)
        {
            this.array = new int[size];
            int elementArr = startNumber;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0)
                    elementArr += step;

                array[i] = elementArr;
            }
        }

        private int sum = 0;

        /// <summary>
        /// Свойство возвращающее значение суммы элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }

        }

        /// <summary>
        /// Метод позволяющий изменить знак каждого элемента массива на противоположный
        /// </summary>
        /// <param name="myArray">Массив данных для замены знака на противоположный</param>
        /// <returns></returns>
        public MyArray Inverse()
        {
            var inverseArray = new int [array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                inverseArray[i] = -1*array[i];
            }

            return new MyArray(inverseArray);
        }

        public void Multi(int value)
        {

            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= value;
            }
                       
        }

        public int Length { get { return array.Length; } }

        public int MaxCount
        {
            get
            {
                int max = array[0];
                int maxCount = 1;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] == max) maxCount++;
                    if (array[i] > max) { max = array[i]; maxCount = 1; }
                    
                }

                return maxCount;
            }            
        }
    }

}
