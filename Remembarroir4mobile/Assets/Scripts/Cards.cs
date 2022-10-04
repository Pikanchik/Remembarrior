using System.Collections;
using System.Collections.Generic;


public class Cards
{
    public Cards[] Stack;
    public string questions;
    public string answers;

    public Cards(string questions, string answers)
    {
        this.questions = questions;
        this.answers = answers;
    }
}
