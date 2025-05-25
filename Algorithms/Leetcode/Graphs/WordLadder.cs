namespace Algorithms.Leetcode.Graphs;

public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        
        if(!wordList.Contains(endWord)){
            return 0;
        }

        return CalculateLength(beginWord, endWord, wordList.ToHashSet());
    }

    private int CalculateLength(
        string beginWord, 
        string endWord, 
        HashSet<string> words){

        var queue = new Queue<(string Word, int Depth)>();
        queue.Enqueue((beginWord, 1));
        var tried = new HashSet<string>();
        tried.Add(beginWord);

        while(queue.Count != 0){
            var current = queue.Dequeue();

            if(current.Word == endWord){
                return current.Depth;
            }

            words.Remove(current.Word);
            foreach(var word in words){
                if(!tried.Contains(word) && DiffersWithOneChar(word, current.Word))
                {
                    tried.Add(word);
                    queue.Enqueue((word, current.Depth + 1));
                }
            }
        }

        return 0;
    }

    private bool DiffersWithOneChar(string first, string second){
        if(first.Length != second.Length){
            return false;
        }

        var difference = 0;

        for(int i = 0;i < first.Length; i++){
            if(first[i] != second[i]){
                difference ++;
            }

            if(difference > 1){
                return false;
            }
        }

        return difference == 1;
    }
}