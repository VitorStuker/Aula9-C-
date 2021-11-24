using Microsoft.EntityFrameworkCore;

//relacionamento bidirecional entre blog e post 
//post eh a unidade dependente 
//se existir a propriedade de Id da unidade principal na dependente, isso significa que é um relacionamento completamente definido (chave estrangeira)

public class Blog
{
    public int BlogId { get; set; } //chave principal - autogerada
    public string Url { get; set; } 
    public List<Post> Posts { get; } = new List<Post>(); //propriedade de navegacao - relacao entre blog e post
}

public class Post
{
    public int PostId { get; set; } //chave principal - autogerada
    public string Title { get; set; } 
    public string Content { get; set; } 
    public Blog Blog { get; set; } //propriedade de navegacao - todo post tem um, e somente um, blog como refêrencia 
    public int BlogId { get; set; } //chave estrangeira
}

public class BlogginContext : DbContext //o objeto Dbcontext esta configurando o mapeamento da classe Blog/Post; e o nome da propriedade como nome da tabela
{
    public DbSet<Blog> Blogs { get; set; } //DbSet prove metodos para operacoes CRUD (tabela Blogs)
    public DbSet<Post> Posts { get; set; } //DbSet prove metodos para operacoes CRUD (tabela Posts)
    public string DbPath { get; set; }
    public BlogginContext() //construtor
    {
        var folder = Environment.SpecialFolder.LocalApplicationData; //pegando o diretorio da minha aplicacao
        var path = Environment.GetFolderPath(folder); //stringao com o caminho do diretorio
        DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db"; //caractere que separa diretorios (visto que em cada OS eh um diferente)
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //seto as configuracoes do banco de dados
    {
        optionsBuilder.UseSqlite($"Data Source = {DbPath}"); //acessa o servidor sqlite pela string DbPath
    }

}