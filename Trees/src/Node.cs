using System;

namespace src
{
    public class Node
    {
        public Node Left {get;set;}
        public Node Right{get;set;}
        public int Data{get;private set;}

        public Node(int data){
            Data = data;
        }
    }
}
