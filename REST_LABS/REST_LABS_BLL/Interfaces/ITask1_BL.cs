using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REST_LABS_BLL.Interfaces
{
    
    public interface ITask1_BL
    {
        Task<string> GetResultTask1Async(Task1 input);
        string GetResultTask1(Task1 input);

        Task<string> GetResultTask2Async(string input);
        string GetResultTask2(string input);
    }
}
