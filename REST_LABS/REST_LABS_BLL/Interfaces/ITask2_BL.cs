using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REST_LABS_BLL.Interfaces
{
    public interface ITask2_BL
    {
        Task<string> GetResultTask2Async(Task2 input);
        string GetResultTask2(Task2 input);
    }
}
