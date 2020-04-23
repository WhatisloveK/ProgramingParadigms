using REST_LABS_BLL.Interfaces;
using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_LABS_BLL.Implementation
{
    public class Task1_BL : ITask1_BL
    {

        private List<int> GetList(string data)
        {
            string input = data;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is empty!");
            }

            var numbers = input.Split(',', ';').Where(x => !string.IsNullOrWhiteSpace(x));

            if (numbers.All(x => int.TryParse(x, out int res)))
            {
                var list = numbers.Select(x => int.Parse(x)).ToList();

                return list;
            }
            else
            {
                throw new ArgumentException("Incorrect input numbers!");
            }
        }

        #region Part1

        public async Task<string> GetResultTask1Async(Task1 input)
        {
            return await Task.Run(() => GetResultTask1(input));
        }
        public string GetResultTask1(Task1 input)
        {
            var list = GetListAfterDeletion(input);

            string result = "[";

            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    result += $"{list[i]}, ";
                }
                else
                {
                    result += $"{list[i]}";
                }
            }

            result += "]";
            return result;
        }

        
        private List<int> GetListAfterDeletion(Task1 input)
        {
            var list = GetList(input.ElementsData);

            var sortedFirstN = list.OrderBy(u => u).Take(Int32.Parse(input.N)).ToList();

            return RemoveFirstEntry(list, sortedFirstN);
        }

        private List<int> RemoveFirstEntry(List<int> elements, List<int> sortedFirstN)
        {
            List<int> result = new List<int>();

            elements.ForEach(item =>
            {
                if (sortedFirstN.Contains(item))
                {
                    sortedFirstN.Remove(item);
                }
                else
                {
                    result.Add(item);
                }
            });
            return result;
        }


        #endregion


        #region Part2

        public async Task<string> GetResultTask2Async(string input)
        {
            return await Task.Run(() => GetResultTask2(input));
        }
        public string GetResultTask2(string input)
        {

            var list = GetList(input);

            var result = new List<int>();
            for(int i = 0; i < list.Count; i++)
            {
                if (IsSquare(i+1))
                {
                    result.Add(list[i]);
                }
            }

            string resultString = "[";

            for (int i = 0; i < result.Count; i++)
            {
                if (i != result.Count - 1)
                {
                    resultString += $"{result[i]}, ";
                }
                else
                {
                    resultString += $"{result[i]}";
                }
            }

            resultString += "]";

            return resultString;
        }

        private bool IsSquare(int number)
        {
            return Math.Floor(Math.Sqrt(number)) == Math.Sqrt(number);
        }

        #endregion
    }
}
