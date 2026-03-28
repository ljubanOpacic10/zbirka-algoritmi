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



// ZADATAK 2 - Dupliranje neponavljajućih karaktera
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
public class BinarySearchTree
{
	private Node root;
	
	public class Node
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
	
	public BinarySearchTree()
	{
		root = null;
	}

	// -------------------------------------------------
	//public bool checkIfPathExists(int[] arr) 
	//{
	
	//}
	
	//private bool checkIfPathExists(Node curr, int[] arr, int index) 
	//{
	
	//}
	// -------------------------------------------------
	
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
					if (currentNode.lChild == null) //rChild is not null
					{
						temp = currentNode.rChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					
					if (currentNode.rChild == null) //lChild is not null
					{
						temp = currentNode.lChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					//neither child is null
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
