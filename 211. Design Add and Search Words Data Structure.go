/*Design a data structure that supports adding new words and finding if a string matches any previously added string.

Implement the WordDictionary class:

WordDictionary() Initializes the object.
void addWord(word) Adds word to the data structure, it can be matched later.
bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.
 

Example:

Input
["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
Output
[null,null,null,null,false,true,true,true]

Explanation
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("bad");
wordDictionary.addWord("dad");
wordDictionary.addWord("mad");
wordDictionary.search("pad"); // return False
wordDictionary.search("bad"); // return True
wordDictionary.search(".ad"); // return True
wordDictionary.search("b.."); // return True
 

Constraints:

1 <= word.length <= 25
word in addWord consists of lowercase English letters.
word in search consist of '.' or lowercase English letters.
There will be at most 2 dots in word for search queries.
At most 104 calls will be made to addWord and search.*/
type WordDictionary struct {
    chars [26]*WordDictionary;
    end bool;
}


func Constructor() WordDictionary {
    dict := WordDictionary{
        chars: [26]*WordDictionary{},
    }
    return dict
}


func (this *WordDictionary) AddWord(word string)  {
    node := this;
    for _, letter := range(word) {
        letter -= 'a';
        if node.chars[letter] == nil {
            node.chars[letter] = &WordDictionary{
                chars: [26]*WordDictionary{},
            }
        }
        node = node.chars[letter]
    }    
    node.end = true;
}


func (this *WordDictionary) Search(word string) bool {
    queue := []*WordDictionary{ this };
    runeWord := []rune(word)
    index := 0
    for len(queue) > 0 && index < len(runeWord) {
        ch := runeWord[index]
        if (ch != '.') {
            ch -= 'a';
        }
        index++;

        size := len(queue);
        for i := 0; i < size; i++ {
            node := queue[0]
            queue = queue[1:]

            if ch == '.' {
                found := false
                for _, node := range(node.chars) {
                    if (node != nil) {                        
                        if (node.end) {
                            found = true
                        }
                        queue = append(queue, node)
                    }
                }
                if found && index == len(word) {
                    return true;
                }
            } else {
                if node.chars[ch] != nil {
                    if (node.chars[ch].end && index == len(word)) {
                        return true;
                    }
                    queue = append(queue, node.chars[ch])
                }
            }
        }
    }
    return false;
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * obj := Constructor();
 * obj.AddWord(word);
 * param_2 := obj.Search(word);
 */
