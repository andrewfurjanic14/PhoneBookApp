using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.StateMachine
{
    public class ExitScreenSentinel : ScreenState
    {
        public override string Name => "Exit";
        public override Task<ScreenAction> RunAsync() => throw new NotSupportedException();
    }
    public class BackScreenSentinel : ScreenState
    {
        public override string Name => "Go Back";
        public override Task<ScreenAction> RunAsync() => throw new NotSupportedException();
    }
}
