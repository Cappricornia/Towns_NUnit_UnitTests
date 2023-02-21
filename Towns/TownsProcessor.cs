using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Towns
{
    public class TownsProcessor
    {
        private TownsCollection towns;

        public TownsProcessor()
        {
            towns = new TownsCollection();
        }

        public IReadOnlyCollection<string> Towns => towns.Towns.AsReadOnly();

        public string ExecuteCommand(string commandLine)
        {
            int spaceIndex = commandLine.IndexOf(" ");
            string cmdArgs = string.Empty;
            string command;

            if (spaceIndex != -1)
            {
                cmdArgs = commandLine.Substring(spaceIndex + 1);
                command = commandLine.Substring(0, spaceIndex);
            }
            else
            {
                command = commandLine;
            }

            return GetResult(cmdArgs, command);
        }

        private string GetResult(string cmdArgs, string command)
        {
            if (command == "CREATE")
            {
                towns = new TownsCollection(cmdArgs);
                return "Successfully created collection of towns.";
            }
            else if (command == "PRINT")
            {
                return $"Towns: {towns}";
            }
            else if (command == "ADD")
            {
                bool added = towns.Add(cmdArgs);
                if (added)
                    return $"Successfully added: {cmdArgs}";
                else
                    return $"Cannot add: {cmdArgs}";
            }
            else if (command == "REMOVE")
            {
                try
                {
                    int index = int.Parse(cmdArgs);
                    towns.RemoveAt(index);
                    return $"Successfully removed from index: {index}";
                }
                catch
                {
                    return "Invalid operation.";
                }
            }
            else if (command == "REVERSE")
            {
                try
                {
                    towns.Reverse();
                    return "Collection of towns reversed.";
                }
                catch (ArgumentNullException)
                {
                    return "Cannot reverse a null collection of towns.";
                }
                catch (InvalidOperationException)
                {
                    return "Cannot reverse a collection of towns with less than 2 items.";
                }
            }
            else
            {
                return $"Invalid command: {command}";
            }
        }
    }
}
