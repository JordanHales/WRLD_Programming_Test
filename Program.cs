using System;
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
                    nodeList = app.GetData();
                    // Displays the amount of nodes
                    Console.WriteLine("Data collected. There are a total of " + nodeList.Count + " points on the map.");
                    Node mostIsolatedPoint = app.GetMostIsolated(nodeList);


                    Console.WriteLine(mostIsolatedPoint.name);
                    Console.ReadKey();
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

        List<Node> GetData()
        {
            var nodeList = new List<Node>();
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
                    nodeList.Add(new Node() { name = tempNode.name , position = new Vector2(tempNode.position.x, tempNode.position.y) });
                    i = 0;
                }

                i++;
            }

            // ###DEBUG###
            //for (int t = 0; t < nodeList.Count; t++)
            //{
            //    Console.WriteLine(nodeList[t].name + " " + nodeList[t].position.x + " " + nodeList[t].position.y);
            //}

            return nodeList;
        }

        Node GetMostIsolated(List<Node> nodeList)
        {
            // Variables for calculations
            Console.WriteLine("1");
            Node mostIsolated = new Node();
            float closestTotalDistance = 0.0f;
            bool lastNodeMostIsolated = true;

            // Variables for tracking the percentage of calculations complete
            double currentComparison = 0.0d;
            double totalComparisons = 0.0d;
            double percentageTracker = 0.0d;
            int percentageDisplay = 0;
            
            // Figure out the total number of comparisons needed to make to figure out the most isolated node
            for (int i = nodeList.Count; i > 0; i--)
            {
                totalComparisons += i;
            }

            // Loops through each node and calculates the closest node, skipping distances that have already been calculated
            for (int i = 0; i < nodeList.Count - 1; i++)
            {
                // Sets the closest node to be the max distance away
                float closestCurrentDistance = 340282300000000000000000000000000000000f;

                // Compares the current node to all remaining nodes
                for (int j = i + 1; j < nodeList.Count; j++)
                {
                    // Calculates what percentage of nodes have been compared
                    currentComparison++;
                    percentageTracker = (currentComparison / totalComparisons) * 100;
                    percentageTracker = Math.Floor(percentageTracker);
                    
                    // If the percentage has gone up by a whole number, display this to the user
                    if (Convert.ToInt32(percentageTracker) != percentageDisplay)
                    {
                        percentageDisplay = Convert.ToInt32(percentageTracker);
                        Console.WriteLine("The current progress is " + percentageDisplay + "% complete.");
                    }
                    
                    float distance = nodeList[i].CalculateDistance(nodeList[j]);

                    // If the current calculated distance between selected nodes is closer than the closest distance
                    // for the first node and another node, set the distance between the two current nodes
                    // to be the closest distance
                    if (distance < closestCurrentDistance)
                    {
                        closestCurrentDistance = distance;

                        // If the node is not comparing against the first or last node in the list
                        // then the last node in the list will not be the most isolated
                        if (lastNodeMostIsolated)
                        {
                            if (j != i + 1 || j != nodeList.Count)
                            {
                                lastNodeMostIsolated = false;
                            }
                        }
                    }
                }
                
                // If this node is the most isolated, record this node and update variables
                if (closestCurrentDistance > closestTotalDistance)
                {
                    closestTotalDistance = closestCurrentDistance;
                    mostIsolated = nodeList[i];
                }
            }

            // If the last comparison was always the furthest distance, this means the last node in the list was the most isolated
            if (lastNodeMostIsolated)
            {
                mostIsolated = nodeList[nodeList.Count - 1];
            }

            Console.WriteLine("2");
            Console.WriteLine(mostIsolated.position.x);

            return mostIsolated;
        }
    }
}
