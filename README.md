## 🚀 Tecnologias
Esse projeto foi desenvolvido com as seguintes tecnologias:
- C#
- AspNet Core
- HTML
- CSS
- JavaScript
- Github

## 💻 Projeto
Projeto GCGov desenvolvido para gerenciar contratos publicos do governo do estado de Rôndonia.

## 📝 Licença
Esse projeto está sob a licença MIT.

### **Orientaçãoes**
#Passo 1: Instalar os pacotes Microsoft EF para habilitar as ferramentas de scaffolding.
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

#Passo 2: Configurar o arquivo appsettings.json (acrecentar as seguintes linhas)
``` "ConnectionStrings": {
"DefaultConnection": "Data Source=localhost;Initial Catalog=GestorContratos;Integrated
Security=True;TrustServerCertificate=True;"
}
```

#Passo 3: Configurar o arquivo Program.cs para ler o arquivo appsettings.json (acrecentar as seguintes
linhas depois da linha builder.Services.AddControllersWithViews(); )
```// Configure the app configuration by loading appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
```

#Passo 4: Rodar o comando Scaffold-DbContext
```
Scaffold-DbContext "Data Source=localhost;Initial Catalog=GestorContratos;Integrated
Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

#Passo 5: Criar os controladores com o commando codegenerator
```
dotnet aspnet-codegenerator controller -name ContratosController -m Contrato -dc GestorContratosContext --
relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

#Passo 6: Atualizar contexto do banco
```
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=GestorContratos;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c GCGovContext --force
```
