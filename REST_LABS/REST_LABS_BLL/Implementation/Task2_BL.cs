using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST_LABS_BLL.Interfaces;
using REST_LABS_BLL.Models;

namespace REST_LABS_BLL.Implementation
{
    public class Task2_BL: ITask2_BL
    {
        private Dictionary<int,int> GetList(string data)
        {
            var result = new Dictionary<int,int>();
            string input = data;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is empty!");
            }

            var numbers = input.Split(',', ';').Where(x => !string.IsNullOrWhiteSpace(x));

            if (numbers.All(x => int.TryParse(x, out int res)))
            {
                int counter = 0;
                result = numbers.Select(x => int.Parse(x)).ToDictionary(item => counter++, item =>item);
            }
            else
            {
                throw new ArgumentException("Incorrect input numbers!");
            }
            return result;
        }

        public async Task<string> GetResultTask2Async(Task2 input)
        {
            return await Task.Run(() => GetResultTask2(input));
        }
        public string GetResultTask2(Task2 input)
        {
            Dictionary<int,int> dictionary = GetList(input.Data);
            var resultDictionary = dictionary.Where(item => IsLocalMax(item, dictionary)).ToDictionary(item=>item.Key, item=> item.Value);

            string result = "[";
            
            foreach (var item in resultDictionary)
            {

                result += !(item.Key == resultDictionary.Last().Key) ? $"({item.Key}, {item.Value}), " : $"({item.Key}, { item.Value})";
            }
            result += "]";
            return result;
        }

        private bool IsLocalMax(KeyValuePair<int,int> elem, Dictionary<int,int> dictionary)
        {
            return (elem.Key == 0 || (dictionary[elem.Key - 1] < elem.Value)) && ((elem.Key == (dictionary.Count - 1))||(dictionary[elem.Key + 1]< elem.Value));
        }

    }
}
