using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class Skynet1
    {
        [Fact]
        public void CanBuildGraph()
        {
            var standinput = new Queue<string>(new[]
            {
                "4 4 1", // no of nodes, no of links, no of gateways
                "1 3", // node 1 is linked to node 3
                "2 3", // node 2 is linked to node 3
                "0 1", // node 0 is linked to node 1
                "0 2", // node 0 is linked to node 2
                "3", // index of gateway node (each new gateway node is provided as a separate input/line
                "0" // position of agent
           });

            Func<string> readLine = () => standinput.Dequeue();

            var initialInputs = readLine().Split(' ');
            var skynet = new Graph();

            var noOfNodes = int.Parse(initialInputs[0]);
            skynet.AddNodes(noOfNodes);

            var noOfLinks = int.Parse(initialInputs[1]);
            for (int i = 0; i < noOfLinks; i++)
            {
                var link = readLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                skynet.AddLink(node1, node2);
            }

            var noOfGateways = int.Parse(initialInputs[2]);
            for (int i = 0; i < noOfGateways; i++)
            {
                var gatewayIndex = int.Parse(readLine());
                skynet.Nodes[gatewayIndex].IsGateway = true;
            }

            var virus = new Virus();
            var virusPosition = int.Parse(readLine());
            virus.CurrentPosition = skynet.Nodes[virusPosition];
        }

        class Graph
        {
            public List<(int,int)>  Links { get; set; }
            public List<Node> Nodes { get; set; }
            public Virus Virus { get; set; }

            public Graph()
            {
                Links = new List<(int, int)>();
                Nodes = new List<Node>();
            }

            public void AddLink(int firstNodeId, int secondNodeId)
            {
                var nodeA = Nodes[firstNodeId];
                var nodeB = Nodes[secondNodeId];

                Links.Add((firstNodeId, secondNodeId));

                if (!nodeA.Neighbours.Exists(n => n == nodeB))
                    nodeA.Neighbours.Add(nodeB);
                
                if (!nodeB.Neighbours.Exists(n => n == nodeA))
                    nodeB.Neighbours.Add(nodeA);
            }

            public void AddNodes(int noOfNodes)
            {
                // Node ID must correspond to the node's index in the Nodes collection
                for (int i = 0; i < noOfNodes; i++)
                    Nodes.Add(new Node(i));
            }

            // TODO Refactor BuildGraph to take in specific inputs
            public void BuildGraph(string[] args)
            {
                string[] inputs;
                
                inputs = Console.ReadLine().Split(' ');

                var noOfNodes = int.Parse(inputs[0]);
                AddNodes(noOfNodes);
                Console.Error.WriteLine($"No of nodes: {noOfNodes}");

                var noOfLinks = int.Parse(inputs[1]);
                Console.Error.WriteLine($"No of Links: {noOfLinks}");

                var noOfGateways = int.Parse(inputs[2]);
                Console.Error.WriteLine($"No of gateways: {noOfGateways}");

                for (int i = 0; i < noOfLinks; i++)
                {
                    var link = Console.ReadLine().Split(' ');
                    var node1 = int.Parse(link[0]);
                    var node2 = int.Parse(link[1]);
                    AddLink(node1, node2);
                    Console.Error.WriteLine($"Nodes {node1} and node {node2} are linked");
                }

                for (int i = 0; i < noOfGateways; i++)
                {
                    var gatewayIndex = int.Parse(Console.ReadLine());
                    Nodes[gatewayIndex].IsGateway = true;
                    Console.Error.WriteLine($"Gateway index: {gatewayIndex}");
                }

                Virus = new Virus();
            }
        }

        class Node
        {
            public int Id { get; set; }
            public List<Node> Neighbours { get; set; }
            public bool IsGateway { get; set; }

            public Node(int id)
            {
                Id = id;
                Neighbours = new List<Node>();
            }
        }

        class Virus
        {
            public Node CurrentPosition { get; set; }
            
            public int GetCurrentPosition()
            {
                return int.Parse(Console.ReadLine());
            }
        }

        // TODO introduce GetInput method that splits the input into component parts.
        // Change BuildGraph to take these inputs, and KillTheVirus to take the graph as single argument
        // That way, you can bypass GetInput in your tests and just new up a collection
        private static string KillTheVirus(string[] args)
        {
            var skynet = new Graph();
            skynet.BuildGraph(args);

            while (true)
            {
                var virusPosition = skynet.Virus.GetCurrentPosition();
                skynet.Virus.CurrentPosition = skynet.Nodes[virusPosition];
                Console.WriteLine("2 3");
            }
        }

    }
}
