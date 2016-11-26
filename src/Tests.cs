using System;
using Xunit;

namespace LinkedNodesKata
{
    public class Kata_DetectAllNodesLinked
    {
        [Fact]
        public void Validate()
        {
           Assert.True(false, "//TODO"); 
        }
    }

    public class Kata_DetectNodeLinksFormLoop
    {
        protected Node Node1 { get; private set; }
        protected Node Node2 { get; private set; }
        protected Node Node3 { get; private set; }

        [Fact]
        public void ThenClosedCircuitShouldBeDetected()
        {
            ArrangeClosedCircuit();

            Assert.True(false, "//TODO");
            //Assert.IsTrue(Node1.IsInClosedCircuit());
            //Assert.IsTrue(Node2.IsInClosedCircuit());
            //Assert.IsTrue(Node3.IsInClosedCircuit());
        }

        private void ArrangeClosedCircuit()
        {
            Node1 = new Node();
            Node2 = new Node();
            Node3 = new Node();

            /*Node1.LinkToRightNode(Node2);
            Node2.LinkToRightNode(Node3);
            Node3.LinkToRightNode(Node1);

            Assert.IsNotNull(Node1.LeftNode);
            Assert.IsNotNull(Node1.RightNode);

            Assert.IsNotNull(Node2.LeftNode);
            Assert.IsNotNull(Node2.RightNode);

            Assert.IsNotNull(Node3.LeftNode);
            Assert.IsNotNull(Node3.RightNode);*/
        }
    }
}
