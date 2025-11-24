using System.Security.Cryptography.X509Certificates;

namespace ProjektSeznam
{
    internal class Program
    {
        public static ListItem Current;
        public static bool Run;
        static void Main(string[] args)
        {
            ListClass seznam = new ListClass(new LinkedList<ListItem>());
            Run = true;
            while (Run)
            {
                LoadMenu(seznam.Count);
                ReadInput(Console.ReadLine(), seznam);
            }
        }

        public static void LoadMenu(int zCount)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Deník se ovládá pomocí následujících příkazů:\r" +
                "\n•\tpredchozi - Přesune napředchozí záznam" +
                "\r\n•\tdalsi - Přesune na následující záznam" +
                "\r\n•\tzacatek - Přesune na první zaznam" +
                "\r\n•\tkonec - Přesune na poslední záznam" +
                "\r\n•\tnovy - vytvoření nového záznamu" +
                "\r\n•\tuloz - uložení nově vytvořeného záznamu" +
                "\r\n•\tsmaz - odstraní záznamu" +
                "\r\n•\tzavri - zavře deník\r\n");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Počet záznamů: " + zCount);
            if (Current != null)
            {
                Console.WriteLine(Current);
            }
            Console.WriteLine();
            Console.WriteLine("Zadej Příkaz: ");
        }

        public static void ReadInput(string input,ListClass seznam)
        {
            switch(input)
            {
                case "novy":
                    ListClass.NewItem(seznam);
                    break;
                case "uloz":
                    ListClass.AddItemLast(Current, seznam);
                    break;
                case "predchozi":
                    ListClass.Previous();
                    break;
                case "dalsi":
                    ListClass.Next();
                    break;
                case "zacatek":
                    ListClass.First(seznam);
                    break;
                case "konec":
                    ListClass.Last(seznam);
                    break;
                case "smaz":
                    ListClass.Delete(seznam);
                    break;
                case "zavri":
                    Console.WriteLine("Ukončuji program...");
                    Console.ReadKey();
                    Run = false;
                    break;
                default:
                    Console.WriteLine("Neznámý příkaz!");
                    break;
            }
        }


        

    }
}
