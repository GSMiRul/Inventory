using System;
using System.Windows.Input;

namespace Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
