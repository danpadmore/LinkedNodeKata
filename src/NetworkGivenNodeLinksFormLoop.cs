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
}