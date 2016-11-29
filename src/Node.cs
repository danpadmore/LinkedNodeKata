using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinkedNodesKata
{
    public class Node
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        private Link _firstLink;
        public Link FirstLink 
        {
            get { return _firstLink; }
            set
            {
                if(value == SecondLink)
                    throw new InvalidOperationException("FirstLink and SecondLink cannot be the same link");

                _firstLink = value;
            }
        }

        private Link _secondLink;
        public Link SecondLink 
        {
            get { return _secondLink; }
            set
            {
                if(value == FirstLink)
                    throw new InvalidOperationException("FirstLink and SecondLink cannot be the same link");

                _secondLink = value;
            }
       }

        public IEnumerable<Link> AllLinks
        {
            get
            {
                if(FirstLink != null)
                    yield return FirstLink;

                if(SecondLink != null)
                    yield return SecondLink;
            }
        }
       

        public Node(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
