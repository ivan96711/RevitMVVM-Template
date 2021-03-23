using Autodesk.Revit.UI;
using RevitMVVM.RevitAPI.APIClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitMVVM.MVVM
{
    interface IViewModel
    {
        void SetHandler(IExternalEventHandler revitHandler, ExternalEvent externalEvent);
    }
}
