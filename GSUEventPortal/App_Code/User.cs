using System;
using System.Collections.Generic;
using System.Web;
public class User
{
    public int id;
    public string name, email, password, type, security_question, security_answer;

    public User(int id, string name, string email, string password, string type, string security_question, string security_answer)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = password;
        this.type = type;
        this.security_answer = security_answer;
        this.security_question = security_question;
    }
}