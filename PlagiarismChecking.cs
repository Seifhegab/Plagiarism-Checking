using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class PlagiarismChecking
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given an UNDIRECTED Graph of matching pairs and a query pair, find the min number of connections between the nodes of the given pair (if any)
        /// </summary>
        /// <param name="edges">array of matching pairs</param>
        /// <param name="query">query pair</param>
        /// <returns>min number of connections between the nodes of the query pair (if any)</returns>
        public static int CheckPlagiarism(Tuple<string, string>[] edges, Tuple<string, string> query)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            Dictionary<string, List<string>> adjacent = new Dictionary<string, List<string>>();
            foreach (Tuple<string, string> edge in edges)
            {
                if (adjacent.ContainsKey(edge.Item1) == true)
                {

                }
                else
                {
                    adjacent[edge.Item1] = new List<string>();
                }
                adjacent[edge.Item1].Add(edge.Item2);
            }

            string source = query.Item1;
            string destination = query.Item2;
            Dictionary<string, int> distance = new Dictionary<string, int>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(source);
            distance[source] = 0;
            string vertex = "";
            int n = 0;
            while (queue.Count != 0)
            {
                vertex = queue.Dequeue();
                if (vertex == destination)
                    break;

                if (adjacent.ContainsKey(vertex))
                {
                    foreach (string side in adjacent[vertex])
                    {
                        if (distance.ContainsKey(side) == true)
                        {

                        }
                        else
                        {
                            distance[side] = distance[vertex] + 1;
                            queue.Enqueue(side);
                        }
                    }
                }

                if (queue.Count == 0)
                {
                    n = 1;
                }
            }

            string source1 = query.Item2;
            string destination1 = query.Item1;
            Dictionary<string, int> distance1 = new Dictionary<string, int>();
            Queue<string> queue1 = new Queue<string>();
            queue1.Enqueue(source1);
            distance1[source1] = 0;
            string vertex1 = "";
            int n1 = 0;
            while (queue1.Count != 0)
            {
                vertex1 = queue1.Dequeue();
                if (vertex1 == destination1)
                    break;

                if (adjacent.ContainsKey(vertex1))
                {
                    foreach (string side1 in adjacent[vertex1])
                    {
                        if (distance1.ContainsKey(side1) == true)
                        {

                        }
                        else
                        {
                            distance1[side1] = distance1[vertex1] + 1;
                            queue1.Enqueue(side1);
                        }
                    }
                }

                if(queue1.Count == 0)
                {
                    n1 = 1;
                }
            }

            if (n == 1 && n1 == 1)
            {
                return 0;
            }
            else if(n == 0 && n1 == 0)
            {
                return Math.Min(distance[vertex], distance1[vertex1]);
            }   
            else if (n == 1 && n1 == 0)
            {
                return distance1[vertex1];
            }
            else if (n == 0 && n1 == 1)
            {
                return distance[vertex];
            }

            return 0;
        }
        #endregion
    }
}
