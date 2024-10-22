
struct TemplateInfo
{
    public TemplateInfo(string param_1, string param_2, string param_3)
    {
        VariableOne = param_1;
        VariableTwo = param_2;
        VariableThree = param_3;
    }

    public string VariableOne;
    public string VariableTwo;
    public string VariableThree;
}

public class Template
{
    public TemplateInfo Info;

    public Template(string param_1, string param_2, string param_3)
    {
        Info = new TemplateInfo(param_1, param_2, param_3);
    }

    public static Template Create(TemplateInfo info)
    {
        return new Template(info);
    }
}