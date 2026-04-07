/*
A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

Implement the Trie class:

Trie() Initializes the trie object.
void insert(String word) Inserts the string word into the trie.
boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.
 

Example 1:

Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]

Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True
 

Constraints:

1 <= word.length, prefix.length <= 2000
word and prefix consist only of lowercase English letters.
At most 3 * 104 calls in total will be made to insert, search, and startsWith.
*/
type Trie struct {
    chars [26]*Trie;
    end bool;
}


func Constructor() Trie {
    t := Trie{
        chars: [26]*Trie{},
    }
    return t;
}


func (this *Trie) Insert(word string)  {
    node := this;
    for _, letter := range(word) {
        if node.chars[letter - 'a'] == nil {
            node.chars[letter - 'a'] = &Trie{
                chars: [26]*Trie{},
            }
        }
        node = node.chars[letter - 'a']
    }

    node.end = true;
}


func (this *Trie) Search(word string) bool {
    node := this;
    for _, letter := range(word) {
        if node.chars[letter - 'a'] == nil {
            return false;
        }
        node = node.chars[letter - 'a']
    }

    return node.end;
}


func (this *Trie) StartsWith(prefix string) bool {
    node := this;
    for _, letter := range(prefix) {
        if node.chars[letter - 'a'] == nil {
            return false;
        }
        node = node.chars[letter - 'a']
    }
    return true;
}


/**
 * Your Trie object will be instantiated and called as such:
 * obj := Constructor();
 * obj.Insert(word);
 * param_2 := obj.Search(word);
 * param_3 := obj.StartsWith(prefix);
 */
