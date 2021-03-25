#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitMVVM.MVVM.FirstControl;
using RevitMVVM.RevitAPI.APIClasses;
using RevitMVVM.RevitAPI.RevitViewController;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RevitMVVM
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private WpfWindowController _wpfWindowController = new WpfWindowController();

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            try
            {
                //Пользовательский элемент управления
                FirstControlView firstControlView = new FirstControlView();
                //ViewModel пользовательского элемента
                FirstControlViewModel vm = new FirstControlViewModel(new RevitBridge(commandData.Application));
                //Обработчик Revit для окна 
                RevitHandler revitHandler = new RevitHandler();

                _wpfWindowController.ShowForm(commandData.Application, firstControlView, vm, revitHandler);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
