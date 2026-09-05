using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.StateMachine
{
    internal class ScreenController
    {
        private readonly Stack<ScreenState> _stateStack = new();
        
        public ScreenController(ScreenState root) => _stateStack.Push(root);

        public void Run()
        {
            while (_stateStack.Count > 0)
            {
                AnsiConsole.Clear();
                var action = _stateStack.Peek().Run();

                switch (action)
                {
                    case GoTo g: 
                        _stateStack.Push(g.Next);
                        break;
                    case Back:
                        _stateStack.Pop();
                        break;
                    case Exit: 
                        _stateStack.Clear();
                        break;
                }
            }
        }
    }
}
