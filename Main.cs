using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab_5_3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"D:\source\RevitApps\";

            var panel = application.CreateRibbonPanel(tabName, "Тема 5");

            var button1 = new PushButtonData("Задание 5_1", "Три кнопки",
                Path.Combine(utilsFolderPath, "Lab_5_1_Button.dll"),
                "Lab_5_1_Button.Main");

            var button2 = new PushButtonData("Задание 5_2", "Типы стен",
                Path.Combine(utilsFolderPath, "Lab_5_2.dll"),
                "Lab_5_2.Main");

            Uri uriImage = new Uri(@"D:\source\RevitApps\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button1.LargeImage = largeImage;
            button2.LargeImage = largeImage;

            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }


    }
}
