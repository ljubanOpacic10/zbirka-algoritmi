<Query Kind="Program" />

void Main()
{

}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1
// -------------------------------------------------
public class Graphs
{
	public Graphs()
	{
		adjacencyList = new List<LinkedList>();
	}

	private List<LinkedList> adjacencyList; //lista jednostruko povezanih listi, za svaki cvor v postoji j.p.lista u kojoj su cvorovi koji su direktni susedi cvora v
	private int[,] adjacencyMatrix;

	public void addEdge(int u, int v)
	{   
		adjacencyList[u].addTail(v); //u j.p.listu cvora u se dodaje cvor sa vrednoscu v; lista grana cvora u se nalazi na indeksu koji odgovara vrednosti u
		return;
	}
	
	public void addVertex()
	{
		adjacencyList.Add(new LinkedList());//dodavanje novog cvora u graf podrazumeva dodavanje nove prazne j.p.liste
	}
	
	public int[,] convertListToMatrix()
	{
		adjacencyMatrix = new int[adjacencyList.Count, adjacencyList.Count]; //velicina matrice [|v|,|v|]
		
		for (int i = 0; i < adjacencyList.Count; i++)//prolazak kroz listu j.p.listi
		{
			LinkedList.Node temp = adjacencyList[i].head; 
			while (temp != null)//prolazak kroz j.p.listu cvora i
			{
				adjacencyMatrix[i, temp.value] = 1; //belezenje grane [i, temp.value] 
				temp = temp.next;
			}
		}
		return adjacencyMatrix;
	}
	
	public List<LinkedList> convertMatrixToList()
	{
		int l = adjacencyMatrix.GetLength(0);//broj redova => broj cvorova
		adjacencyList = new List<LinkedList>(l);//initializes a new instance of List<T> class that is empty and has the specifies initial capacity
        int i, j;
        
        for (i = 0; i < l; i++) 
        {
            addVertex();
        }
          
        for (i = 0; i < adjacencyMatrix.GetLength(0); i++) //iteracija kroz i cvorova
        {
            for (j = 0; j < adjacencyMatrix.GetLength(1); j++)//dodavanje grane (i,j)
            {
                if (adjacencyMatrix[i,j] == 1) 
                {
					addEdge(i, j);
                }
            }
        }
  
        return adjacencyList;
	}
	
	public void DFS()
    {
		for (int i = 0; i < adjacencyList.Count; i++)//svaki cvor je na pocetku sa tezinom 0 i obojen belo
		{
			LinkedList.Node temp = adjacencyList[i].head;
			while (temp != null)
			{
				temp.weight = 0;
				temp.color = "WHITE";
				temp = temp.next;
			}
		}
		
		time = 0;
		for (int i = 0; i < adjacencyList.Count; i++)
		{
			LinkedList.Node temp = adjacencyList[i].head;
			while (temp != null)
			{
				if (temp.color == "WHITE" && adjacencyList[temp.value].head.color == "WHITE")//posecuje se neposecen cvor
				{
					DFSVisit(temp, i);//rekurzivan poziv
				}
				temp = temp.next;
			}
		}
	}

	// -------------------------------------------------
	private void DFSVisit(LinkedList.Node node, int nodeIndex)
	{
		
	}
	// -------------------------------------------------
	    
    public void printList() 
    {
        for (int v = 0; v < adjacencyList.Count; v++) 
        {
            Console.Write(v); //ispisujemo vrednost cvora ciju j.p.listu posmatramo
			LinkedList.Node temp = adjacencyList[v].head;
            while (temp != null)
			{
				//Console.Write(" --> " + temp.value);
				//ispis za BFS:
				//Console.Write(" --> " + temp.value + "(" + temp.weight+"," +temp.color+")");
				//ispis za DFS:
				Console.Write(" --> " + temp.value + "(" + temp.weight+"," + temp.forest +","+temp.color+")");
				temp = temp.next;
			}
            Console.WriteLine(); //kraj iteracije i - ispisa liste cvora i
        }
    }
	
	public void printMatrix()
	{
	    for(int i = 0; i < adjacencyMatrix.GetLength(0); i++)
	    {
	        for(int j = 0; j < adjacencyMatrix.GetLength(1); j++)
	        {
	            Console.Write(adjacencyMatrix[i, j] + " ");
	        }
	        Console.WriteLine();
	    }
	    Console.WriteLine();
	}
}

