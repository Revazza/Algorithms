using System.Text;
using Algorithms.DataStructures.Arrays;
using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;
using Algorithms.Leetcode.Arrays;

EvalRPN(["10","6","9","3","+","-11","*","/","*","17","+","5","+"]).Dump();

int EvalRPN(string[] tokens) {
    var numbers = new Stack<int>();

    foreach(var token in tokens){
        if(int.TryParse(token, out var num)){
            numbers.Push(num);
            continue;
        }

        var first = numbers.Pop();
        var second = numbers.Pop(); 

        if(token == "-"){
            numbers.Push(second - first);
        }
        else if(token == "+"){
            numbers.Push(second + first);
        }
        else if(token == "*"){
            numbers.Push(second * first);
        }
        else{           
            numbers.Push(second / first);
        }

    }

    return numbers.Pop();
}