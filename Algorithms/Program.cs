using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;


int NumUniqueEmails(string[] emails) {
     
    var uniqueEmails = new HashSet<string>();
        
    for(int i = 0;i < emails.Length; i++){
        AddEmail(emails[i]);   
    }
        
    return uniqueEmails.Count;
        
}
    
void AddEmail(string email, HashSet<string> emails){
    var split = email.Split("@");
    var local = split.First();
        
    if(local.Length == 0){
        return;
    }
        
    local = local.Split("+").First().Replace(".", "");
        
    var domain = split.Last();
    emails.Add($"{local}@{domain}");
}



