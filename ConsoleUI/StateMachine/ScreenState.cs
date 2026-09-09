namespace ConsoleUI.StateMachine
{
    public abstract class ScreenState
    {
        public virtual string? Name { get; set; } = null;
        public abstract Task<ScreenAction> RunAsync();
        public override string ToString()
        {
            return Name ?? throw new InvalidOperationException("The attempted ScreenState has no defined Name");
        }
    }
}
