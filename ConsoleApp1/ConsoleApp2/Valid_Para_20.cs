using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Valid_Para_20
    {
        string s = "()[]{}";
        Stack<char> parentheses_stack = new Stack<char>();

        public bool get_result() 
        {
            Dictionary<char, char> bracketMap = new Dictionary<char, char>
            {
                { '{', '}'},
                { '(', ')'},
                { '[', ']'},
            };

            Stack<char> openBrackets = new Stack<char>();

            foreach (char bracket in s)
            {
                if (bracketMap.ContainsKey(bracket)) 
                {
                    Console.WriteLine(bracket);
                    openBrackets.Push(bracket);
                }
            
            }
            

            return parentheses_stack.Count() == 0;
        }
        /**
        foreach (char c in s)
        {
           parentheses_r.ToString();
        }
        **/
    }
}
