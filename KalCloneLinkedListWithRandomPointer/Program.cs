using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalCloneLinkedListWithRandomPointer
{
    class Program
    {
        static void Main(string[] args)
        {

            // Pushing data in the linked list.
       LinkedList list= new LinkedList();
       list.add(5);

       list.add(4); list.add(3); list.add(2); list.add(1);
 
        // Setting up random references.
        list.head.random = list.head.next.next;
        list.head.next.random =
            list.head.next.next.next;
        list.head.next.next.random =
            list.head.next.next.next.next;
        list.head.next.next.next.random =
           list.head;
        list.head.next.next.next.next.random =
            list.head.next;
 
        // Making a clone of the original linked list.
        LinkedList clone =list.cloneWithRandom();
 
        // Print the original and cloned linked list.
        Console.WriteLine("Original linked list");
        list.print();
       Console.WriteLine("\nCloned linked list");
        clone.print();
          

        }

        //cloning the list with random pointer
        
        //create a single linked list
        class Node
        {
            public  int data;
            public Node next, random; //next and random pointers
            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.random = null;

            }
        }
        class LinkedList
        {
           public Node head;
            //constructor
            public LinkedList(){
            this.head= null;

            }
            public LinkedList(Node h)
            {
                this.head = h;
            }
          
            //add a node
            public  void add(int data)
            {
                Node newNode = new Node(data); //create a node
                //check if head is null
                if (this.head == null)
                {
                    this.head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = newNode;
                }
            }

            public LinkedList cloneWithRandom()
            {
                //1. Traverse the original linked list and make a copy in terms of data.
                //2. Make a Dictionary of key value pair with original linked list node and copied linked list node.
                //3. Traverse the original linked list again and using the dictionary adjust the next and random reference of cloned linked list nodes.
                Dictionary<Node, Node> dl = new Dictionary<Node, Node>();

                //we will start with head
                Node current =this.head;
                while (current!= null)
                {
                    Console.WriteLine(current.data);
                    //copy each node in dictionary with value
                    Node newNode = new Node(current.data);
                    // put this Node as Value for key of parent node
                    dl.Add(current, newNode);
                    current = current.next;
                }

                // now we will create the clone of the list
                //traverse the original list one more time
                current = this.head;
              
                Node cloneNode=null ;

                while (current != null)
                {
                    cloneNode = dl[current];
                    Console.WriteLine(cloneNode.data);
                 cloneNode.next = current.next;
                    //Console.WriteLine(cloneNode.next.data);
                 cloneNode.random = dl[current.random];

                    current = current.next;
              

                }
             LinkedList clone = new LinkedList();
             clone.head = dl[this.head];
             //   clone.print();
                return clone;

            }


            // Method to print the list.
            public void print()
            {
                Node temp = head;
                while (temp != null)
                {
                    Node random = temp.random;
                    int randomData = (random != null)? random.data: -1;
                    Console.WriteLine("Data = " + temp.data +
                                       ", Random data = "+ randomData);
                    temp = temp.next;
                }
            }
        }
    }
}
