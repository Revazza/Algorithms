namespace Algorithms.LeetCodeGoogle;

public class LengthOfLongestSubstring
{
    public int Solve(string str) {
        if(str.Length == 0){
            return 0;
        }
        
        var set = new HashSet<char>();
        var left = 0;
        var right = 0;
        var result = 0;
        
        while(right < str.Length){
            if(set.Add(str[right])){
                
                result = Math.Max(right - left + 1, result);
                right++;
                continue;
            }
            
            set.Remove(str[left]);
            left++;
        }
        
        return result;
    }
}