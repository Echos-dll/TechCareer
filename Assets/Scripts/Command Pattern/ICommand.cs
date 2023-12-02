namespace Command_Pattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}