namespace Algorithms.Leetcode;

public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root) {
        var list = new List<int>();
        InOrderTraversal(root, list);
        for(int i = 0;i < list.Count - 1; i++){
            if(list[i] > list[i + 1]){
                return false;
            }
        }

        return true;
    }

    private void InOrderTraversal(TreeNode root, List<int> list){
        if(root == null){
            return;
        }

        if(root.left != null){
            InOrderTraversal(root.left, list);
        }

        list.Add(root.val);

        if(root.right != null){
            InOrderTraversal(root.right, list);
        }
    } 
}