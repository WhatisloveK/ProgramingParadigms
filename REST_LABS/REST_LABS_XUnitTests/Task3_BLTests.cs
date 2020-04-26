using REST_LABS_BLL.Implementation;
using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace REST_LABS_XUnitTests
{
    public class Task3_BLTests
    {

        [Fact]
        public void GetWordBySymbolTest()
        {
            //Arrange 

            Automat automat = new Automat
            {
                StartState = 1,
                FinalStates = new List<int>{ 4, 5 },
                Transitions = new List<Transition>
                {
                    new Transition{CurrentState = 1, Symbol = "a", NextState = 2 },
                    new Transition{CurrentState = 1, Symbol = "b", NextState = 1 },
                    new Transition{CurrentState = 2, Symbol = "a", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 2, Symbol = "c", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "a", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 4, Symbol = "a", NextState = 1 },
                    new Transition{CurrentState = 4, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 5, Symbol = "a", NextState = 5 }
                }
            };
            Task3_BL helper = new Task3_BL(automat);

            //Act
            string result = helper.GetWordBySymbol(new List<int> { 1 }, "a", 0);

            //Assert
            Assert.Equal("aaa", result);

        }

        [Fact]
        public void GetWordBySymbolReturnNull()
        {
            //Arrange 
            Automat automat = new Automat
            {
                StartState = 1,
                FinalStates = new List<int> { 4, 5 },
                Transitions = new List<Transition>
                {
                    new Transition{CurrentState = 1, Symbol = "a", NextState = 2 },
                    new Transition{CurrentState = 1, Symbol = "b", NextState = 1 },
                    new Transition{CurrentState = 2, Symbol = "a", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 2, Symbol = "c", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "a", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 4, Symbol = "a", NextState = 1 },
                    new Transition{CurrentState = 4, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 5, Symbol = "a", NextState = 5 }
                }
            };
            Task3_BL helper = new Task3_BL(automat);

            //Act
            string actual = helper.GetWordBySymbol(new List<int> { 1 }, "b", 0);

            //Assert
            Assert.Null(actual);

        }

        [Fact]
        public void GetWordBySymbolReturnNotNull()
        {
            //Arrange 
            Automat automat = new Automat
            {
                StartState = 1,
                FinalStates = new List<int> { 4 },
                Transitions = new List<Transition>
                {
                    new Transition{CurrentState = 1, Symbol = "a", NextState = 2 },
                    new Transition{CurrentState = 1, Symbol = "b", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "a", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 2, Symbol = "c", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "a", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 4, Symbol = "a", NextState = 1 },
                    new Transition{CurrentState = 4, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 5, Symbol = "a", NextState = 5 }
                }
            };
            Task3_BL helper = new Task3_BL(automat);

            //Act
            string actual = helper.GetWordBySymbol(new List<int> { 1 }, "b", 0);

            //Assert
            Assert.Equal("bb", actual);

        }

        [Fact]
        public void GetResultTask2()
        {
            //Arrange 
            Automat automat = new Automat
            {
                StartState = 1,
                FinalStates = new List<int> { 4,5 },
                Transitions = new List<Transition>
                {
                    new Transition{CurrentState = 1, Symbol = "a", NextState = 2 },
                    new Transition{CurrentState = 1, Symbol = "b", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "a", NextState = 3 },
                    new Transition{CurrentState = 2, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 2, Symbol = "c", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "a", NextState = 5 },
                    new Transition{CurrentState = 3, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 4, Symbol = "a", NextState = 1 },
                    new Transition{CurrentState = 4, Symbol = "b", NextState = 4 },
                    new Transition{CurrentState = 5, Symbol = "a", NextState = 5 }
                }
            };
            Task3_BL helper = new Task3_BL(automat);

            //Act
            string actual = helper.GetResultTask2(automat);

            //Assert
            Assert.NotNull(actual);
        }

    }
}
