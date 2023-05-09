using System;
using System.IO;

namespace Full_GRASP_And_SOLID.Library
{
    public interface IPrinterStrategy
    {
        void Print(string text);
    }

    public class ConsolePrinterStrategy : IPrinterStrategy
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class FilePrinterStrategy : IPrinterStrategy
    {
        public void Print(string text)
        {
            File.WriteAllText("Recipe.txt", text);
        }
    }

    public class AllInOnePrinter
    {
        private IPrinterStrategy printerStrategy;

        public AllInOnePrinter(IPrinterStrategy printerStrategy)
        {
            this.printerStrategy = printerStrategy;
        }

        public void PrintRecipe(Recipe recipe)
        {
            string textToPrint = recipe.GetTextToPrint();
            printerStrategy.Print(textToPrint);
        }
    }
}