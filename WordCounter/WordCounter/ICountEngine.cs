using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public interface ICountEngine
    {
        // Load input statement before processing it
        // in case of future changes of requirement, 
        // maybe user would like to load input from a file or other places,
        // we could add other funtions here for example: LoadInputFromFile, LoadInputFromWeb ...
        void LoadInputStatementFromArgs(string[] args);

        // Process the input statement to count occourance of words
        void ProcessStatement();

        // Currently uutput result to console, in the future, if we want to output to other places,
        // we could add other funtion for example: OutputResultToFile, OutputResultToEmail ...
        void OutputResultToConsole();

    }
}
