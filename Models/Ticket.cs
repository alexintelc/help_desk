namespace help_desk.Models;

public class Ticket
{
    public string? RequestId;
    private int creationDate;
    private int dueDate;
    private string? creatorUser;
    private string? description;
    private string? status;

//Setters
private void setRequestId(string requestid){
    this.RequestId = requestid;
}
private void setCreationDate(int creationDate){
    this.creationDate = creationDate;
}
private void setDueDate(int dueDate){
    this.dueDate = dueDate;
}
private void setCreatorUser(string creatorUser){
    this.creatorUser = creatorUser;
}
private void setDescription(string description){
    this.description = description;
}
private void setStatus(string status){
    this.status = status;
}

//Getters
public string getRequestId(string requestid){
    return this.RequestId;
}
public int getCreationDate(int creationDate){
    return this.creationDate;
}
public int getDueDate(int dueDate){
    return this.dueDate;
}
public string getCreatorUser(string creatorUser){
    return this.creatorUser;
}
public string getDescription(string description){
    return this.description;
}
public string getStatus(string status){
   return this.status;
}



}
