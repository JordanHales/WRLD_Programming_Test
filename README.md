# WRLD_Programming_Test
 Test application for a software developer position at WRLD3D by Jordan Hales

# Instructions
1. Ensure that a suitable text file is located in the folder along with the executable in the "Release" folder.
2. Run the executable file.
3. Type in the name of the text file (e.g. "problems_big") and press enter.
4. Wait for the program to finish calculating the most isolated point which will then be displayed to you.

# Explanation
 This program is written in C# and takes input from a text file. These inputs are points on a 2D map (x and y coordinates). The purpose of this program is to calculate the most isolated point from the given data.

This program currently stores the points as a "node" class. These nodes have a name, position and closeset node distance, as well as a function for calculating the distance to another node. The program will loop through every node and calculate the distance between every other node, with the most isolated node having the largest distance from any other node.

Since calculating the distance between two nodes gives a distance for both the nodes, there is no need to compare every node to every other node, as some distances have already been calculated. When a distance is calculated, the program looks at the nodes closest node distance variable. If the distance is smaller (i.e. closer) than the previously stored closest node, this variable is overwritten with the new calculated distance. This results in having an algorithm that performs better than O(n^2).

# Research
This algorithm could be improved upon with the us of a k-d tree. This splits the points into different sections and eventually constructs a binary tree of points. After this tree has been constructed, the distances can be found by moving down the tree and checking the distance from there. Finding the nearest neighbour for a node is an O(log n) operation on average.

Although this would have been the preffered method, there was trouble implementing the method due to a lack of experience working with them. A note that came with the task was that it would be able to be completed in an evening. This method was worked on for a rough estimate of 10 hours with a lot of progress still to be achieved, so this algorithm was replaced in order to make best use of the time given.

