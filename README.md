# Data Structures and Algorithms

An organized library that includes common data structures and algorithms in C#. 

### Data Structures
- Nodes
- Linked Lists
- Stack
- Queue
- Tree
- Graph
- Trie
- Hash Set
- Hash Table

#### Nodes
- A base class ```Node``` that fundamentally contains just "Data" of any type. The data can be unique depending on the type of structure implementing the inheriting ```Node```. 
- There are node types ```NodeS```, ```NodeD```, ```Vertex```, ```TreeNode```, ```TrieNode``
- ```NodeS``` and ```NodeD``` specifically belong to (a node that isn't in a ```LinkedList```, has a ```LinkedList, ```Tree``` (takes )
- No methods except a ```ToString()``` to ID the node. 

#### Linked Lists
- A base class ```LinkedListBase``` that contains base members and implements an interface ```ILinkedList```. 
- Singly and doubly linked list ```LinkedListS``` and ```LinkedListD``` that are instantiated one or the other depending on user input for the boolean "is_doubly_linked". 
- ```LinkedListS``` uses nodes of type ```NodeS```, while ```LinkedListD``` uses type ```NodeD```.


### Algorithms
- Search
  - Binary Search
- Sort
  - Selection Sort
  - Bubble Sort
  - Insertion Sort
  - Merge Sort
  - Quick Sort
  - Heap Sort
