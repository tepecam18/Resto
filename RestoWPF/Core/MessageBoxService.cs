using System.Windows;

namespace RestoWPF.Core
{
    public interface IMessageBoxService
    {
        void ShowMessage(string message);
    }

    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
