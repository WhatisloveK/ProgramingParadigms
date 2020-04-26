using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REST_LABS_BLL.Interfaces
{
    public interface ITask3_BL
    {
        Task<string> GetResultTask2Async(Automat input);
        string GetResultTask2(Automat input);
    }
}