public class LinkedList
{
	public class Node
	{
		internal int value;
		internal int weight;
		internal Node next;
		internal String color;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
		
		public Node(int v, int w, Node n, String c)
		{
			value = v;
			weight = w;
			next = n;
			color = c;
		}
	}
	
	public Node head;
	public int count = 0;
	
	public void addHead(int value)
	{
		head = new Node(value, head);
		count++;
	}
	
	public void addTail(int value)
	{
		Node newNode = new Node(value, null);
		Node curr = head;
		
		if (head == null)
		{
			head = newNode;
			count++;
			return;
		}
		
		while (curr.next != null)
		{
			curr = curr.next;
		}
		
		curr.next = newNode;
		count++;
	}
		
	public void print()
	{		
		Node temp = head;
		while (temp != null)
		{			
			Console.Write(temp.value + "  ");
			temp = temp.next;
		}
	}		
	
	public bool searchList(int value)
	{
		Node temp = findNode(value);
		if (temp != null)
		{
			return true;
		}
		return false;
	}
	
	public bool removeHead()
	{
		if (count == 0)
		{
			return false;
		}
		head = head.next;
		count--;
		return true;
	}
	
	public bool delete(int value)
	{
		Node temp = head;
		if (count == 0)
		{
			return false;
		}
		
		if (temp.value == value)
		{
			head = head.next;
			count--;
			return true;
		}
		
		while (temp.next != null)
		{
			if (temp.next.value == value)
			{
				temp.next = temp.next.next;
				count--;
				return true;
			}
			temp = temp.next;
		}
		return false;
	}
	
	public void deleteList()
	{
		head = null;
		count = 0;
	}

	private Node findNode(int value)
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.value == value)
			{
				return temp;
			}
			temp = temp.next;
		}
		return null;
	}
}
// -------------------------------------------------


// ZADATAK 2
// -------------------------------------------------

// -------------------------------------------------
//public static bool IsPalindrome(string word)
//{
//
//}
// -------------------------------------------------


public class Dictionary
{
    HashTableChaining ht;

    public Dictionary()
    {        
        ht = new HashTableChaining(7);
    }

    public void Add(int value)
    {
        CheckLoadFactor();
        ht.Add(value);
    }

    public bool Remove(int value)
    {
        bool removed = ht.Remove(value);
        if (removed)
        {
            CheckLoadFactor();
        }
        return removed;
    }
	
    public bool Find(int value)
    {
        return ht.Find(value);
    }

    public void Print()
    {
        ht.Print();
    }
    
    public void CheckLoadFactor()
    {
        if (ht.N > ht.TableSize)
        {
            HashTableChaining doubleHashTable = new HashTableChaining(2 * ht.TableSize); //Kreiramo duplo vecu hash tabelu

            RehashToNewTable(doubleHashTable);
            ht = doubleHashTable;
        }
        else if (ht.N + 1 < ht.TableSize / 4)
        {
            HashTableChaining shrunkenHashTable = new HashTableChaining(ht.TableSize/2);
            RehashToNewTable(shrunkenHashTable);
            ht = shrunkenHashTable;
        }
    }

    private void RehashToNewTable(HashTableChaining hashTable)
    {
        for (int i = 0; i < ht.TableSize; i++)
        {
            var temp = ht.HashTable[i];
            while (temp != null)
            {
                hashTable.Add(temp.value);
                temp = temp.next;
            }
        }
    }

    public class HashTableChaining
    {
        public int TableSize { get; set; }
        public int N { get; set; }
        public Node[] HashTable { get; set; }

        public class Node
        {
            public int value;
            public Node next;

            public Node(int value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }

        public HashTableChaining(int tableSize)
        {                
            TableSize = tableSize;
            HashTable = new Node[TableSize];
            N = 0;
        }

        private int ComputeHash(int key)
        {
            return key % TableSize;
        }

        public void Add(int value)
        {
            int index = ComputeHash(value);
            HashTable[index] = new Node(value, HashTable[index]);
            N += 1;
        }

        public bool Remove(int value)
        {
            int index = ComputeHash(value);
            Node nextNode, head = HashTable[index];

            if (head != null && head.value == value)
            {
                HashTable[index] = head.next;
                return true;
            }

            while (head != null)
            {
                nextNode = head.next;
                if (nextNode != null && nextNode.value == value)
                {
                    head.next = nextNode.next;
                    N -= 1;
                    return true;
                }
                else
                {
                    head = nextNode;
                }
            }
            return false;
        }

