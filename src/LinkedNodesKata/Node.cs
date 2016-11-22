namespace LinkedNodesKata
{
    public class Node
    {
        public Node LeftNode { get; private set; }
        public Node RightNode { get; private set; }

        public void LinkToRightNode(Node node)
        {
            RightNode = node;
            node.LeftNode = this;
        }

        public bool IsInClosedCircuit()
        {
            var rightNode = RightNode;
            while(rightNode != null)
            {
                if (rightNode == this)
                    return true;

                rightNode = rightNode.RightNode;
            }

            return false;
        }
    }
}
