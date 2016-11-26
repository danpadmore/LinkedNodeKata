using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LinkedNodesKata
{
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

        private IEnumerable<Node> GetUniqueReachableNodes(Guid startingLinkId, Link link)
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
}