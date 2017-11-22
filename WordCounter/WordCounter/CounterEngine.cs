using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter
{
    public class CounterEngine : ICountEngine
    {
        // singlton 
        private static CounterEngine _instance;
        public static CounterEngine Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CounterEngine();
                }
                return _instance;
            }
        }

        // for store all the word's occourance in a statement
        public Dictionary<string, int> WordCountDictionary { get; set; }
        public string InputStatement { get; set; }

        public CounterEngine()
        {
            WordCountDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        /// Load input statement from args
        /// </summary>
        /// <param name="args"></param>
        public void LoadInputStatementFromArgs(string[] args)
        {
            if(args.Length > 0)
            {
                InputStatement = args[0];
            }
            else
            {
                throw new ArgumentException("Input args length is 0.");
            }
        }

        /// <summary>
        /// Process the statement to count word occourance
        /// </summary>
        /// <param name="inputStr"></param>
        public void ProcessStatement()
        {
            if(this.InputStatement != null)
            {
                // clean up the dictionary
                WordCountDictionary.Clear();

                string[] words = this.InputStatement.Split(' ');
                foreach (var item in words)
                {
                    string word = item.ToLower();
                    if(IsValid(word)) // make sure the item is a word
                    {
                        if(this.WordCountDictionary.ContainsKey(word) == true)
                        {
                            this.WordCountDictionary[word]++;
                        }
                        else
                        {
                            this.WordCountDictionary.Add(word, 1);
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("InputStr is null.");
            }
        }


        /// <summary>
        /// Output the result to console
        /// </summary>
        public void OutputResultToConsole()
        {
            Console.WriteLine("Word Count Result:");
            foreach (var item in this.WordCountDictionary.Keys)
            {
                Console.WriteLine("{0}-{1}", item, this.WordCountDictionary[item]);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// check if a str is a word
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValid(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }


    }
}
