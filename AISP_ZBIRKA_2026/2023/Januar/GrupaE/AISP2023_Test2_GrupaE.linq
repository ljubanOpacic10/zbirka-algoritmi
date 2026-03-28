<Query Kind="Program" />

void Main()
{
	int[] keys = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21};
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

	private List<LinkedList> adjacencyList; 
	private int[,] adjacencyMatrix;

	public void addEdge(int u, int v)
	{   
		adjacencyList[u].addTail(v); 

	}
	
	public void addVertex()
	{
		adjacencyList.Add(new LinkedList());
	}
	
	public int[,] convertListToMatrix()
	{
		adjacencyMatrix = new int[adjacencyList.Count, adjacencyList.Count]; 
		
		for (int i = 0; i < adjacencyList.Count; i++)
		{
			LinkedList.Node temp = adjacencyList[i].head; 
			while (temp != null)
			{
				adjacencyMatrix[i, temp.value] = 1; 
				temp = temp.next;
			}
		}
		return adjacencyMatrix;
	}
	
	public List<LinkedList> convertMatrixToList()
	{
		int l = adjacencyMatrix.GetLength(0);
		adjacencyList = new List<LinkedList>(l);
        int i, j;
        
        for (i = 0; i < l; i++) 
        {
            addVertex();
        }
          
        for (i = 0; i < adjacencyMatrix.GetLength(0); i++) 
        {
            for (j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                if (adjacencyMatrix[i,j] == 1) 
                {
					addEdge(i, j);
                }
            }
        }
  
        return adjacencyList;
	}
	
	// -------------------------------------------------
	/*public void BFS(int startVertex)
	{
		for (int i = 0; i < adjacencyList.Count; i++)
		{
			LinkedList.Node temp = adjacencyList[i].head;
			while (temp != null)
			{
				temp.weight = 0;
				temp.color = "WHITE";
				temp = temp.next;
			}
		}

		LinkedList.Node startNode = adjacencyList[startVertex].head;
		startNode.color = "GRAY";

		Queue queue = new Queue();
		queue.Enqueue(startNode.value);
		// -- NASTAVITI IMPLEMENTACIJU ALGORITMA
	}*/
	// -------------------------------------------------
	    
    public void printList() 
    {
        for (int v = 0; v < adjacencyList.Count; v++) 
        {
            Console.Write(v); 
			LinkedList.Node temp = adjacencyList[v].head;
            while (temp != null)
			{
				//Console.Write(" --> " + temp.value);
				//ispis za BFS:
				Console.Write(" --> " + temp.value + "(" + temp.weight+"," +temp.color+")");
				//ispis za DFS:
				//Console.Write(" --> " + temp.value + "(" + temp.weight+"," + temp.forest +","+temp.color+")");
				temp = temp.next;
			}
            Console.WriteLine(); 
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

public class Queue
{
	private Node tail = null;
	private int count = 0;

	private class Node
	{
		internal int value;
		internal Node next;

		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
	}

	public int Size()
	{
		return count;
	}

	public bool isEmpty
	{
		get
		{
			return count == 0;
		}
	}

	public void Enqueue(int value)
	{
		Node temp = new Node(value, null);
		if (tail == null)
		{
			tail = temp;
			tail.next = tail;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}

	public int? Dequeue()
	{
		if (count == 0)
		{
			return null;
		}

		int value;
		if (tail == tail.next)
		{
			value = tail.value;
			tail = null;
		}
		else
		{
			value = tail.next.value;
			tail.next = tail.next.next;
		}
		count--;
		return value;
	}

	public int? Peek()
	{
		if (count == 0)
		{
			return null;
		}

		int value;
		if (tail == tail.next)
		{
			value = tail.value;
		}
		else
		{
			value = tail.next.value;
		}
		return value;
	}
}

public class LinkedList
{
	public class Node
	{
		internal int value;
		internal int weight;
		internal int forest;
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



// ZADATAK 2
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
	//public void countNonLeaves(){
	//	
	//}
	//
	//private Node countNonLeavesBST(Node curr){
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




// ZADATAK 3
// -------------------------------------------------

// -------------------------------------------------
//public static double percentOfSimilarityAfterSubsequence(string str1, string str2, string substr)
//{
//
//}
// -------------------------------------------------


public class KarpRabinAlgorithm
{
	private readonly static int d = 256;
	
	public static void search(String pattern, String text, int q)
	{
		int M = pattern.Length; 
        int N = text.Length; 
        int i, j; 
        int patternHash = 0; // Hash vrednost obrasca koji se trazi 
        int textHash = 0; // Hash vrednost svakog prozora
        int h = 1; 
      
		// Racunanje parametra h
        for (i = 0; i < M-1; i++)
		{
            h = (h * d) % q; 
      	}
	  
		// Racunanje Hash vrednosti obrasca i prvog prozora u tekstu
        for (i = 0; i < M; i++) 
        { 
            patternHash = (d * patternHash + pattern[i]) % q; 
            textHash = (d * textHash + text[i]) % q; 
        }
      
		// Prolazak kroz svaki pojedinacni prozor u tekstu, n-m+1 prozora
        for (i = 0; i <= N - M; i++) 
        { 
			// Proveravanje da li se Hash-ovane vrednosti obrasca i trenutnog prozora poklapaju
			// U slucaju poklapanja Hash vrednosti neophodno je proveriti karaktere jedan po jedan
            if ( patternHash == textHash ) 
            { 
                // Proveravanje pojedinacnih karaktera
                for (j = 0; j < M; j++) 
                { 
                    if (text[i + j] != pattern[j])
					{
                        break; 
                	}
				} 
      
                // p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]
				// Ukoliko su svi karakteri obrasca identicni kao karakteri trenutnog prozora, obrazac je pronadjen
                if (j == M)
				{
                    Console.WriteLine("Pattern found at index " + i); 
            	}
			} 
   
			// Racunanje hash vrednosti narednog prozora, tj. brisanje prve cifre i dodavanje nove na kraj prozora
			// Ponovno racunanje Hash vrednosti novog prozora
            if ( i < N - M ) 
            { 
                textHash = (d * (textHash - text[i] * h) + text[i + M]) % q; 
      
                // Konverzija u slucaju da Rehash funkcija vrati negativan broj
                if (textHash < 0)
				{
                	textHash = (textHash + q); 
            	}
			} 
        }
	}
}

public class MinHash
{
	private int numHashFunctions;
    public delegate uint Hash(int toHash);
    private Hash[] hashFunctions;
	
    // Constructor passed universe size and number of hash functions
    public MinHash(int universeSize, int numHashFunctions)
    {
        this.numHashFunctions = numHashFunctions;
        // number of bits to store the universe
        int u = BitsForUniverse(universeSize);
        GenerateHashFunctions(u);
    }
 
    // Generates the Universal Random Hash functions
    private void GenerateHashFunctions(int u)
    {
        hashFunctions = new Hash[numHashFunctions];
 
        // will get the same hash functions each time since the same random number seed is used
        Random r = new Random(10);
        for (int i = 0; i < numHashFunctions; i++)
        {
            uint a = 0;
            // parameter a is an odd positive
            while (a % 1 == 1 || a <= 0)
			{
                a = (uint)r.Next();
            }
			uint b = 0;
            int maxb = 1 << u;
            // parameter b must be greater than zero and less than universe size
            while (b <= 0)
			{
				b = (uint)r.Next(maxb);                 
				hashFunctions[i] = x => QHash(x, a, b, u);
        	}
		}
    }
 
    // Returns the number of bits needed to store the universe
    public int BitsForUniverse(int universeSize)
    {
        return (int)Math.Truncate(Math.Log((double)universeSize, 2.0)) + 1;
    }
 
    // Universal hash function with two parameters a and b, and universe size in bits
    private static uint QHash(int x, uint a, uint b, int u)
    {
        return (a * (uint)x + b) >> (32 - u);
    }
 
    // Returns the list of min hashes for the given set of word Ids
    public List<uint> GetMinHash(List<uint> wordIds)
    {
        uint[] minHashes = new uint[numHashFunctions];
        for (int h = 0; h < numHashFunctions; h++)
        {
            minHashes[h] = int.MaxValue;
        }
        foreach (int id in wordIds)
        {
            for (int h = 0; h < numHashFunctions; h++)
            {
                uint hash = hashFunctions[h](id);
                minHashes[h] = Math.Min(minHashes[h], hash);
            }
        }
        return minHashes.ToList();
    }
 
    // Calculates the similarity of two lists of min hash values. Approximately Numerically equivilant to Jaccard Similarity
    public double Similarity(List<uint> l1, List<uint> l2)
    {
        return Jaccard.Calc(l1, l2);
    }
}

public class Jaccard
{
	private static double Calc(HashSet<uint> hs1, HashSet<uint> hs2)
	{
	    return ((double)hs1.Intersect(hs2).Count() / (double)hs1.Union(hs2).Count());
	}
		
 	public static double Calc(List<uint> ls1, List<uint> ls2)
 	{
      	HashSet<uint> hs1 = new HashSet<uint>(ls1);
      	HashSet<uint> hs2 = new HashSet<uint>(ls2);
      	return Calc(hs1, hs2);
 	}
}
