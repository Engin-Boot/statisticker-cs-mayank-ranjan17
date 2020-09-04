using System;
using System.Collections.Generic;

namespace Statistics
{
    public class Stats
    {
        public float average, max, min;
        public Stats(float average,float max,float min)
        {
            this.average = average;
            this.max = max;
            this.min = min;
        }
    }
    public class StatsComputer
    {
        public float Max(float max,float number)
        {
            if (number > max)
            {
                max = number;
            }
            return max;
        }

        public float Min(float min,float number)
        {
            if (number < min)
            {
                min = number;
            }
            return min;

        }
        public Stats CalculateStatistics(List<float> numbers) {
            float average = 0;
            float countOfNumber= 0;
            float max = -10000;
            float min = 10000;
            bool arrayisempty = true;
                for (int i = 0; i < numbers.Count; i++)
                {
                  
                    arrayisempty = false;
                    if (!float.IsNaN(numbers[i]))
                    {
                        countOfNumber += 1;
                        average = numbers[i] + average;
                        max=Max(max, numbers[i]);
                        min=Min(min, numbers[i]);   
                    }
                }
               average = average / countOfNumber;
               if(arrayisempty)
               {
                 average = float.NaN;
                 max = float.NaN;
                 min = float.NaN;
               }
               Stats stats = new Stats(average, max, min);
               return stats;
        }
    }
}
