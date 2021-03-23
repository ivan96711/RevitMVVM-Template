using Autodesk.Revit.UI;
using RevitMVVM.RevitAPI.APIClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitMVVM.MVVM.FirstControl
{
    public class FirstControlViewModel : IViewModel
    {
        private IExternalEventHandler RevitHandler;
        private ExternalEvent ExternalEvent;

        public string Text { get; set; } = "Hello word";
        public FirstControlViewModel()
        {

        }

        public void SetHandler(IExternalEventHandler revitHandler, ExternalEvent externalEvent)
        {
            RevitHandler = revitHandler;
            ExternalEvent = externalEvent;
        }
    }
}
