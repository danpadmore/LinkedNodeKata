using System;

namespace LinkedNodesKata
{
    public class Link
    {
        public Guid Id { get; private set; }

        private Node _firstNode;
        public Node FirstNode 
        {
             get { return _firstNode; }
             set
             {
                 if(_secondNode == value)
                    throw new InvalidOperationException("FirstNode and SecondNode cannot be the same node");

                 _firstNode = value;
             }
        }

        private Node _secondNode;
        public Node SecondNode
        {
            get { return _secondNode; }
            set
            {
                if(_firstNode == value)
                    throw new InvalidOperationException("FirstNode and SecondNode cannot be the same node");

                _secondNode = value;
            }
        }

        public Link()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{FirstNode.Name} <--> {SecondNode.Name}";
        }
    }
}