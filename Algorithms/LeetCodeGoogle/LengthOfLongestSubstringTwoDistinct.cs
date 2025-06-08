namespace Algorithms.LeetCodeGoogle;

public class LengthOfLongestSubstringTwoDistinct
{
    public int Solve(string str) {
        
        if(str.Length == 0){
            return 0;
        }
        
        // cacabbb
        var left = 0;
        var right = 0;
        var result = 0;
        var window = new Dictionary<char, int>();
        var available = 2;
        
        while(right < str.Length){
            
            var letter = str[right];
            
            if(window.ContainsKey(letter)){
                window[letter]++;
                result = Math.Max(result, right - left + 1);
                right++;
                continue;
            }
            
            if(available > 0){
                window[letter] = 1;
                available--;
                result = Math.Max(result, right - left + 1);
                right++;
                continue;
            }
            
            var removeLetter = str[left];
            
            while(window[removeLetter] != 0){
                window[str[left]]--;
                left++;
            }
            
            right++;
            
        }
        
        return Math.Max(result, right - left + 1);
    }
}