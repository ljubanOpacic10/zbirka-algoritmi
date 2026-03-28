<Query Kind="Program" />

void Main()
{
		// ZADATAK 1
	GFG graph = new GFG();
	
	//6 cvorova oznacenih vrednostima 0,1,2,3,4,5
	//graph.addVertex();
	//graph.addVertex();
	//graph.addVertex();
	//graph.addVertex();
	//graph.addVertex();
	//graph.addVertex();
	//
	//graph.addEdge(0, 0);
	//graph.addEdge(0, 1);
	//graph.addEdge(0, 3);
	//graph.addEdge(0, 2);
	//
	//graph.addEdge(1, 1);
	//graph.addEdge(1, 0);
	//graph.addEdge(1, 3);
	//graph.addEdge(1, 4);
	//
	//graph.addEdge(2, 2);
	//graph.addEdge(2, 0);
	//graph.addEdge(2, 3);
	//
	//graph.addEdge(3, 3);
	//graph.addEdge(3, 1);
	//graph.addEdge(3, 0);
	//graph.addEdge(3, 2);
	//graph.addEdge(3, 4);
	//
	//graph.addEdge(4, 4);
	//graph.addEdge(4, 1);
	//graph.addEdge(4, 3);
	//graph.addEdge(4, 5)
	//
	//graph.addEdge(5, 5);
	//graph.addEdge(5, 4);
	
	//graph.adjacencyMatrix = new int[,]
	//{
	//	{ 1, 1, 1, 1, 0, 0 },
	//	{ 1, 1, 0, 1, 1, 0 },
	//	{ 1, 0, 1, 1, 0, 0 },
	//	{ 1, 1, 1, 1, 1, 0 },
	//	{ 0, 1, 0, 1, 1, 1 },
	//	{ 0, 0, 0, 0, 1, 1 }	
	//};
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1
// -------------------------------------------------
public class GFG
{
	public GFG()
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
	
	// -------------------------------------------------
//	public List<LinkedList> convertMatrixToList (int[,] adjacencyMatrix, int vertex)
//	{
//
//	}
	// -------------------------------------------------
	    
    public void printList(List<LinkedList> adjListArray) 
    {
        for (int v = 0; v < adjListArray.Count; v++) 
        {
            Console.Write(v);
			LinkedList.Node temp = adjListArray[v].head;
            while (temp != null)
			{
				Console.Write(" --> " + temp.value);
				temp = temp.next;
			}
            Console.WriteLine();
        }
    }
	
	public void printMatrix(int[,] adj, int v)
	{
	    for(int i = 0; i < v; i++)
	    {
	        for(int j = 0; j < v; j++)
	        {
	            Console.Write(adj[i, j] + " ");
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
		internal Node next;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
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
public class Avl
{
	private Node root;
	
	private class Node
	{
		internal Node lChild;
		internal Node rChild;
		internal Node parent;
		internal int value;
		
		public Node(int value, Node rChild, Node lChild, Node parent)
		{
			this.value = value;
			this.rChild = rChild;
			this.lChild = lChild;
			this.parent = parent;
		}
	}	
		
	public Avl(){}
	
	// -------------------------------------------------
	//public void printOddLeaves()
	//{
	//
	//}
	//
	//private Node printOddLeavesAVL(Node curr)
	//{
	//
	//}
	// -------------------------------------------------
	
	public void Insert(int value)
    {
        root = InsertNode(root, value, null);
    }
	
	private Node InsertNode(Node current, int value, Node parent)
	{
		if (current == null)
		{
			current = new Node(value, null, null, parent);
		}
		else
		{
			if (current.value > value)
			{
				current.lChild = InsertNode(current.lChild, value, current);				
			}
			else
			{
				current.rChild = InsertNode(current.rChild, value, current);				
			}
			current = BalanceTree(current);
		}
		
		return current;
	}
	
	public bool Find(int value)
    {
        Node result = FindNode(root, value);
		if (result != null)
		{
			return true;
		}
		return false;
    }
	
    private Node FindNode(Node current, int value)
    {	
		Node temp = current;
		
		while (temp != null)
		{
			if (temp.value == value)
			{
				return temp;
			}
			
			if (value < temp.value)
			{
				temp = temp.lChild;
			}
			else
			{
				temp = temp.rChild;
			}
		}	
		return null;
    }
	
	public void Delete(int value)
	{
		root = DeleteNode(root, value);
	}
	
	private Node DeleteNode(Node current, int value)
	{
		Node parent = null;
		
		if (current != null)
		{
			if (value == current.value)
			{
				if (current.rChild != null) //ako postoji child onda sl cvor prevezati na parent od ovoga sto se brise
				{
					parent = current.rChild;
					while (parent.lChild != null)
	                {
	                    parent = parent.lChild; //trazimo minimalni element u desnom podstablu
	                }
	                current.value = parent.value; //upisujemo minimalni element na mesto elementa koji brisemo
	                current.rChild = DeleteNode(current.rChild, parent.value); //pozivamo se opet da obrisemo ovaj minimalni element koji je otisao gore
					if (GetBalanceFactor(current) == 2) //rebalansiranje ako je potrebno
                    {
                        if (GetBalanceFactor(current.lChild) >= 0)
                        {
                            current = RotateR(current);
                        }
                        else 
						{ 
							current = DoubleRotateLR(current); 
						}
                    }
				}
				else
				{
					return current.lChild;
				}
			}
			else if (value < current.value) //idemo levo
			{
				current.lChild = DeleteNode(current.lChild, value);
                if (GetBalanceFactor(current) == -2)//here
                {
                    if (GetBalanceFactor(current.rChild) <= 0)
                    {
                        current = RotateL(current);
                    }
                    else
                    {
                        current = DoubleRotateRL(current);
                    }
                }
			}
			else //value > current.value //idemo desno
			{
				current.rChild = DeleteNode(current.rChild, value);
                if (GetBalanceFactor(current) == 2)
                {
                    if (GetBalanceFactor(current.lChild) >= 0)
                    {
                        current = RotateR(current);
                    }
                    else
                    {
                        current = DoubleRotateLR(current);
                    }
                }
			}
		}
		return current;
	}
	
	//Vrsi balansiranje stabla u datom cvoru
	private Node BalanceTree(Node current)
	{
		int balanceFactor = GetBalanceFactor(current);
		
		if (balanceFactor > 1) //Levo podstablo je to koje je vise
		{
			if (GetBalanceFactor(current.lChild) > 0)
			{
				current = RotateR(current);
			}
			else
			{
				current = DoubleRotateLR(current);
			}
		}
		else if (balanceFactor < -1) //Desno podstablo je to koje je vise
		{
			if (GetBalanceFactor(current.rChild) > 0)
			{
				current = DoubleRotateRL(current);
			}
			else
			{
				current = RotateL(current);
			}
		}
		return current;
	}
	
	//Vraca faktor balansiranosti za dati cvor
	private int GetBalanceFactor(Node current)
	{
		int lSubtreeHeight = GetHeight(current.lChild);
		int rSubtreeHeight = GetHeight(current.rChild);
		return lSubtreeHeight - rSubtreeHeight;
	}
	
	//Rekurzijom racuna visinu levog i desnog podstabla
	private int GetHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int left = GetHeight(current.lChild);
            int right = GetHeight(current.rChild);
            int m = left > right ? left : right;
            height = m + 1; //Dodaje se 1 zbog current cvora (parent)
        }
        return height;
    }
	
	//Metode za 4 slucaja rotacije
	private Node RotateL(Node parent)
	{
		Node pivot = parent.rChild;
		parent.rChild = pivot.lChild;
		pivot.parent = parent.parent;
		parent.parent = pivot;

		if (parent.rChild != null)
        {
			parent.rChild.parent = parent;
		}
		pivot.lChild = parent;
		return pivot;
	}
	private Node RotateR(Node parent)
	{
		Node pivot = parent.lChild;
		parent.lChild = pivot.rChild;
		pivot.parent = parent.parent;
		parent.parent = pivot;

		if (parent.lChild != null)
		{
			parent.lChild.parent = parent;
		}

		pivot.rChild = parent;
		return pivot;
	}
    private Node DoubleRotateRL(Node parent)
    {
        Node pivot = parent.rChild;
        parent.rChild = RotateR(pivot);
        return RotateL(parent);
    }
    private Node DoubleRotateLR(Node parent)
    {
        Node pivot = parent.lChild;
        parent.lChild = RotateL(pivot);
        return RotateR(parent);
    }	
	
	//Display tree
	public void PrintInOrder()
    {            
        InOrderDisplay(root);
        Console.WriteLine();
    }
    private void InOrderDisplay(Node current)
    {
        if (current != null)
        {
            InOrderDisplay(current.lChild);
            Console.Write($"{current.value} ");
            InOrderDisplay(current.rChild);
        }
    }
	
	//Temp metode za proveru stabla - ovo se ne radi na casu	
	public void IsBalanced()
	{
		if (IsBalanced(root))
			Console.WriteLine("Tree is balanced");
		else
			Console.WriteLine("Tree is not balanced");
	}
	
	private bool IsBalanced(Node node) 
    { 
        int lh;
  
        int rh; 
		
        if (node == null) 
        { 
            return true; 
        } 
          
        lh = Height(node.lChild); 
        rh = Height(node.rChild); 
  
        if (Math.Abs(lh - rh) <= 1 && IsBalanced(node.lChild) && IsBalanced(node.rChild)) 
        { 
            return true; 
        } 
        return false; 
    } 
  
    private int Height(Node node) 
    { 
        
        if (node == null) 
        { 
            return 0; 
        } 
  
        return 1 + Math.Max(Height(node.lChild), Height(node.rChild)); 
    } 
}
// -------------------------------------------------



// ZADATAK 3
// -------------------------------------------------
// -------------------------------------------------
//public static bool checkIfMutationIsPossible (string str, string mutatingSubsequence, string mutationSubsequence)
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
// -------------------------------------------------