using Autodesk.Revit.UI;
using RevitMVVM.MVVM;
using RevitMVVM.RevitAPI.APIClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RevitMVVM.RevitAPI.RevitViewController
{
    class WpfWindowController : IExternalApplication
    {
        // class instance
        public static WpfWindowController Instance;
        public Window Window = new Window();
        public UserControl UserControl;


        public WpfWindowController()
        {
            Instance = this;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            if (Window != null)
            {
                Window.Close();
            }
            return Result.Succeeded;
        }

        /// <summary>
        /// Открытие окна
        /// </summary>
        /// <param name="uiapp"></param>
        /// <param name="userControl">Пользовательский элемент управления для отображения в форме</param>
        /// <param name="viewModel">ViewModel пользовательского элемента управления, реализующий IViewModel</param>
        /// <param name="externalEventHandler">Класс, реализующий IExternalEventHandler, для внесения изменений в Revit</param>
        public void ShowForm(UIApplication uiapp, UserControl userControl, IViewModel viewModel, IExternalEventHandler externalEventHandler, WindowParameters windowParameters = null)
        {
            // External Event for the dialog to use (to post requests)
            ExternalEvent exEvent = ExternalEvent.Create(externalEventHandler);

            viewModel.SetHandler(externalEventHandler, exEvent);

            userControl.DataContext = viewModel;
            UserControl = userControl;

            Window.Content = userControl;
            if (windowParameters != null)
            {
                Window.Title = windowParameters.Title;
                Window.Height = windowParameters.Height;
                Window.Width = windowParameters.Width;
                Window.Topmost = windowParameters.Topmost;
                Window.WindowStartupLocation = windowParameters.WindowStartupLocation;
            }
            Window.Show();
            
            Window.Closed += OnClosing;
            //App.RevitAddinWPFButton.Enabled = false;
        }

        public void OnClosing(object sender, EventArgs e)
        {
            //App.RevitAddinWPFButton.Enabled = true;
            WpfWindowController.Instance = null;
            UserControl = null;
        }
    }
}