        public bool Find(int value)
        {
            int index = ComputeHash(value);
            Node head = HashTable[index];

            while (head != null)
            {
                if (head.value == value)
                {
                    return true;
                }
                head = head.next;
            }
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < TableSize; i++)
            {
                Console.Write($"\n Printing for index value: { i } \n List of values:");
                Node head = HashTable[i];
                while (head != null)
                {
                    Console.Write($" { head.value } ");
                    head = head.next;
                }
            }
        }
    }
}
// -------------------------------------------------



// ZADATAK 3
// -------------------------------------------------
public class BinarySearchTree
{
	private Node root;
	
	private class Node
	{
		internal int value;
		internal Node lChild;
		internal Node rChild;
		internal Node parent;
		
		public Node(int value, Node left, Node right, Node parent)
		{
			this.value = value;
			lChild = left;
			rChild = right;
			this.parent = parent;
		}
		
		public Node(int value)
		{
			this.value = value;
			lChild = null;
			rChild = null;
			parent = null;
		}
	}
	
	// -------------------------------------------------
	//public void countOddNonLeaves(){
	//	
	//}
	//
	//private int countOddNonLeavesAVL(Node curr){
	//
	//}
	// -------------------------------------------------
	
	public BinarySearchTree()
	{
		root = null;
	}
	
	public void Insert(int value)
	{
		root = InsertNode(root, value, null);
	}
	
	private Node InsertNode(Node node, int value, Node parent)
	{
		if (node == null)
		{
			node = new Node(value, null, null, parent);
		}
		else
		{
			if (node.value > value)
			{
				node.lChild = InsertNode(node.lChild, value, node);
			}
			else
			{
				node.rChild = InsertNode(node.rChild, value, node);
			}
		}
		return node;
	}
	
	public void Delete(int value)
	{
		root = DeleteNode(root, value);
	}
	
	private Node DeleteNode(Node currentNode, int value)
	{
		Node temp = null;
		
		if (currentNode != null)
		{
			if (currentNode.value == value)
			{
				if (currentNode.lChild == null && currentNode.rChild == null)
				{
					return null;
				}
				else
				{
					if (currentNode.lChild == null)
					{
						temp = currentNode.rChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					
					if (currentNode.rChild == null)
					{
						temp = currentNode.lChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					
					Node minNode = FindMinNode(currentNode.rChild);
					int minValue = minNode.value;
					currentNode.value = minValue;
					currentNode.rChild = DeleteNode(currentNode.rChild, minValue);
				}
			}
			else
			{
				if (currentNode.value > value)
				{
					currentNode.lChild = DeleteNode(currentNode.lChild, value);
				}
				else
				{
					currentNode.rChild = DeleteNode(currentNode.rChild, value);
				}
			}
		}

		return currentNode;
	}
	
	public bool Find(int value)
	{
		Node curr = root;
		
		while (curr != null)
		{
			if (curr.value == value)
			{
				return true;
			}
			else if (curr.value > value)
			{
				curr = curr.lChild;
			}
			else
			{
				curr = curr.rChild;
			}
		}
		return false;
	}
	
	public int? FindMin()
	{
		Node min = FindMinNode(root);
		
		if (min == null)
		{
			return null;
		}
		
		return min.value;
	}
	
	public int? FindMax()
	{
		Node max = FindMaxNode(root);
		
		if (max == null)
		{
			return null;
		}
		
		return max.value;
	}
	
	private Node FindMinNode(Node curr)
	{
		if (curr == null)
		{
			return null;
		}
		
		while (curr.lChild != null)
		{
			curr = curr.lChild;
		}
		return curr;
	}
	
	private Node FindMaxNode(Node curr)
	{		
		if (curr == null)
		{
			return null;
		}
		
		while (curr.rChild != null)
		{
			curr = curr.rChild;
		}
		return curr;
	}
	
	public void PrintInOrder()
	{
		PrintInOrder(root);
	}
	
	private void PrintInOrder(Node current)
	{
		if (current != null)
		{
			PrintInOrder(current.lChild);
			Console.Write(" " + current.value);
			PrintInOrder(current.rChild);
		}
	}
}
// -------------------------------------------------
