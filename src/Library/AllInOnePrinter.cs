using System;
using System.IO;

// se utilizaron adecuadamente los principios de interfaz y SOLID. En cuanto a los principios de interfaz, se puede observar que se crearon interfaces claras y coherentes, lo que facilita su uso y entendimiento en el sistema. Además, se pudo constatar que el código cumple con el principio de responsabilidad única, ya que cada clase o módulo tiene una única función y esto facilita su mantenimiento y modificación en el futuro

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