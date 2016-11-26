using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LinkedNodesKata
{
    public abstract class Network
    {
        // Based on https://raw.githubusercontent.com/danpadmore/LinkedNodeKata/master/doc/kata-linked-node-whiteboard.jpg
        private readonly List<Link> _links;

        protected Node Node1 { get; private set;}
        protected Node Node2 { get; private set;}
        protected Node Node3 { get; private set;}
        protected Node Node4 { get; private set;}
        protected Link LinkX { get; private set; }
        protected Link LinkY { get; private set; }
        protected Link LinkZ { get; private set; }
        protected Link LinkA { get; private set; }
        protected Link LinkB { get; private set; }

        public Network()
        {
            Node1 = new Node("Node1");
            Node2 = new Node("Node2");
            Node3 = new Node("Node3");
            Node4 = new Node("Node4");
            LinkX = new Link();
            LinkY = new Link();
            LinkZ = new Link();
            LinkA = new Link();
            LinkB = new Link();

            _links = new List<Link>();
            _links.Add(LinkX);
            _links.Add(LinkY);
            _links.Add(LinkZ);
            _links.Add(LinkA);
            _links.Add(LinkB);
        }

        public IEnumerable<Node> GetUniqueReachableNodes(Guid startingLinkId, Link link)
        {
            return GetAllReachableNodes(startingLinkId, link)
                .Distinct();
        }

        private IEnumerable<Node> GetAllReachableNodes(Guid startingLinkId, Link link)
        {
            if(link.FirstNode != null)
                yield return link.FirstNode;

            if(link.SecondNode != null)
                yield return link.SecondNode;

            var linkedLinks = _links.Where(l => l.Id != startingLinkId && l.Id != link.Id 
                && (l.FirstNode == link.FirstNode
                || l.FirstNode == link.SecondNode
                || l.SecondNode == link.FirstNode
                || l.SecondNode == link.SecondNode));

            foreach (var linkedLink in linkedLinks)
            {
                foreach(var node in GetAllReachableNodes(startingLinkId, linkedLink))
                {
                    yield return node;
                }
            }
        }
    }

    public class NetworkGivenAllNodesLinked : Network
    {
        public NetworkGivenAllNodesLinked()
            : base()
        {
            LinkX.FirstNode = Node1;
            LinkX.SecondNode = Node2;

            LinkA.FirstNode = Node1;
            LinkA.SecondNode = Node4;
        }

        [Fact]
        public void ThenFromAnyNodeAllOtherNodesShouldBeReachable()
        {
            var reachableNodesFromLinkX = GetUniqueReachableNodes(LinkX.Id, LinkX).ToList();
            Assert.Equal(3, reachableNodesFromLinkX.Count());
            Assert.True(reachableNodesFromLinkX.Any(n => n.Id == Node1.Id));
            Assert.True(reachableNodesFromLinkX.Any(n => n.Id == Node2.Id));
            Assert.True(reachableNodesFromLinkX.Any(n => n.Id == Node4.Id));

            var reachableNodesFromLinkA = GetUniqueReachableNodes(LinkA.Id, LinkA).ToList();
            Assert.Equal(3, reachableNodesFromLinkA.Count());
            Assert.True(reachableNodesFromLinkA.Any(n => n.Id == Node1.Id));
            Assert.True(reachableNodesFromLinkA.Any(n => n.Id == Node2.Id));
            Assert.True(reachableNodesFromLinkA.Any(n => n.Id == Node4.Id));
        }
    }

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
            Assert.True(false, "//TODO");
        }
    }
}
