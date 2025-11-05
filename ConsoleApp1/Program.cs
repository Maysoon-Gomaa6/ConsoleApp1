using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {
      static void BubbleSort(int[] arr)
        {
            bool Swapi = false;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < (arr.Length) - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        Swapi = true;
                    }
                }

                if (!Swapi)
                {
                    break;
                }
            }
           
        }


        static void ReverseQueue(Queue<int> Q)
        {
            Stack<int> S = new Stack<int>();

            while (Q.Count > 0)//Move All Element From Queue To Stack
            {
                S.Push(Q.Dequeue());//Make Dequeue To All Element In Q And Push Them In Stack
            }

            while(S.Count > 0)
            {
                Q.Enqueue(S.Pop()); //pop All Elemnts From Stack & Enqueue them in Q
            }

        }
        
        static bool IsBalanced(string Input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in Input)//Loop On Input
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if(stack.Count == 0)
                        return false;

                    char Top = stack.Pop();

                    if ((ch == ')' && Top != '(') ||(ch == '}' && Top != '{') ||(ch == ']' && Top != '['))
                        return false;
                }

            }

            return stack.Count == 0;

        }


        static List<int> RemoveDuplicates(int[] arr)
        {
            List<int> result = new List<int>();

            foreach (int num in arr)
            {
                if (!result.Contains(num)) //IF Number Not Exist In List Add It & IF It already in the list don’t do anything
                {
                    result.Add(num);
                }
            }

            return result;
        }

        static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--) //Remove From The End To Preserve The Order
            {
                int num = (int)list[i];

                if (num % 2 != 0)//If Odd
                {
                    list.RemoveAt(i); //Remove
                }
            }
        }

        static List<int> IntersectArrays(int[] arr1, int[] arr2)
        {
            List<int> result = new List<int>();
            List<int> second = new List<int>(arr2); 

            foreach (int num in arr1)//Loop ON array 1 IF Element exist in Array 2 Add it in Result And remove It From Second Array That We convert it to list to can delete from it 
            {
                if (second.Contains(num))
                {
                    result.Add(num);      
                    second.Remove(num);   
                }
            }

            return result;
        }

        static void FindSubListWithSum(ArrayList list, int target)
        {
            for (int i = 0; i < list.Count; i++)//Start OF SubList (For EX: try to start SubList From First Index = 0)
            {
                int sum = 0;

                for (int j = i; j < list.Count; j++)//start from position if i (if i = 0 , j = 0 --> list have first elemnt only , i = 0 , j = 1 --> list have first & second element)
                {
                    int value = (int) list[j];
                    sum += value;

                    if (sum == target)
                    {
                        Console.Write("Sub list: [");
                        for (int k = i; k <= j; k++)
                        {
                            Console.Write(list[k]);
                            if (k < j) //if we don’t at the last position
                                Console.Write(", ");
                        }
                        Console.WriteLine("]");
                        return;//if we find list we don’t need to continue 
                    }
                }
            }

            Console.WriteLine("No sub list found with this sum.");//if all loops finished and list not found
        }

        static void ReverseFirstKElements(Queue<int> queue, int k)
        {
            if (queue == null || k <= 0 || k > queue.Count)
            {
                Console.WriteLine("Invalid value of K.");
                return;
            }

            Stack<int> stack = new Stack<int>();

            //Put Element On Stack From start to k
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());//Make Dequeue from Q then Push To Stack
            }

            //return them again to the queue so they return reversed
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            
            int remaining = queue.Count - k;//elemnts after k remain as them
            for (int i = 0; i < remaining; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        static void Main()
        {
            #region Question 1
            //The Reason OF Biggest time complexity of Bubble Sort --> Because it make more comparisons also after order it continue compare elements 
            //We Can Optimize it By Detect when it stop swapping so array is sorted and stop it 

            /*
            int [] arr = { 33, 2, 56, 86 };
          

            Console.Write("UnSorted array: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");


            BubbleSort(arr);


            Console.Write("\nSorted array: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            */
            #endregion

            //Question 2 In The previous Assigment

            #region Question 3

            /*
            Console.WriteLine("Enter Size OF Array , Number OF Quesries: ");
            string[] Input = Console.ReadLine().Split();
            int.TryParse(Input[0], out int Size);
            int.TryParse(Input[0], out int Queries);

            Console.WriteLine("Enter Numbers In Array:  ");
            string[] ArrInput = Console.ReadLine().Split();//arrInput --> ["5","11","4"] 
            int[] arr = new int[Size];

            for (int i = 0; i < Size; i++)
            {
                if (!int.TryParse(ArrInput[i], out arr[i]))//  Convert string in ArrInput to int by TryParse , If Convert Failed
                {
                    Console.WriteLine($"Error in element number {i + 1}");//{i+1} --> Bec We Start Count From 1
                    arr[i] = 0;//Convert Failed So Put Default Value 0 To Avoid Program Damage
                }
            }
            Console.WriteLine("Enter Queries: ");
            int[] results = new int[Queries];

            for (int i = 0; i < Queries; i++)
            {
                string queriesInput = Console.ReadLine();
                if (!int.TryParse(queriesInput, out int x))
                {
                    Console.WriteLine("Invalid Query Input");
                    results[i] = 0; ;//Convert Failed So Put Default Value 0 
                    continue;//IF Convert Failed Skip To Next Query
                }

                int count = 0;

                for (int j = 0; j < Size; j++)
                {
                    if (arr[j] > x)
                    {
                        count++;
                    }
                }

                results[i] = count; //Store Result
            }

            Console.WriteLine("Output:");
            for (int i = 0; i < Queries; i++)
            {
                Console.WriteLine(results[i]);
            }

            */

            #endregion

            #region Question 4
            /*
            //palindrome Mean The Numbers Or Letters Same If We Read if from right or left
            Console.WriteLine("Enter Size OF Array");
            int.TryParse(Console.ReadLine(), out var Size);

            Console.WriteLine("Enter Elements: ");
            string[] input = Console.ReadLine().Split();
            int[] arr = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (!int.TryParse(input[i], out arr[i]))
                {
                    Console.WriteLine($"Invalid number at position {i + 1}");
                    arr[i] = 0; //IF Convert Failed Put Default Value
                }
            }

            bool isPalindrome = true;

            for (int i = 0; i < Size / 2; i++) //Compare First Element With Last Element & Second Element With before last element
            {
                if (arr[i] != arr[Size - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
                Console.WriteLine("YES");

            else
                Console.WriteLine("NO");

            */

            #endregion

            #region Question 5

            //Queue (FIFO)
            //Stack (LIFO)
            //So We Can Use Stack To Reverse Elements
            /*
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(1);
            Q.Enqueue(2);
            Q.Enqueue(3);
            Q.Enqueue(4);

            Console.WriteLine("Original Queue: " + string.Join(", ", Q));//string.Join --> Merge All Elements In Collection and convert it to text or string and make split 

            ReverseQueue(Q);

            Console.WriteLine("Reversed Queue: " + string.Join(", ", Q));
            */
            #endregion

            #region Question 6
            /*
            Console.Write("Enter string: ");
            string input = Console.ReadLine();

            if (IsBalanced(input))//true
                Console.WriteLine("Balanced");
            else//false
                Console.WriteLine("Not Balanced");
            */

            #endregion

            #region Quesyion 7
            /*
            int[] numbers = { 10 ,44 ,6 ,7 ,8 ,35 ,33 };

            List<int> newList = RemoveDuplicates(numbers);

            Console.WriteLine("Array after removing duplicates:");
            foreach (int n in newList)
                Console.Write(n + " ");

            */
            #endregion

            #region Question 8
            /*
            ArrayList numbers = new ArrayList() { 12,44,3,7,45,22,909};

            RemoveOddNumbers(numbers);

            Console.WriteLine("List after removing odd numbers:");
            foreach (int n in numbers)
                Console.Write(n + " ");
            */
            #endregion

            #region Question 9
            //We Want To Store Different Data Types So We will Use Non Generics Queue It Will Take Object
            /*
            Queue queue = new Queue(); //Non Generic Queue

            queue.Enqueue(1);       
            queue.Enqueue("Apple");
            queue.Enqueue(5.28);     

            Console.WriteLine("Items in the queue:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region Question 10
            /*
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.Write("Enter the target: ");
            int.TryParse(Console.ReadLine(), out int target);

            int count = 0;
            bool found = false;

            foreach(int num in stack)
            {
                count++;//Stack Not indexed based

                if(num == target)
                {
                    Console.WriteLine($"Target was found successfully and the count = {count}");//Note: First Number We will check is 50 with count = 1 --> bec stack (LIFO)
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Target was not found");
            }
            */
            #endregion

            #region Question 11
            /*
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };

            List<int> intersection = IntersectArrays(arr1, arr2);

            Console.WriteLine("Intersection:");
            foreach (int n in intersection)
                Console.Write(n + " ");

            */
            #endregion

            #region Question 12
            /*
            ArrayList numbers = new ArrayList() { 1, 2, 3, 7, 5 };
            int target = 12;

            FindSubListWithSum(numbers, target);


            */
            #endregion

            #region Question 13
            /*
            Queue<int> queue = new Queue<int>();

            Console.Write("Enter the number of elements in the queue: ");
            int.TryParse(Console.ReadLine(), out int Size);

            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < Size; i++)
            {
                int.TryParse(Console.ReadLine(),out int value);
                queue.Enqueue(value);
            }

            Console.Write("Enter the value of K: ");
            int.TryParse(Console.ReadLine(),out int k);

            ReverseFirstKElements(queue, k);

            Console.WriteLine("Queue after reversing first " + k + " elements:");
            foreach (int item in queue)
            {
                Console.Write(item + " ");
            }
            */
            #endregion
        }
    }
}
