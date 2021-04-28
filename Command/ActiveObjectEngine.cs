using System.Collections;

namespace Command
{
    public interface ICommand
    {
        void Excute();
    }
    public class ActiveObjectEngine
    {
        ArrayList itsCommand = new ArrayList();

        public void AddCommand(ICommand c)
        {
            itsCommand.Add(c);
        }

        public void Run()
        {
            while (itsCommand.Count > 0)
            {
                ICommand c = (ICommand)itsCommand[0];
                c.Excute();
            }
        }
    }
}
