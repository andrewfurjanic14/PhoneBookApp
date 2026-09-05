using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.StateMachine
{
    public abstract record ScreenAction;
    public sealed record GoTo(ScreenState Next) : ScreenAction;
    public sealed record Back : ScreenAction;
    public sealed record Exit : ScreenAction;
}
