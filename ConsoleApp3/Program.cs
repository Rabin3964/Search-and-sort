using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
namespace prog
{
    public class Rabin
    {
        public int[] arr = { 2, 3, 6, 10, 40 };
        public int x = 10;
    }
    class Linearsearch
    {
        public static int search(int[] arr, int x)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                    return i;
            }
            return -1;
        }
        public  void linear()
        {
            Rabin r = new Rabin();
            Stopwatch sw = Stopwatch.StartNew();
           
           
            int result = search(r.arr,r.x);
            if (result == -1)
                Console.WriteLine("not present ");
            else
                Console.WriteLine("Number " + r.x + " is present and is in index  " + result);
            sw.Stop();
            Console.WriteLine("Time taken by LinearSearch is: {0} milli", sw.Elapsed.TotalMilliseconds);
        }

    }
    class binaraysearch
    { 
    static int bs(int[] arr,int l,int r,int x)
        {
           
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;

                if (arr[mid] > x)
                    return bs(arr, l, mid - 1, x);

                
                return bs(arr, mid + 1, r, x);
            }
                return -1;
        }
        public  void binary()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Rabin r = new Rabin();
            int n = r.arr.Length;
            
            int result = bs(r.arr, 0, n - 1, r.x);
            Console.WriteLine();
            if (result==-1)
                Console.WriteLine("not present ");
            else Console.WriteLine("Number " + r.x + " is present and is in index " +result);
            sw.Stop();
            
            Console.WriteLine("Time taken by BinaraySearch is: {0} milli", sw.Elapsed.TotalMilliseconds);

        }
    }

        class JumpSearch
    {
        public static int jumpsearch(int[] arr, int x)
        {
            int n = arr.Length;


            int step = (int)Math.Floor(Math.Sqrt(n));

            int prev = 0;
            while (arr[Math.Min(step, n) - 1] < x)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (arr[prev] < x)
            {
                prev++;

                
                if (prev == Math.Min(step, n))
                    return -1;
            }

       
            if (arr[prev] == x)
                return prev;

            return -1;
        }

        
        public  void Jump()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Rabin r = new Rabin();
           

            Console.WriteLine("");
            int index = jumpsearch(r.arr, r.x);

           
            Console.Write("Number " + r.x +" is present and  is at index " + index);
            sw.Stop();
            Console.WriteLine("");
            Console.WriteLine("Time taken by JumpSearch is: {0} milli", sw.Elapsed.TotalMilliseconds);
        }
    }

    class Program
    {
       static void Main()
        {
            Linearsearch ls = new Linearsearch();
            binaraysearch b = new binaraysearch();
            JumpSearch j = new JumpSearch();


            ls.linear();
            b.binary();
            j.Jump();

            Console.ReadLine();
        }
    }
}