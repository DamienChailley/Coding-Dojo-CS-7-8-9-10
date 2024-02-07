using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProjectForCS_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Super heroes incomes simulation.\n\n");

            GameManager gameManager = new GameManager();

            gameManager.InitWorld();

            gameManager.DisplayWorld();

            Console.ReadLine(); // Obligatoire sinon la console se ferme.
        }
    }
}
