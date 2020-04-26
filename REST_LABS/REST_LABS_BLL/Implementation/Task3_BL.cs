using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using REST_LABS_BLL.Interfaces;

namespace REST_LABS_BLL.Implementation
{
    public class Task3_BL: ITask3_BL
    {
        private Automat automat;

        public void SetAutomat(Automat automat)
        {
            this.automat = automat;
        }
        public async Task<string> GetResultTask2Async(Automat automat)
        {
            return await Task.Run(() => GetResultTask2(automat));
        }

        public List<string> GetAlphabet()
        {
            var alphabet = new List<string>();
            
            automat.Transitions.ForEach(item =>
            {
                if (!alphabet.Contains(item.Symbol))
                {
                    alphabet.Add(item.Symbol);
                }
            });

            return alphabet;
        } 

        public string GetResultTask2(Automat automat)
        {
            this.automat = automat;
            var alpabet = GetAlphabet();
            string currentWord;
            foreach (var item in alpabet)
            {
                currentWord = GetWordBySymbol(new List<int> { automat.StartState }, item, 0);
                if (!String.IsNullOrEmpty(currentWord))
                {
                    return currentWord;
                }
            }
            return "";
        }

        public string GetWord(int numberOfSteps, string symbol)
        {
            string result="";
            for(int i = 0; i < numberOfSteps; i++)
            {
                result += symbol;
            }

            return result;
        }

        public string GetWordBySymbol(List<int> reachedStates, string symbol, int step)
        {
            
            var currentReachedState = automat.Transitions.Where(item => (item.CurrentState == reachedStates.Last()) && (item.Symbol == symbol)).Select(t=>t.NextState).First();
            if (automat.FinalStates.Contains(currentReachedState))
            {
                return GetWord(++step, symbol);
            } else if (!reachedStates.Contains(currentReachedState))
            {
                reachedStates.Add(currentReachedState);
                return GetWordBySymbol(reachedStates, symbol, ++step);
            } 
            else
            {
                return null;
            }

        }
    }
}
