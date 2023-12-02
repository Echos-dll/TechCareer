namespace Command_Pattern
{
    public class ChangeHealthCommand : ICommand
    {
        private IHealthProcess _healthProcess;
        private HealthSystem _target;
        private int _amount;
        
        public ChangeHealthCommand(IHealthProcess healthProcess, HealthSystem target, int amount)
        {
            _healthProcess = healthProcess;
            _target = target;
            _amount = amount;
        }
        
        public void Execute()
        {
            _healthProcess.Process(_target, _amount);
        }

        public void Undo()
        {
            _healthProcess.UndoProcess(_target, _amount);
        }
    }
}