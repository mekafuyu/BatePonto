using static System.Console;

Ponto[] pontos = new Ponto[1000];
Empregado[] empregados = new Empregado[100];
empregados[0] = new Empregado("Adm","000.000.000-00","00/00/0000","admin8888",true);

WriteLine("\n\n\n\n\n");

while (true)
{
    string? user = null;
    string? pass = null;
    WriteLine("-----LOGIN-----");
    WriteLine("Qual seu usuário (CPF): ");
    user = ReadLine();
    WriteLine("Qual sua senha: ");
    pass = ReadLine();

    for (int i = 0; i < empregados.Length; i++)
    {
        if (!(empregados[i] is null))
        {
            if (empregados[i].Cpf == user)
            {
                if (empregados[i].Senha == pass) {login(empregados[i]);break;}
            }
        }
    }

    WriteLine("\n\n\n\n");

    for (int i = 0; i < pontos.Length; i++)
    {
        if (pontos[i] is null){
            break;
        }
        else WriteLine($"{pontos[i].Value.Nome} - {pontos[i].registro}");
    }
    WriteLine("\n\n");

}


void login(Empregado logged){
    WriteLine($"\n\nLogado como: {logged.Nome}\n");
    WriteLine("1 - Bater ponto\n2 - Adicionar funcionario\n3 - Sair\n");
    string? choice = ReadLine();

    if (choice == "1")
    {
        WriteLine("Data: ");
        string? date = ReadLine();
        WriteLine("Horario: ");
        string? hour = ReadLine();
        BaterPonto(logged, date, hour);
    }

    else if (choice == "2" && logged.Adm)
    {
        WriteLine("Nome: "); string? Nome = ReadLine();

        WriteLine("Cpf: "); string? Cpf = ReadLine();

        WriteLine("Data de nascimento: "); string? Nasc = ReadLine();

        WriteLine("Senha: "); string? Senha = ReadLine();

        WriteLine("Administrador (sim/nao): ");
        string? adm = ReadLine();
        bool Adm;
        if (adm == "sim") Adm=true;
        else Adm=false;

        Empregado newEmp = new Empregado(Nome,Cpf,Nasc,Senha,Adm);

        for (int i = 0; i < pontos.Length; i++)
            {
                if (empregados[i] is null)
                {
                    empregados[i] = newEmp;
                    return;
                }
            }
        
        
    }
    else if (choice=="3") return;
    else WriteLine("Operação Inválida");
}




void BaterPonto(Empregado emp, string data, string hora)
{
    for (int i = 0; i < pontos.Length; i++)
    {
        if (pontos[i] is null)
        {
            pontos[i] = new Ponto(emp, data, hora);
            return;
        }
    }
}

public class Ponto
{
    public Ponto(Empregado value, string data, string hora)
    {
        this.Value = value;
        this.registro = data + " " + hora;
    }

    public Empregado Value { get; set; }
    public string registro { get; private set; }
}

public class Empregado
{

    public string Nome      { get; set; }
    private long   cpf;
    public string Nasc      { get; set; }
    public string Senha     { get; set; }
    public bool   Adm       { get; set; }

    public string Cpf
    {   
        get { string tempCpf = this.cpf.ToString(); while (tempCpf.Length<11) tempCpf = tempCpf.Insert(0,"0"); return tempCpf.Insert(9,"-").Insert(6,".").Insert(3,"."); }
        set { this.cpf = long.Parse(value.Replace(".","").Replace("-","")); }
    }

    public Empregado( string Nome, string Cpf, string Nasc, string Senha, bool Adm)
    {   
        this.Nome  = Nome;
        this.cpf   = long.Parse(Cpf.Replace(".","").Replace("-",""));
        this.Nasc  = Nasc;
        this.Senha = Senha;
        this.Adm   = Adm;
    }
}




