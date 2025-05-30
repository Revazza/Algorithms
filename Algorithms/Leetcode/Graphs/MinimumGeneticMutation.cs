using System.Text;

namespace Algorithms.Leetcode.Graphs;

public class MinimumGeneticMutation
{
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        // startGene = "AACCGGTT"
        // endGene = "AAACGGTA" 
        // bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
    
        //              AACCGGTT
        //     AACCGGTA
        // 
    
        var mutations = CalculateMutations(startGene, endGene, bank.ToHashSet(), []); 
        return  mutations <= -1 ? -1 : mutations - 1;
    }
    
    int CalculateMutations(
        string startGene,
        string endGene,
        HashSet<string> bank,
        HashSet<string> tried)
    {
        if (startGene == endGene)
        {
            return 1;
        }
    
        if (!tried.Add(startGene))
        {
            return -1;
        }
    
        var minMutations = int.MaxValue;
        foreach (var val in bank)
        {
            if (!ChangeOneCharacterToMatch(startGene, val))
            {
                continue;
            }
    
            var mutations = CalculateMutations(val, endGene, bank, tried);
    
            if (mutations == -1)
            {
                continue;
            }
    
            minMutations = Math.Min(mutations + 1, minMutations);
        }
    
        tried.Remove(startGene);
        
        if (minMutations == int.MaxValue)
        {
            return -1;
        }
    
        return minMutations;
    }
    
    
    bool ChangeOneCharacterToMatch(string startGene, string bankVal)
    {
        var changedAlready = false;
        var builder = new StringBuilder(startGene);
        for (int i = 0; i < builder.Length; i++)
        {
            if (builder[i] == bankVal[i])
            {
                continue;
            }
    
            if (changedAlready)
            {
                return false;
            }
    
            builder[i] = bankVal[i];
            changedAlready = true;
        }
    
        return true;
    }
}