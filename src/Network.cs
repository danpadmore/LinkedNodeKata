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
        protected readonly List<Link> _links;

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
    }
}