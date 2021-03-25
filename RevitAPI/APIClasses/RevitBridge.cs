using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevitMVVM.RevitAPI.APIClasses
{
    public class RevitBridge
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Application app;
        private Document doc;

        public List<Parameter> Parameters;

        public RevitBridge(UIApplication uiapp)
        {
            this.uiapp = uiapp;
            app = uiapp.Application;
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;
        }

    }
}
