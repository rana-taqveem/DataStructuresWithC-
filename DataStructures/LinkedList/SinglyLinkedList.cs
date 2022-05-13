using System;
namespace DataStructures
{

    class SinglyLinkedListNode<T>
    {
        public T data;
        public SinglyLinkedListNode<T> next;

        public SinglyLinkedListNode(T nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> head;
        public SinglyLinkedListNode<T> tail;
        private int count = 0;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(T nodeData)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
            count++;
        }

        public void InsertAtHead(T node)
        {
            var newNode = new SinglyLinkedListNode<T>(node);
            newNode.next = head;
            head = newNode;
            count++;
        }

        public int Count {

            get
            {
                return count;
            }

        }

        public void InsertAtIndex(T node, int index)
        {

            int currentIndex = 1;
            if (count < index)
            {
                InsertNode(node);
                return;
            }

            if (index < 1)
                return;

            if (index == 1)
                InsertAtHead(node);
            else
            {
                var current = head;
                while (current != null)
                {
                    if (currentIndex == index - 1)
                    {
                        var newNode = new SinglyLinkedListNode<T>(node);
                        newNode.next = current.next;
                        current.next = newNode;
                        count++;
                        break;
                    }
                    currentIndex++;
                    current = current.next;
                }
            }
        }


        public void Reverse()
        {
            if (count < 2)
            {
                return;
            }
            else
            {
                SinglyLinkedListNode<T> current = head;
                SinglyLinkedListNode<T> previous = null;
                SinglyLinkedListNode<T> next = current.next;
                this.tail = head;

                while (next != null)
                {

                    current.next = previous;
                    previous = current;
                    current = next;
                    next = next.next;
                }
                current.next = previous;

                this.head = current;
            }
        }


        public long factorial(int num)
        {
            if (num > 1)
            {
                return num * this.factorial(num - 1);
            }
            else
                return num;
        }




        public SinglyLinkedListNode<T> ReverseRecursive(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> previous)
        {
            if (count < 2)
            {
                return current;
            }
            else
            {
                if (current.next != null)
                {
                    SinglyLinkedListNode<T> next = current.next;
                    current.next = previous;
                    previous = current;
                    current = next;

                    current = ReverseRecursive(current, previous);
                }
            }

            if (current.next == null)
                current.next = previous;

            return current;

        }


        public SinglyLinkedListNode<T> ReverseBetween(SinglyLinkedListNode<T> head, int left, int right)
        {

            SinglyLinkedListNode<T> leftNode = null;
            SinglyLinkedListNode<T> rightNode = null;
            SinglyLinkedListNode<T> current = head;

            int index = 1;

            if (head.next == null)
            {
                return head;
            }

            while (index <= right + 1)
            {
                if (index == left - 1)
                {
                    leftNode = current;
                }
                else if (index == right + 1)
                {
                    rightNode = current;
                }

                if(current != null ) current = current.next;
                index++;
            }

            var diff = right - left;

            current = leftNode != null ? leftNode.next : head;
            index = 0;

            SinglyLinkedListNode<T> previous = null;
            SinglyLinkedListNode<T> next = current.next;
            this.tail = head;

            while (index < diff)
            {
                current.next = previous;
                previous = current;
                current = next;
                if(next != null)
                    next = next.next;

                index++;
            }

            if(current != null) current.next = previous;

            SinglyLinkedListNode<T> newCurrent = current;

            while (newCurrent.next != null)
                newCurrent = newCurrent.next;

            newCurrent.next = rightNode;
            if (leftNode != null)
                leftNode.next = current;
            else
                head = current;

            return head;



        }


        public SinglyLinkedListNode<T> ReverseKGroup(SinglyLinkedListNode<T> head, int k)
        {

            if (head.next == null || k < 2)
            {
                return head;
            }

            int listLength = GetListCount(head);


            bool firstSkipped = false;

            int mainIndex = 0;
            int groupIndex = 1;
            int loopLength = listLength / k;

            SinglyLinkedListNode<T> newHead = null;
            SinglyLinkedListNode<T> previous = null;
            SinglyLinkedListNode<T> current = head;
            SinglyLinkedListNode<T> lastTail = current;
            SinglyLinkedListNode<T> nextTail = current;
            SinglyLinkedListNode<T> nextNode = current.next;

            while (mainIndex < loopLength)
            {
                while (groupIndex < k)
                {
                    current.next = previous;
                    previous = current;
                    current = nextNode;
                    if (nextNode != null) nextNode = nextNode.next;

                    groupIndex++;
                }

                if (current != null) current.next = previous;

                if (mainIndex == 0)
                {
                    newHead = current;
                    if (groupIndex == listLength)
                        return newHead;
                }

                if (groupIndex == k)
                {
                    if (firstSkipped)
                    {
                        lastTail.next = current;
                        lastTail = nextTail;
                    }

                    firstSkipped = true;
                    groupIndex = 1;

                    nextTail = nextNode;
                    current = nextNode;
                    previous = null;

                    if(current != null) nextNode = current.next;
                }

                mainIndex++;
            }

            lastTail.next = current;

            return newHead;
        }

        public int GetListCount(SinglyLinkedListNode<T> head)
        {
            int count = 0;
            while (head != null)
            {
                head = head.next;
                count++;
            }

            return count;
        }

        public SinglyLinkedListNode<T> MiddleNode(SinglyLinkedListNode<T> head)
        {

            if (head.next == null)
                return head;

            var first = head;
            var second = head;

            while (second != null && second.next != null)
            {
                first = first.next;
                second = second.next.next;
            }

            return first;
        }
    }

 
}



    



