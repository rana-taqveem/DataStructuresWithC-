using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.SearchAlgos;
using DataStructures.String;
using DataStructures.ArrayAlgos;
using DataStructures.LinkedList;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args) 
        {

            //Console.WriteLine(StringProblems.Reverse("Hello"));

            //int[] arr = { 2,1,-3,-4};



            //var res = ArrayAlgos.ArrayProblems.SubArrayWithHighestSum(arr);
            //Console.WriteLine(res);

            //Console.WriteLine(ArrayAlgos.ArrayProblems.maxSubArraySum(arr).ToString());
            //1,0,3,0,13,0,0,7,7,7,0,1
            //var res = ArrayAlgos.ArrayProblems.RemoveElement(new int[] { 2,3,3,2}, 3);

            //-1, 2, 1, -4 
            //var res = ArrayAlgos.ArrayProblems.ThreeSum(new int[] { -1, 2, 1, -4 }, 1);


            //    Console.Write(res.ToString() + ",");


            //var res = ArrayAlgos.ArrayProblems.dd(new int[] { 1, 2, 3 , 4, 3 } );
            //Console.WriteLine(res);

            //" "
            //"ab"
            //"abvd"
            //"aab"
            //"aababcdef"
            //pwwkew
            //var res = StringProblems.p("bacb");

            //Console.WriteLine(res.ToString());



            var res = ArrayProblems.FindMedianSortedArrays(new int[] { 0,0,0,0,0 }, new int[] { -1,0,0,0,0,0,1 });

            Console.Write(res.ToString());
            //SinglyLinkedList<int> myList = new SinglyLinkedList<int>();

            //myList.InsertNode(1);

            //myList.InsertNode(2);


            //myList.InsertNode(3);


            //myList.InsertNode(4);

            //myList.InsertNode(5);

            ////myList.InsertNode(6);


            //var res = myList.MiddleNode(myList.head);

            //while (res != null)
            //{
            //    Console.Write(res.data.ToString() + ", ");
            //    res = res.next;
            //}

            //SinglyLinkedList<int> newList = new SinglyLinkedList<int>();
            //newList.head = myList.ReverseKGroup(myList.head, 10);

            //Console.WriteLine("");
            //res = newList.head;

            //while (res != null)
            //{
            //    Console.Write(res.data.ToString() + ", ");
            //    res = res.next;
            //}
        }

        public static void c(float a)
        {
            object aa = a;
            int b = (int)(float) aa;
        }
    }
}
