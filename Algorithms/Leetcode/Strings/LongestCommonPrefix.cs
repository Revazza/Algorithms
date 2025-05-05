namespace Algorithms.DataStructures.Strings;

public class LongestCommonPrefix
{
    public string Solve(string[] strs) {
        if(strs.Length == 0){
            return string.Empty;
        }
        
        var prefix = strs[0];
        while(prefix.Length != 0){
            if(strs.Skip(1).All(s => s.StartsWith(prefix))){
                return prefix;
            }

            prefix = prefix.Substring(0, prefix.Length - 1);
        }

        return prefix;
    }
}