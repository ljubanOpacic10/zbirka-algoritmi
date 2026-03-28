<Query Kind="Program" />

void Main()
{
	
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1
// -------------------------------------------------
public class GFG
{
	public void insertToList(List<LinkedList> adj, int u, int v)
	{
		adj[u].addTail(v);
		return;
	}
	
	// -------------------------------------------------
//	public int[,] ConvertAdjacencyListToAdjacencyMatrix (List<LinkedList> adjacencyList, int vertex)
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

// -------------------------------------------------
//public static int CountDistinctValues(int[] arr)
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
	//public void countLeaves()
	//{
	//
	//}
	//
	//private Node countLeavesAVL(Node curr)
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
