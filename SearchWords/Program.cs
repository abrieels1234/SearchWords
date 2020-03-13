using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchWords
{

    static class Program
    {

        readonly static int nRows = 5;
        readonly static int nCols = 5;
        readonly static int gridSize = nRows * nCols;
        readonly static int minWords = 25;
        static string[] lines = new string[1];
        readonly static Random rand = new Random();
        static int n = lines.Length;
        static readonly int M = 5, N = 5;
        static void Main(string[] args)
        {
            lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\TextFile\words.txt", Encoding.UTF8);
            var gridSize = 5;
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rand = new Random();
            var grid = Enumerable.Range(0, gridSize)
                .Select(c => new String(
                    Enumerable.Range(0, gridSize)
                    .Select(d => alphabet[rand.Next(0, alphabet.Length)])
                    .ToArray()
                )).ToArray();
            char[,] Letters = new char[5, 5];
            int count = 0;
            foreach (string Line in grid)
            {
                //count = 0;
                Letters[count, 0] = Convert.ToChar(Line.Substring(0, 1));               
                Letters[count, 1] = Convert.ToChar(Line.Substring(1, 1));               
                Letters[count, 2] = Convert.ToChar(Line.Substring(2, 1));                
                Letters[count, 3] = Convert.ToChar(Line.Substring(3, 1));                
                Letters[count, 4] = Convert.ToChar(Line.Substring(4, 1));
                count++;
                Console.WriteLine(Line);
            }

            SearchWords(Letters);
        }

        static bool isWord(String str)
        {

            for (int i = 0; i < n; i++)
                if (str.Equals(lines[i]))
                    return true;
            return false;
        }


        static void SearchWordsUtil(char[,] AllChar, bool[,] visited,
                                  int i, int j, String str)
        {

            visited[i, j] = true;
            str = str + AllChar[i, j];

            if (isWord(str))
                Console.WriteLine(str);

            for (int row = i - 1; row <= i + 1 && row < M; row++)
                for (int col = j - 1; col <= j + 1 && col < N; col++)
                    if (row >= 0 && col >= 0 && !visited[row, col])
                        SearchWordsUtil(AllChar, visited, row, col, str);

            str = "" + str[str.Length - 1];
            visited[i, j] = false;
        }


        static void SearchWords(char[,] Characters)
        {

            bool[,] visited = new bool[M, N];
            String str = "";
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    SearchWordsUtil(Characters, visited, i, j, str);
        }


    }

}



