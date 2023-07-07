# GCGov
 Gestor de Contratos Governamentais

Atualizar contexto do banco
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=GestorContratos;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c GCGovContext --force

