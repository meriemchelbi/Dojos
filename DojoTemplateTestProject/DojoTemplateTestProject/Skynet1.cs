using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class Skynet1
    {
        [Fact]
        public void SeveralPaths()
        {
            var nodes = 4;
            var links = 4;
            var gatweays = 4;

            var result = KillTheVirus(nodes, links, gatweays);

            Assert.Equal("2 3", result);
        }
        
        [Fact]
        public void CanBuildGraph()
        {
            var standinput = new Queue<string>(new[]
            {
                "4 4 4",
                "1 3",
                "2 3",
                "0 1",
                "0 2",
                "3",
                "0"
           });

            Func<string> readLine = () => standinput.Dequeue();

            var initialInputs = readLine().Split(' ');

            var noOfLinks = int.Parse(initialInputs[1]);
            var skynet = new Graph();

            for (int i = 0; i < noOfLinks; i++)
            {
                var link = readLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                skynet.AddLink(node1, node2);
            }

            var wibble = "blurb";
            
        }

        class Graph
        {
            public List<(int,int)>  Links { get; set; }
            public List<Node>  Nodes { get; set; }

            public Graph()
            {
                Links = new List<(int, int)>();
                Nodes = new List<Node>();
            }

            public void AddLink(int nodeId1, int nodeId2)
            {
                if (Nodes.Exists(n => n.Id == nodeId1) == false)
                    Nodes.Add(new Node(nodeId1));
                
                if (Nodes.Exists(n => n.Id == nodeId2) == false)
                    Nodes.Add(new Node(nodeId2));
                
                Links.Add((nodeId1, nodeId2));
            }
        }

        class Node
        {
            public int Id { get; set; }

            public Node(int id)
            {
                Id = id;
            }
        }

        private string KillTheVirus(int nodes, int links, int gatweays)
        {
            throw new NotImplementedException();
        }
    }
}
