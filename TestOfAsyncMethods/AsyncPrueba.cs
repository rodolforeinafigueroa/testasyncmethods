using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOfAsyncMethods
{
    internal class AsyncPrueba
    {
        private List<int> integers;
       internal AsyncPrueba()
        {
            integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        }


        public async Task Insert()
        {
            var resultList = new List<int>();
            var random = new Random();
            //var tasks = new List<Task>();
            //foreach (int integer in integers)
            //{
            //    tasks.Add(AddToResultList(integer, resultList, random));

            //}

            var tasks = integers.Select(integer => AddToResultList(integer, resultList, random));
            await Task.WhenAll(tasks);
            foreach (var result in resultList)
            {
                Console.WriteLine(result);
            }
        }

       

        private static async Task AddToResultList(int integer, List<int> resultList, Random random)
        {
            var waitTime = random.Next(3000, 10000);
            Console.WriteLine(waitTime);
            await Task.Delay(waitTime);
            resultList.Add(integer);
        }


    }
}
