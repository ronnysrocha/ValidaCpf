// See https://aka.ms/new-console-template for more information
Console.Write("Digite o CPF para validação: ");
string cpf = Console.ReadLine();

CpfValido(cpf);

static bool CpfValido(string cpf)
{
    if (string.IsNullOrEmpty(cpf.Trim()))
    {
        Console.WriteLine("CPF não informado!");
        return false;
    }

    if ((cpf.Length != 11 && cpf.Length != 14) || numeroIguais(cpf))
    {
        Console.WriteLine("CPF informado incorretamente!");
        return false;
    }
    
    if (digitoVerificador(cpf, 1) != int.Parse(cpf[cpf.Length - 2].ToString()) || digitoVerificador(cpf, 2) != int.Parse(cpf[cpf.Length - 1].ToString()))
    {
        Console.WriteLine("CPF inválido!");
        return false;
    }

    Console.WriteLine("CPF válido!");
    return true;
}

static bool numeroIguais(string cpf)
{
    char digitoAuxiliar = cpf[0];

    for (int i = 0; i < cpf.Length; i++)
    {
        if (digitoAuxiliar != cpf[i] && cpf[i] != '.' && cpf[i] != '-' && cpf[i] != ' ')
        {
            return false;
        }
    }
    return true;
}

static int digitoVerificador(string cpf, int dv)
{
    int controleDv = dv + 9;
    int somaDv = 0;
    int digitoPosicao;
    int calculoDigito;

    if (dv > 2)
    {
        Console.WriteLine("O CPF só possui 2 digitos verificadores!");
        return 0;
    }

    for (int i = 0; i < cpf.Length - (3 - dv); i++)
    {
        if (cpf[i].ToString() != "-" && cpf[i].ToString() != "." && cpf[i].ToString() != " ")
        {
            digitoPosicao = int.Parse(cpf[i].ToString());
            calculoDigito = digitoPosicao * controleDv;
            somaDv += calculoDigito;
            controleDv--;
        }
    }

    return (somaDv % 11 < 2) ? 0 : (11 - (somaDv % 11));
}
