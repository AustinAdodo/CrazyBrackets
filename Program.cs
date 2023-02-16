using System.IO.Pipes;

namespace CrazyBrackets
{
    internal class Program
    {
        //Algorithms like these are extensively used in crytopgrapthy.
        class brackets
        {
            //Crazy Brackets Problem
            public static int[][] GetCombination2(int value, int startWith = -1)
            {
                if (value <= 0)
                    return new int[][] { new int[0] };
                if (startWith < 0)
                    startWith = value - 1;
                List<int[]> solutions = new List<int[]>();
                for (int i = Math.Min(value, startWith); i >= 1; --i)
                    foreach (int[] solution in GetCombination2(value - i, i))
                    {
                        int[] next = new int[solution.Length + 1];
                        Array.Copy(solution, 0, next, 1, solution.Length);
                        next[0] = i;
                        solutions.Add(next);
                    }

                // Or just (if we are allow a bit of Linq)
                //   return solutions.ToArray();
                int[][] answer = new int[solutions.Count][];
                for (int i = 0; i < solutions.Count; ++i) answer[i] = solutions[i];
                return answer;
                //string report = string.Join(Environment.NewLine, result
                //.Select(solution => string.Join(" + ", solution)));
            }
            //output 3 -> [3, 3(Modified), 2 1, 1 2, 1 1 1 ]
            public static List<string> CrazyBrackets(int n) //output 3 -> [((())), (()()), (())(), ()(()), ()()() ]
            {
                List<List<int>> combinations = new List<List<int>>();
                string[] t = new string[] {"()","(())","((()))","(((())))","((((()))))","(((((())))))","((((((()))))))",
            "(((((((())))))))"};
                string[] Modified = new string[] {"()","(())","(()())","(()()())","(()()()())","(()()()()())","(()()()()()())",
            "(()()()()()()())"};
                int[][] result = brackets.GetCombination2(n);
                List<string> answer = new(); answer.Add(t[n - 1]);
                answer.Add(Modified[n - 1]);
                foreach (var row in result)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        answer.Add(t[row[i] - 1]);
                        if (i + 1 <= row.Length - 1 && row[i] != row[i + 1]) { answer.Add(t[row[i] - 1]); answer.Add(t[row[i + 1] - 1]); }
                    }
                }
                return answer;
            }
        }
        static void Main(string[] args)
        {
            List<string> result = brackets.CrazyBrackets(3);
            Console.Write(String.Join(" ", result));
        }
    }
}