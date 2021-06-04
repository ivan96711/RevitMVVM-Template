#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitMVVM.UI.MainWindow;
using RevitMVVM.RevitAPI.APIClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RevitMVVM
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            try
            {
                RevitBridge revitBridge = new RevitBridge(commandData.Application);

                RevitHandler revitHandler = new RevitHandler();
                ExternalEvent exEvent = ExternalEvent.Create(revitHandler);

                MainWindowView firstControlView = new MainWindowView();
                MainWindowVM vm = new MainWindowVM();
                firstControlView.ShowDialog();


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
