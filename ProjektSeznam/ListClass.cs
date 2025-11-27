using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjektSeznam
{
    internal class ListClass
    {
        public LinkedList<ListItem> Seznam;

        public int Count;

        public ListItem FirstItem;

        public ListItem LastItem;


        public ListClass(LinkedList<ListItem> seznam)
        {
            Seznam = seznam;
            FirstItem = null;
            LastItem = null;
            Count = 0;
        }


        public static void Last(ListClass seznam)
        {
            if (seznam.Count > 0)
            {
                    Program.Current = seznam.LastItem;
            }
            else
            {
                Console.WriteLine("Deník je prázdný.");
                Console.ReadKey();
            }
        }

        public static void First(ListClass seznam)
        {
            if (seznam.Count > 0)
            {
                Program.Current = seznam.FirstItem;
            }
            else
            {
                Console.WriteLine("Deník je prázdný.");
                Console.ReadKey();
            }
        }
        public static void Previous()
        {
            if (Program.Current == null)
            {
                Console.WriteLine("Nejprve přejděte na nějaký záznam.");
                Console.ReadKey();
                return;
            }

            if (Program.Current.Previous != null)
            {
                Program.Current = Program.Current.Previous;
            }
            else
            {
                Console.WriteLine("Jste na prvním záznamu.");
                Console.ReadKey();
            }
        }

        public static void Next()
        {
            if (Program.Current == null)
            {
                Console.WriteLine("Nejprve přejděte na nějaký záznam.");
                Console.ReadKey();
                return;
            }

            if (Program.Current.Next != null)
            {
                Program.Current = Program.Current.Next;
            }
            else
            {
                Console.WriteLine("Jste na posledním záznamu.");
                Console.ReadKey();
            }
        }
        public static void AddItemLast(ListItem item,ListClass seznam){
            if (seznam.FirstItem == null)
            {
                seznam.FirstItem = item;
                seznam.LastItem = item;
            }
            else
            {
                seznam.LastItem.Next = item;
                item.Previous = seznam.LastItem;
                seznam.LastItem = item;
            }
            seznam.Count++;
        }

        public static void NewItem( ListClass seznam)
        {
            DateTime datum;
            while (true)
            {
                Console.Write("Zadejte datum (dd.mm.yyyy): ");
                string datumText = Console.ReadLine();
                if (DateTime.TryParseExact(datumText, "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out datum))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný formát data! Zkuste znovu.");
                }
            }
            Console.WriteLine("Nyní zadejte text (pro ukončení napište hotovo):");
            StringBuilder content = new StringBuilder();
            string row;

            while (true)
            {
                row = Console.ReadLine();
                if (row?.ToLower() == "hotovo")
                {
                    break;
                }
                content.AppendLine(row);
            }
            string Scontent = content.ToString().TrimEnd();
            ListItem item = new ListItem(Scontent, datum);

            Program.Current = item;



        }

        public static void Delete(ListClass seznam)
        {
            if (Program.Current == null)
            {
                Console.WriteLine("Není vybrán žádný záznam ke smazání.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("=== ODSTRANĚNÍ ZÁZNAMU ===\n");
            Console.WriteLine(Program.Current.Content);
            Console.WriteLine();
            Console.Write("Opravdu chcete odstranit tento záznam? (ano/ne): ");
            string odpoved = Console.ReadLine();

            if (odpoved == "ano")
            {
                ListItem proOdstraneni = Program.Current;

                Program.Current = seznam.FirstItem;

                seznam.Odstran(proOdstraneni);
                seznam.Seznam.Remove(proOdstraneni);

                if (Program.Current == proOdstraneni)
                {
                    Program.Current = seznam.FirstItem;
                }

                Console.WriteLine("Záznam byl odstraněn.");
            }
            else
            {
                Console.WriteLine("Odstranění zrušeno.");
            }
            Console.ReadKey();
        }

        public void Odstran(ListItem item)
        {
            if (item == null) return;

            if (item.Previous != null)
            {
                item.Previous.Next = item.Next;
            }
            else
            {
                FirstItem = item.Next;
            }

            if (item.Next != null)
            {
                item.Next.Previous = item.Previous;
            }
            else
            {
                LastItem = item.Previous;
            }

            Count--;
        }

    }
}
