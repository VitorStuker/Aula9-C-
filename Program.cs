using Microsoft.EntityFrameworkCore;
using (var db = new BlogginContext()) //ponto de acesso ao nosso banco de dados. ao final do programa, eu quero limpar tudo
{
    /*Console.WriteLine("Inserindo:");
    var umBlog = new Blog { Url = "http://blogs.msdn.com/adonet"}; //entidade Detached  (nao esta no contexto do EF)
    db.Blogs.Add(umBlog); //DbContext, conheca esse novo blog! entidade marcada como Added
    db.SaveChanges(); //DbContext, salve as alterações!

    Console.WriteLine("Consultando BD:");
    var blogs = db.Blogs.ToList(); //executando opecao .ToList() do LINQ
    blogs.ForEach(b => Console.WriteLine($"{b.BlogId} - {b.Url}"));*/

    /*Console.WriteLine("Consultando BD:");
    var blog = db.Blogs.Find(3);
    Console.WriteLine($"{blog.BlogId} - {blog.Url}");

    Console.WriteLine("Alterando:");
    blog.Posts.Add(new Post { Title = "Novo Post", Content = "Novo conteudo"});
    db.SaveChanges(); //vai de unchanged para modified, alem de criar uma nova entidade Post (que vai gerar um insert no banco de dados) */

    
    /*Console.WriteLine("Consultando Eager Loading:");
    var blogs = db.Blogs.Include(b => b.Posts).OrderByDescending(b => b.BlogId).ToList(); //consultando, nessa linha, apenas os dados dos blogs
    blogs.ForEach(b => {
        Console.WriteLine($"{b.BlogId} - {b.Url}");
        b.Posts.ForEach(p => Console.WriteLine($"\t{p.PostId} - {p.Title} - {p.Content}"));
    }); */

    /*Console.WriteLine("Consultando Explicit Loading:");
    var blogs = db.Blogs.OrderByDescending(b => b.BlogId).ToList(); //consultando, nessa linha, apenas os dados dos blogs
    blogs.ForEach(b => {
        Console.WriteLine($"{b.BlogId} - {b.Url}");
        db.Entry(b).Collection(b => b.Posts).Load(); //DbContext, pega esse blog! Explicit Loading
        b.Posts.ForEach(p => Console.WriteLine($"\t{p.PostId} - {p.Title}"));
    });*/

    Console.WriteLine("Removendo");
    var blog = db.Blogs.Find(4);
    if (blog != null)
    {
        db.Blogs.Remove(blog);
        db.SaveChanges();
    }
    Console.WriteLine("Consultando BD:");
    var blogs = db.Blogs.ToList(); //executando opecao .ToList() do LINQ
    blogs.ForEach(b => Console.WriteLine($"{b.BlogId} - {b.Url}"));
}