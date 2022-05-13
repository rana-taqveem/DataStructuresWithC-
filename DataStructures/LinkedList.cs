using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    //static void PrintSinglyLinkedList(SinglyLinkedListNode<T> node, string sep, TextWriter textWriter)
    //{
    //    while (node != null)
    //    {
    //        textWriter.Write(node.data);

    //        node = node.next;

    //        if (node != null)
    //        {
    //            textWriter.Write(sep);
    //        }
    //    }
    //}

    //// Complete the mergeLists function below.

    ///*
    // * For your reference:
    // *
    // * SinglyLinkedListNode<T> {
    // *     int data;
    // *     SinglyLinkedListNode<T> next;
    // * }
    // *
    // */
    //static void mergeLists(SinglyLinkedListNode<T> head1, SinglyLinkedListNode<T> head2)
    //{

    //    //var h1 = head1;
    //    //var h2 = head2;
    //    //var nh = head1;

    //    //while (true)
    //    //{
    //    //    if(h1.data < h2.data)
    //    //    {
    //    //        nh = new SinglyLinkedListNode<T>(h1.data);
                
    //    //    }
    //    //}



    //    return null;

    //}

    ////static void Main(string[] args)
    ////{
    ////    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    ////    int tests = Convert.ToInt32(Console.ReadLine());

    ////    for (int testsItr = 0; testsItr < tests; testsItr++)
    ////    {
    ////        SinglyLinkedList llist1 = new SinglyLinkedList();

    ////        int llist1Count = Convert.ToInt32(Console.ReadLine());

    ////        for (int i = 0; i < llist1Count; i++)
    ////        {
    ////            int llist1Item = Convert.ToInt32(Console.ReadLine());
    ////            llist1.InsertNode(llist1Item);
    ////        }

    ////        SinglyLinkedList llist2 = new SinglyLinkedList();

    ////        int llist2Count = Convert.ToInt32(Console.ReadLine());

    ////        for (int i = 0; i < llist2Count; i++)
    ////        {
    ////            int llist2Item = Convert.ToInt32(Console.ReadLine());
    ////            llist2.InsertNode(llist2Item);
    ////        }

    ////        SinglyLinkedListNode<T> llist3 = mergeLists(llist1.head, llist2.head);

    ////        PrintSinglyLinkedList(llist3, " ", textWriter);
    ////        textWriter.WriteLine();
    ////    }

    ////    textWriter.Flush();
    ////    textWriter.Close();
    ////}
}
