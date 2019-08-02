﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WRLD_Programming_Test
{

    class Program
    {
        string filepath = "";

        static void Main(string[] args)
        {
            Program app = new Program();
            bool exit = false;

            //Loop the main body until the user wants to quit the application
            while (!exit)
            {
                // If the file the user requets exists, analyze the data
                if (app.CheckForFile())
                {
                    var nodeList = new List<Node>();
                    app.GetData(nodeList);
                }

                // Otherwise exit the application
                else
                {
                    exit = true;
                }
            }
        }
        

        bool CheckForFile()
        {
            // Intro message
            Console.WriteLine("Welcome to the map analyzer. This program allows the user to enter data and find the most isolated point on a map.");
            Console.WriteLine("Please enter the name of the file you wish to gather data from:");

            // Get the filepath from user input and add ".txt" to the input
            filepath = Console.ReadLine();
            filepath = filepath + ".txt";
            FileInfo file = new FileInfo(filepath);

            // Check if the file exists
            if (!file.Exists)
            {
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "The file declared was not found. Press any key to exit the application.");
                Console.ReadKey();
                return false;
            }

            else
            {
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "The file declared was found. Reading data...");
                return true;
            }
        }

        void GetData(List<Node> nodeList)
        {
            var fileContent = File.ReadAllText(filepath);
            var array = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

            int i = 1;
            Node tempNode = new Node();


            foreach (string line in array)
            {
                // Decides what section of the data the text represents
                if (i == 1)
                {
                    tempNode.name = line;
                }
                else if (i == 2)
                {
                    tempNode.position.x = float.Parse(line);
                }
                else if (i == 3)
                {
                    tempNode.position.y = float.Parse(line);

                    // Adds node to the list and sets the data to be entered into a new node
                    nodeList.Add(tempNode);
                    i = 0;
                }

                i++;
            }

            // Keep the console window open in debug mode.
            Console.WriteLine(nodeList.Count);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
