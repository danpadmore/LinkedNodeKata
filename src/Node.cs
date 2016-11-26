using System;

namespace LinkedNodesKata
{
    public class Node
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Node()
        {
            Id = Guid.NewGuid();
        }
    }
}
