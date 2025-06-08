namespace Algorithms.LeetCodeGoogle;

public class StrobogrammaticNumber
{
    public IList<string> FindStrobogrammatic(int n) {
        var rotates = new Dictionary<char, char>();
        rotates.Add('0','0');
        rotates.Add('1','1');
        rotates.Add('6','9');
        rotates.Add('8','8');
        rotates.Add('9','6');

        IsStrobogrammatic("10", rotates);
        var available = rotates.Select(kvp => int.Parse(kvp.Key.ToString())).ToList();
        
        var result = new List<string>();
        Find("", n, rotates, available, result);
        return result;
    }
    
    private void Find(
        string current,
        int n, 
        Dictionary<char, char> rotates, 
        List<int> available,
        List<string> result){
        
        if(current.Length == n){
            if(IsStrobogrammatic(current, rotates)){
                result.Add(current);
            }
            
            return;
        }
        
        for(int i = 0;i < available.Count; i++){
            if(current.Length == 0 && available[i] == 0){
                continue;
            }
            
            Find(current + available[i].ToString(), n, rotates, available, result);
        }
    }
    
    private bool IsStrobogrammatic(string str, Dictionary<char, char> rotates){
        var stroboGrammatic = "";
        
        for(int i = str.Length - 1;i >= 0; i--){
            stroboGrammatic += rotates[str[i]];
        }
        
        return str == stroboGrammatic;
    }
}