namespace UFNCC_DotNetASPTeste.Models
{
    public class Usuario
    {
        private int _id;
        private string _nome;
        private string _senha;
        private string _email;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Email { get => _email; set => _email = value; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Senha: {Senha} Email: {Email}";
        }
    }
}
