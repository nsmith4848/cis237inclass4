using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make a new linked list
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.Add("First");
            myLinkedList.Add("Second");
            myLinkedList.Add("Third");
            myLinkedList.Add("Fourth");           

            //Loop through with this differently looking for loop to output.
            //In here, the first part is initialization: Setting x to the Head
            //The second part is the test: if x is null, keep going
            //The last part is: Set the current x to x's next pointer.
            for (Node x = myLinkedList.Head; x != null; x = x.Next)
            {
                Console.WriteLine(x.Data);
            }
        }
    }
}
