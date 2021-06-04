using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace RevitMVVM.RevitAPI.APIClasses
{
    [Transaction(TransactionMode.Manual)]
    public class RevitHandler : IExternalEventHandler
    {
        public void Execute(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                //Здесь должен быть код для взаимодействия с Revit
            }
            catch (Exception exception)
            {
                MessageBox.Show("Произошла ошибка. \n" + exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public string GetName()
        {
            return "Revit Addin";
        }
    }
}
