<Query Kind="Program" />

void Main()
{
	
}

// IME I PREZIME:
// BROJ INDEKSA:

// ZADATAK 1 - Implementacija metode za izgrađivanje najkraće putanje
// -------------------------------------------------
public static void DijkstrasAlgorithm(int[,] graph, int nodeCount, int startVertex)
{
	int[] vertices = new int[nodeCount]; //lista cvorova
	int[] previousVertices = new int[nodeCount]; //lista prethodnih cvorova
	int[] distances = new int[nodeCount];
	bool[] isShortestPaths = new bool[nodeCount];
	HashSet<int>[] shortestPaths = new HashSet<int>[nodeCount]; //niz lista najkracih putanja (svaki cvor ima svoju najkracu putanju do polaznog cvora)

	for (int i = 0; i < nodeCount; ++i)
	{
		vertices[i] = i;
		previousVertices[i] = i;
		distances[i] = int.MaxValue;
		isShortestPaths[i] = false;
		shortestPaths[i] = new HashSet<int>();
	}

	distances[startVertex] = 0;

	for (int count = 0; count < nodeCount - 1; ++count)
	{
		int u = ExtractMin(distances, isShortestPaths, nodeCount);
		isShortestPaths[u] = true;
		
		for (int v = 0; v < nodeCount; ++v)
		{
            //Relaksacija cvora
			if (!isShortestPaths[v] && Convert.ToBoolean(graph[u, v]) && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
            {
				previousVertices[v] = u; //Ovde se gradi lista prethodnika za svaki čvor na osnovu relaksacije, a na osnovu koje se moze izvuci najkraca putanja
				distances[v] = distances[u] + graph[u, v];						
			}                    
        }				
	}

	BuildShortestPaths(vertices, previousVertices, shortestPaths);
	PrintResults(distances, vertices, shortestPaths);
}

private static int ExtractMin(int[] distances, bool[] isShortestPaths, int nodeCount)
{
	int minimumTemp = int.MaxValue;
	int minimumIndex = 0;

	for (int v = 0; v < nodeCount; ++v)
	{
		if (isShortestPaths[v] == false && distances[v] <= minimumTemp)
		{
			minimumTemp = distances[v];
			minimumIndex = v;
		}
	}

	return minimumIndex;
}

// -------------------------------------------------
private static void BuildShortestPaths(int[] vertices, int[] previousVertices, HashSet<int>[] shortestPaths)
{
	
}
// -------------------------------------------------

private static void PrintResults(int[] distance, int[] vertices, HashSet<int>[] shortestPaths)
{
	Console.WriteLine("Cvor  |  Udaljenost od starta | Putanja");

	for (int i = 0; i < vertices.Length; ++i)
    {
        if (distance[i] != int.MaxValue)
        {
            if (i < 10)
            {
                Console.WriteLine("{0}     | {1}                     |{2}  ", i, distance[i], string.Join(", ", shortestPaths[i].Reverse()));
            }
            else
            {
                Console.WriteLine("{0}    | {1}                     | {2}  ", i, distance[i], string.Join(", ", shortestPaths[i].Reverse()));
            } 
        }
	}
}
// -------------------------------------------------



// ZADATAK 2 - Dupliranje ponavljajućih karaktera
// -------------------------------------------------
//public static string addMoreDuplicates(string str)
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
            HashTableChaining doubleHashTable = new HashTableChaining(2 * ht.TableSize);

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



// ZADATAK 3 - Provera putanje sa sekvencom čvorova
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
	
	public void Insert(int value)
    {
        root = InsertNode(root, value, null);
    }
	
	// -------------------------------------------------
	//public bool checkIfPathExists(int[] arr) 
	//{
	
	//}
	
	//private bool checkIfPathExists(Node curr, int[] arr, int index) 
	//{
	
	//}
	// -------------------------------------------------
	
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
