var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var trie = new Trie();

var N = int.Parse(sr.ReadLine());
for (var i = 0; i < N; i++)
{
    var parts = sr.ReadLine().Split();
    trie.Insert(parts.Skip(1).ToArray());
}

trie.Sort();
trie.Display();

sw.Close();
sr.Close();

class TrieNode
{
    public Dictionary<string, TrieNode> children;

    public TrieNode()
    {
        children = new Dictionary<string, TrieNode>();
    }

    public void Sort()
    {
        foreach (var child in children)
        {
            child.Value.Sort();
        }
        
        children = children.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    }
}

class Trie
{
    private TrieNode root;

    // Constructor
    public Trie()
    {
        root = new TrieNode();
    }
    
    public void Sort()
    {
        root.Sort();
    }
    
    public void Insert(string[] words)
    {
        TrieNode node = root;
        foreach (string word in words)
        {
            if (!node.children.ContainsKey(word))
            {
                node.children[word] = new TrieNode();
            }

            node = node.children[word];
        }
    }
    
    public void Display()
    {
        DisplayHelper(root, "");
    }

    private void DisplayHelper(TrieNode node, string indent)
    {
        foreach (var child in node.children)
        {
            Console.WriteLine(indent + child.Key);
            DisplayHelper(child.Value, indent + "--");
        }
    }
}