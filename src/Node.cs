using System;

namespace LinkedNodesKata
{
    public class Node
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Node(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
