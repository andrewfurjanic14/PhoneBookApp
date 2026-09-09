namespace ConsoleUI.StateMachine
{
    public abstract class ScreenState
    {
        public virtual string? Name { get; set; } = null;
        public abstract Task<ScreenAction> RunAsync();
    }
}
