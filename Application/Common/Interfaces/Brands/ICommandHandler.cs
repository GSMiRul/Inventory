using System.Windows.Input;

namespace Application.Common.Interfaces.Brands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
