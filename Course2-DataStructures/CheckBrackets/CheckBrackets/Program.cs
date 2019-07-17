using System;
using System.Collections.Generic;

namespace CheckBrackets
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var charArray = input.ToCharArray();

            bool result = IsBalanced(charArray);

            if (result == true)
            {
                Console.WriteLine("Success");
            }

        }

        public static bool IsBalanced(char[] arr)
        {
            
            Stack<BracketIndex> stack = new Stack<BracketIndex>();
            int pos = 0;

            foreach (char ch in arr)
            {
                pos++;

                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(new BracketIndex(ch, pos));
                }
                else if(ch == ')' || ch == '}' || ch == ']')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine(pos);
                        return false;
                    }

                    BracketIndex top = stack.Pop();

                    if ((top.Brac == '(' && ch != ')') || (top.Brac == '[' && ch != ']') || (top.Brac == '{' && ch != '}'))
                    {
                        Console.WriteLine(pos);
                        return false;
                    }
                }
            }

            if(stack.Count > 0){
                Console.WriteLine(stack.Peek().Index);
            }

            return (stack.Count == 0);
        }
    }

    public class BracketIndex{
        public BracketIndex(char bracket, int index)
        {
            this.Brac = bracket;
            this.Index = index;
        }

        public char Brac { get; set; }

        public int Index { get; set; }
    }
}
