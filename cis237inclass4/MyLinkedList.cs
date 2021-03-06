﻿using System;
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
            }

            //This is the case whre there is already at least 1 node in the linked list
            else
            {
                //Take the Tail Node, which is the last one in the list, and set it's Next property
                //Which was null, to the new node we just created.
                Tail.Next = node;                
            }
            Tail = node;
        }
        public string Retrieve(int position)
        {
            //Used as a temporary pointer to a spot within the linked list
            Node tempNode = Head;
            //Used to hold the node at the index indicated by the passed in position
            Node returnNode = null;
            //Counter to see where we are in the list
            int count = 0;

            //While our tempNode is not at the end of the list
            while(tempNode != null)
            {
                //If the count and the position match.  This means that it will be
                //zero based.  If we wanted it to be 1 based, we would need to subtract
                //1 from the position
                if(count == position)
                {
                    //Set the returnNode var to the tempNode, which is the one we were looking for
                    returnNode = tempNode;
                }
                //Incremetn the count so that we actually move through the list
                count++;
                //Set the tempNode to tempNode's next property, which will move us to the next
                //node in the linked list
                tempNode = tempNode.Next;
            }
            //We are going to use a ternary operator to do a smaller version of an if.
            //This could easily be written as a if/else.  Essentially the part in the ()
            //is the test, and the part between the ? and the : is what will happen if true.
            //The part after the : is what will happen when false.
            return (returnNode != null) ? returnNode.Data : null;
        }

        public bool Delete(int position)
        {
            //Return value for the method
            bool returnBool = false;
            //Set current to Head.
            Current = Head;
            //If the position that we want to remove is the very first node, we need to do things
            //different than if it is 1 thru the end
            if (position == 0)
            {
                //set the Head to the Current.Next which will make the next node in the linked list the new head
                Head = Current.Next;

                if(Head == null)
                {
                    Tail = null;
                }
                //Sets Current's Next property to null so that it does not connect to anything.  Not 'required' in this case, as this is the 
                //beginning
                Current.Next = null;
                //Sets Current to null to delete the node
                Current = null;
                //Return bool as true to show that something was deleted   
                returnBool = true;                       
            }
            else
            {
                //Set a tempnode to the first position in the linkedlisit.
                Node tempNode = Head;
                //Declare a previous temp that will get a value after the tempNode moves
                Node previousTempNode = null;
                //Start a counter to use to move through the linked list
                int count = 0;
                //Loop until the tempnode is null (End of list)
                while(tempNode != null)
                {
                    //If we match the position and the count we are on, we found the one that we need to delete
                    if(count == position)
                    {
                        //attaches Node before deleted node to node after deleted node
                        previousTempNode.Next = tempNode.Next;
                        //Tests to see if item deleted is at the end of the list.  If so, then the Tail property is also changed
                        if (tempNode.Next == null)
                        {
                            Tail = previousTempNode;
                        }
                        //Gets rid of deleted node's connection to next node
                        tempNode.Next = null;
                        //Deletes next node
                        tempNode = null;
                        //Return bool as true to show that something was deleted   
                        returnBool = true;
                    }
                    //Increments previousTempNode, tempNode, and count so the chain keeps moving
                    previousTempNode = tempNode;
                    tempNode = tempNode.Next;
                    count++;
                }
            }

           if(returnBool != true)
           {
              Console.WriteLine("Error!  The position did not exist to be deleted!");               
           }
           return returnBool;
        }
    }
}
