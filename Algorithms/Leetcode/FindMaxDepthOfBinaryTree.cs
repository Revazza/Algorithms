namespace Algorithms.Leetcode;

public class FindMaxDepthOfBinaryTree
{
    public int MaxDepth(TreeNode root) {
        if (root == null)
        {
            return 0;
        }
        
        var maxDepth = 0;

        var q = new Queue<(TreeNode Current, int Depth)>();
        q.Enqueue((root,1));

        while (q.Count > 0){
            var (current,depth) = q.Dequeue();
            
            if(maxDepth < depth){
                maxDepth = depth;
            }
            if(current.left != null) q.Enqueue((current.left,depth + 1));
            if(current.right != null) q.Enqueue((current.right,depth + 1));
        }
        
        return maxDepth;
    }
}