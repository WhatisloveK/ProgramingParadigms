using System;
using System.Collections.Generic;
using System.Text;

namespace REST_LABS_BLL.Models
{
    
    public class Automat
    {
        public List<int> States { get; set; }
        public List<Transition> Transitions { get; set; }
        public int StartState { get; set; }
        public List<int> FinalStates { get; set; }
    }

    public class Transition
    {
        public int CurrentState { get; set; }
        public int NextState { get; set; }
        public string Symbol { get; set; }
    }

}
