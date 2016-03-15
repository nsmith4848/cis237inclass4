using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class MyLinkedList
    {
        //Node that will 'point' to the current node we are looking at
        public Node Current
        {
            get;
            set;
        }

        //Node that will 'point' to the first node in the linked list
        public Node Head
        {
            get;
            set;
        }

        //Node that will 'point' to the last node in the linked list
        public Node Tail
        {
            get;
            set;
        }

        //Constructor.  Just initialize the properties to null
        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //This will be to add a new node to the linked list
        public void Add(string content)
        {
            //Make a new node
            Node node = new Node();

            //Set the data for the node to the content that was passed in
            node.Data = content;

            //if Head is null, that means that there are no nodes in the linked list.
            //We are about to add the first node
            if(Head == null)
            {
                Head = node;
                Tail = node;
            }

            //This is the case whre there is already at least 1 node in the linked list
            else
            {
                //Take the Tail Node, which is the last one in the list, and set it's Next property
                //Which was null, to the new node we just created.
                Tail.Next = node;

                Tail = node;
            }
        }
    }
}
