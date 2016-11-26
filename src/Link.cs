namespace LinkedNodesKata
{
    public class Link
    {
        public Node First { get; set; }
        public Node Second { get; set; }

        public override string ToString()
        {
            return $"{First.Name} <--> {Second.Name}";
        }
    }
}