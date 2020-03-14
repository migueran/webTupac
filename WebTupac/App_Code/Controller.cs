using System;
using System.Web;

public class Controller
{
    private HttpRequest request;
    private HttpResponse response;

    public Controller(HttpRequest request, HttpResponse response)
    {
        this.request = request;
        this.response = response;
        MakeQuestions();
    }

    private void MakeQuestions()
    {
        throw new NotImplementedException();
    }
}