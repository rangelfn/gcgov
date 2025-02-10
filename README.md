v# 📌 GCGov - Gestão de Contratos Públicos

## 🚀 Tecnologias
Esse projeto foi desenvolvido com as seguintes tecnologias:
- C#
- .NET 8 (AspNet Core)
- HTML
- CSS
- JavaScript
- GitHub

## 💻 Projeto
O **GCGov** é um sistema desenvolvido para gerenciar contratos públicos do governo do estado de Rondônia.

## 📝 Licença
Esse projeto está sob a licença MIT.

---

## 📢 **Atualizações do Projeto**
### 🔹 **Migração para .NET 8**
O projeto foi atualizado do **.NET 7** para **.NET 8**. Agora, todas as dependências estão compatíveis com a nova versão.

### 🔹 **Novos comandos e otimizações**
Além da atualização, foram adicionados novos comandos para a correta instalação e configuração do ambiente.

---

## **🎯 Orientações para Configuração e Execução**

### **1️⃣ Instalar os pacotes do Entity Framework Core**
Antes de rodar o projeto, instale os pacotes necessários:
```sh
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.4
 dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.4
 dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.4
 dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.3
 dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```
#Liste e veja se os pacotes foram instalados
```sh
-dotnet list package
```

### **2️⃣ Configurar a string de conexão no `appsettings.json`**
Adicione ou edite a seguinte configuração:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=localhost;Initial Catalog=GestorContratos;Integrated Security=True;TrustServerCertificate=True;"
}
```

### **3️⃣ Configurar `Program.cs` para carregar `appsettings.json`**
Após a linha `builder.Services.AddControllersWithViews();`, adicione:
```csharp
// Carregar configurações do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
```

### **4️⃣ Gerar os modelos a partir do banco de dados**
Rode o comando a seguir para gerar os modelos:
```sh
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=GestorContratos;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c GCGovContext --force
```

### **5️⃣ Criar os controladores automaticamente**
Execute o comando para gerar um controlador automaticamente:
```sh
dotnet aspnet-codegenerator controller -name ContratosController -m Contrato -dc GCGovContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

### **6️⃣ Rodar a aplicação**
Agora, execute os seguintes comandos para iniciar a aplicação:
```sh
dotnet restore  # Restaurar dependências
```
```sh
dotnet build  # Compilar o projeto
```
```sh
dotnet run  # Executar o projeto
```

O servidor estará rodando localmente. Acesse no navegador:
```
http://localhost:5000
```
Se estiver rodando via HTTPS:
```
https://localhost:5001
```

---

## **💡 Dicas Adicionais**
- Para **aplicar migrações**, execute:
  ```sh
  dotnet ef migrations add Inicial
  dotnet ef database update
  ```
- Para **verificar pacotes desatualizados**, use:
  ```sh
  dotnet list package --outdated
  ```
- Para **limpar arquivos temporários**, execute:
  ```sh
  dotnet clean
  rm -rf bin obj
  ```

Caso tenha dúvidas, consulte a documentação oficial do [Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/) ou abra uma issue no repositório. 🚀
