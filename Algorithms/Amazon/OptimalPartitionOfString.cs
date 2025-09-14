namespace Algorithms.Amazon;

public class OptimalPartitionOfString
{
    public int PartitionString(string str) {
        
        var tracker = new HashSet<char>();
        var subCount = 0;
        
        for(int i = 0;i < str.Length; i++){
            var letter = str[i];
            if(!tracker.Contains(letter)){
                tracker.Add(letter);
                continue;
            }

            subCount++;
            tracker.Clear();
            tracker.Add(letter);
        }

        if(tracker.Count != 0){
            subCount++;
        }

        return subCount;
    }
}