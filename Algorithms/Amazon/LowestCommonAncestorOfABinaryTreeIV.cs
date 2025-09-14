using static Algorithms.DataStructures.Trees.BinaryTree;

namespace Algorithms.Amazon;

public class LowestCommonAncestorOfABinaryTreeIV
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        return FindLowestCAncestor(root, nodes.ToHashSet());
    }

    private TreeNode FindLowestCAncestor(
        TreeNode root, 
        HashSet<TreeNode> nodes){
        
        if(root is null){
            return null;
        }

        if(nodes.Contains(root)){
            return root;
        }

        var left = FindLowestCAncestor(root.left, nodes);
        var right = FindLowestCAncestor(root.right, nodes);

        if(left != null && right != null){
            return root;
        }

        return left ?? right;
    }
}