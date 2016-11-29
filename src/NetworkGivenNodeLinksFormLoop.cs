using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LinkedNodesKata
{
    public class NetworkGivenNodeLinksFormLoop : Network
    {
        public NetworkGivenNodeLinksFormLoop()
            : base()
        {
            LinkX.FirstNode = Node1;
            LinkX.SecondNode = Node2;

            LinkY.FirstNode = Node2;
            LinkY.SecondNode = Node3;

            LinkZ.FirstNode = Node3;
            LinkZ.SecondNode = Node4;

            LinkA.FirstNode = Node4;
            LinkA.SecondNode = Node1;
        }

        [Fact]
        public void ThenSecondNodeOfLastLinkShouldBeEqualToFirstNodeOfFirstLink()
        {
            var lastLink = GetLastLink(LinkX.Id, LinkX);

            Assert.NotNull(lastLink);
            Assert.Equal(lastLink.SecondNode, LinkX.FirstNode);
        }

        private Link GetLastLink(Guid startingLinkId, Link link)
        {
            var nextLink = _links.SingleOrDefault(l => l.Id != startingLinkId && l.FirstNode == link.SecondNode);
            if (nextLink == null)
                return link;

            return GetLastLink(startingLinkId, nextLink);
        }
    }

    public class NetworkGivenFiveNodesFormLoop : Network
    {
        protected Node Node5 { get; private set;}
        protected Link LinkFromNode2ToNode5 { get; private set; }

        public NetworkGivenFiveNodesFormLoop()
            : base()
        {
            LinkX.FirstNode = Node1;
            LinkX.SecondNode = Node2;

            LinkY.FirstNode = Node2;
            LinkY.SecondNode = Node3;

            LinkZ.FirstNode = Node3;
            LinkZ.SecondNode = Node4;

            LinkA.FirstNode = Node4;
            LinkA.SecondNode = Node1;

            Node5 = new Node("Node 5");
            LinkFromNode2ToNode5 = new Link();
            LinkFromNode2ToNode5.FirstNode = Node2;
            LinkFromNode2ToNode5.SecondNode = Node5;
            _links.Add(LinkFromNode2ToNode5);
        }

        [Fact]
        public void ThenAllNodesShouldBeReachableFromAnyNode()
        {
            ThenAllNodesShouldBeReachable(Node1);
            ThenAllNodesShouldBeReachable(Node2);
            ThenAllNodesShouldBeReachable(Node3);
            ThenAllNodesShouldBeReachable(Node4);
            ThenAllNodesShouldBeReachable(Node5);
        }

        public IEnumerable<Node> GetAllReachableNodes(Node node, List<Guid> visitedNodeIds)
        {          
            if (node == null)
                yield break;

            visitedNodeIds.Add(node.Id);
            
            foreach (var firstGenerationNode in GetLinkNodes(node.AllLinks))
            {
                if(visitedNodeIds.Contains(firstGenerationNode.Id))
                    continue;

                yield return firstGenerationNode;

                foreach(var secondGenerationNode in GetAllReachableNodes(firstGenerationNode, visitedNodeIds))
                {
                    yield return secondGenerationNode;
                }
            }
        }

        private IEnumerable<Node> GetLinkNodes(IEnumerable<Link> links)
        {
            foreach(var link in links)
            {
                if(link.FirstNode != null)
                    yield return link.FirstNode;

                if(link.SecondNode != null)
                    yield return link.SecondNode;
            }
        }

        private void ThenAllNodesShouldBeReachable(Node nodeToAssert)
        {
            var reachableNodes = GetAllReachableNodes(nodeToAssert, new List<Guid>()).ToList();
            reachableNodes.Add(nodeToAssert);

            Assert.Equal(5, reachableNodes.Count());
            Assert.True(reachableNodes.Contains(Node1));
            Assert.True(reachableNodes.Contains(Node2));
            Assert.True(reachableNodes.Contains(Node3));
            Assert.True(reachableNodes.Contains(Node4));
            Assert.True(reachableNodes.Contains(Node5));
        }
    }
}