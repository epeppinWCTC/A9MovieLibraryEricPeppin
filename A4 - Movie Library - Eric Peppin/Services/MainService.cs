using System;
using System.Collections.Generic;
using System.Threading.Channels;
using A4___Movie_Library___Eric_Peppin.Data;
using A4___Movie_Library___Eric_Peppin.Models;

namespace A4___Movie_Library___Eric_Peppin.Services
{
    public class MainService : IMainService
    {
        private readonly char _exitKey = 'X';
        private readonly List<char> _validChars = new List<char> { '1' };

        public void Invoke()
        {
            var orchestrator = new OrchestratorService();
            var returnKey = _exitKey;
            
            do
            {
                Console.WriteLine("1. Search Titles");
                //Console.WriteLine("2. List Shows");
                // Console.WriteLine("3. List Videos");
                //Console.WriteLine("2. Add Movie");
                returnKey = GetMenuSelection();
                if (returnKey == '1')
                {
                    
                    Console.WriteLine();
                    Console.WriteLine("Enter Search Term");
                    var searchTerm = Console.ReadLine();
                    var results = orchestrator.SearchAllMedia(searchTerm);
                    Console.WriteLine("Your Results are:");
                    results.ForEach(Console.WriteLine);
                    results.Clear();

                }
            } while (returnKey != _exitKey);
        }

        public char GetMenuSelection()
        {
            Console.Write($"Select ({_validChars[0]},{_exitKey})>");
            var key = Console.ReadKey().KeyChar;
            while (Equals(!_validChars.Contains(key)))
            {
                if (key == _exitKey || char.ToLower(key) == char.ToLower(_exitKey))
                {
                    break;
                }

                Console.WriteLine($"Invalid, Please select {_validChars[0]}, {_validChars[1]}, {_exitKey}> ");
                key = Console.ReadKey().KeyChar;
            }
            return key;
        }

    }
}