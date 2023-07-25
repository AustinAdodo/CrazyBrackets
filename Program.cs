using System.IO.Pipes;

namespace CrazyBrackets
{
    internal class Program
    {
        //Algorithms like these are extensively used in crytopgrapthy.
        class brackets
        {
            //Crazy Brackets Problem.
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
                        if (i + 1 <= row.Length - 1 && row[i] != row[i + 1]) { answer.Add(t[row[i + 1] - 1]); answer.Add(t[row[i] - 1]); }
                        //if (i + 1 <= row.Length - 1 && row[i] != row[i + 1]) { answer.Add(row.Reverse()); }
                    }
                }
                return answer;
            }
            public static List<string> Fizzbuzz(int n)
            {
                List<string> result = new();
                for (int i = 1; i <= n; i++)
                {
                    if (i % 2 == 0) result.Add("Fizz");
                    if (i % 3 == 0) result.Add("Buzz");
                    if (i % 2 == 0 && i % 3 == 0) result.Add("FizzBuzz");
                    else { result.Add(i.ToString()); }
                }
                return result;
            }
        }

        static void Turttle_ham(string[] args)
        {
            string source = Console.ReadLine();
            string target = Console.ReadLine();
            string buffer = string.Empty;
            buffer = source;
            int i = 0;
            List<string> answer = new List<string>();
            while (source != target)
            {
                if (source[i] == target[i]) continue;
                buffer = buffer.Substring(i, i - 0) + target[i] + source.Substring(i, source.Length - i);
                answer.Add(buffer);
                i++;
            }
            Console.WriteLine(string.Join("\n", answer));
        }

        static string Camel_case(string[] args)
        {
            string variableName = Console.ReadLine();
            string result = string.Join("", variableName.Select((a, i) => (variableName[i - 1].ToString() == "_") ? a.ToString().ToUpper() : a.ToString
            ()));
            return result;
        }

        static void participants(string[] args)
        {
            int totalSelectedparticipants = 0;
            int TotalPonts = 0;
            List<List<int>> queries = new List<List<int>>();
            List<int> PointsArr = new List<int>();
            int N = int.Parse(Console.ReadLine());
            int P = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                for (int j = 0; j < P; j++)
                {
                    int points = int.Parse(inputs[j]);
                    PointsArr.Add(points);
                }
                queries.Add(PointsArr);
            }
            foreach (List<int> item in queries)
            {
                int temp = 0;
                temp = item.Where(a => a == item.Max()).Count();
                TotalPonts += (temp * item.Max());
                totalSelectedparticipants += temp;
            }
            Console.WriteLine(totalSelectedparticipants + " " + TotalPonts);
        }
        static void Main(string[] args)
        {
            Console.Write(String.Join(" ", brackets.Fizzbuzz(15)));
        }
    }
}